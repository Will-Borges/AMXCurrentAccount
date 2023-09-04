namespace AMXCurrentAccount.Core.Application.CurrentAccount.Services
{
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Adapters.Repositories;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Entities.PostCustomerCurrentAccount.Request;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Exceptions;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Interfaces;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Request.PostCustomerCurrentAccount;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Response.GetCustomerCurrentAccount;
    using System;

    public class CurrentAccountService : ICurrentAccountService
    {
        private readonly ICurrentAccountRepository _currentAccountRepository;
        private readonly ICustomerCurrentAccountRepository _customerCurrentAccountRepository;


        public CurrentAccountService(
            ICurrentAccountRepository currentAccountRepository,
            ICustomerCurrentAccountRepository customerCurrentAccountRepository)
        {
            _currentAccountRepository = currentAccountRepository;
            _customerCurrentAccountRepository = customerCurrentAccountRepository;
        }


        public async Task PostCustomerCurrentAccount(CustomerCurrentAccountRequest customer)
        {
            var currentAccount = await CreateCurrentAccount(customer);
            customer.AddCurrentAccount(currentAccount);

            var entity = CreateCustomerCurrentAccountEntity(customer);
            await InsertCustomerCurrentAccount(entity);
        }

        public async Task<CustomerCurrentAccountResponse> GetCustomerCurrentAccount(int customerId)
        {
            var entity = await _customerCurrentAccountRepository.GetCustomerCurrentAccountByCustomerId(customerId);
            VerifyIfExistCustomerCurrentAccountByCustomerId(entity);

            var currentAccountResponse = CreateCustomerCurrentAccountResponse(entity);
            return currentAccountResponse;
        }

        private static void VerifyIfExistCustomerCurrentAccountByCustomerId(CustomerCurrentAccountEntity entity)
        {
            if (entity == null)
            {
                throw new CurrentAccountException("Error: Customer not found");
            }
        }

        private async Task InsertCustomerCurrentAccount(CustomerCurrentAccountEntity currentAccount)
        {
            await _customerCurrentAccountRepository.InsertCustomerCurrentAccount(currentAccount);
        }

        private async Task<CurrentAccountRequest> CreateCurrentAccount(CustomerCurrentAccountRequest customer)
        {
            var currentAccount = new CurrentAccountRequest();
            int numberCurrentAccount = 0;

            bool numberCurrentAccountExisting = true;
            while (numberCurrentAccountExisting)
            {
                numberCurrentAccount = CurrentAccountRequest.CreateRandomNumberCurrentAccount();
                numberCurrentAccountExisting = await FindExistingCurrentAccountNumber(numberCurrentAccount);
            }

            return await VerifyInitialCredit(customer, currentAccount, numberCurrentAccount);
        }

        private async Task<CurrentAccountRequest> VerifyInitialCredit(
            CustomerCurrentAccountRequest customer,
            CurrentAccountRequest currentAccount,
            int numberCurrentAccount)
        {
            if (customer.InitialCredit > 0)
            {
                var transactions = CreateTransactionsCurrentAccount(customer.InitialCredit, numberCurrentAccount);
                currentAccount.InsertCurrentAccount(numberCurrentAccount, customer.InitialCredit, transactions);
            }
            else
            {
                var transactions = new TransactionsCurrentAccountRequest[0];
                currentAccount.InsertCurrentAccount(numberCurrentAccount, 0, transactions);
            }

            return currentAccount;
        }

        private static TransactionsCurrentAccountRequest[] CreateTransactionsCurrentAccount(decimal initialCredit, int numberCurrentAccount)
        {
            var transactions = new TransactionsCurrentAccountRequest[1];

            var transaction = new TransactionsCurrentAccountRequest(initialCredit, numberCurrentAccount, numberCurrentAccount);

            transactions[0] = transaction;
            return transactions;
        }

        private async Task<bool> FindExistingCurrentAccountNumber(int numberCurrentAccount)
        {
            var result = await _currentAccountRepository.VerifyCurrentAccountByCurrentAccountNumber(numberCurrentAccount);
            return result;
        }

        private static CustomerCurrentAccountEntity CreateCustomerCurrentAccountEntity(CustomerCurrentAccountRequest customerRequest)
        {
            var transactionsEntity = CreateTransactionsCurrentAccountEntity(customerRequest.CurrentAccount.Transactions);

            var currentAccountEntity = new CurrentAccountEntity(
                customerRequest.CurrentAccount.CurrentAccountNumber,
                customerRequest.CurrentAccount.Balance,
                transactionsEntity);

            var customerEntity = CreateCustomerCurrentAccountEntity(customerRequest, currentAccountEntity);

            return customerEntity;
        }

        private static CustomerCurrentAccountEntity CreateCustomerCurrentAccountEntity(
            CustomerCurrentAccountRequest customerRequest, CurrentAccountEntity currentAccountEntity)
        {
            var customerEntity = new CustomerCurrentAccountEntity(
                currentAccountEntity,
                customerRequest.CustomerId,
                customerRequest.InitialCredit,
                customerRequest.Name,
                customerRequest.Surname);

            return customerEntity;
        }

        private static TransactionsCurrentAccountEntity[] CreateTransactionsCurrentAccountEntity(TransactionsCurrentAccountRequest[] transactionsRequest)
        {
            var transactionsEntityList = new List<TransactionsCurrentAccountEntity>();
            foreach (var transactionRequest in transactionsRequest)
            {
                var transactionEntity = new TransactionsCurrentAccountEntity(
                    transactionRequest.Amount,
                    transactionRequest.Date,
                    transactionRequest.SourceAccountId,
                    transactionRequest.DestinationAccountId);

                transactionsEntityList.Add(transactionEntity);
            }

            return transactionsEntityList.ToArray();
        }

        private static CustomerCurrentAccountResponse CreateCustomerCurrentAccountResponse(CustomerCurrentAccountEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            
            var transactions = CreateTransactionsCurrentAccountResponse(entity.CurrentAccount.Transactions);
            var current = CreateCurrentAccountResponse(entity.CurrentAccount, transactions);

            return new CustomerCurrentAccountResponse(
                current,
                entity.CustomerId,
                entity.InitialCredit,
                entity.Name,
                entity.Surname);
        }

        private static CurrentAccountResponse CreateCurrentAccountResponse(
            CurrentAccountEntity currentAccount, TransactionsCurrentAccountResponse[] transactions)
        {
            if (currentAccount == null)
            {
                return null;
            }

            return new CurrentAccountResponse(
                currentAccount.CurrentAccountId,
                currentAccount.CurrentAccountNumber,
                currentAccount.Balance,
                transactions);
        }

        private static TransactionsCurrentAccountResponse[] CreateTransactionsCurrentAccountResponse(TransactionsCurrentAccountEntity[] transactionsEntity)
        {
            if (transactionsEntity == null)
            {
                return null;
            }

            var transactionsResponseList = new List<TransactionsCurrentAccountResponse>();
            foreach (var transactionEntity in transactionsEntity)
            {
                var transactionsResponse = new TransactionsCurrentAccountResponse(
                    transactionEntity.TransactionsId,
                    transactionEntity.Amount,
                    transactionEntity.SourceAccountId,
                    transactionEntity.Date,
                    transactionEntity.DestinationAccountId);

                transactionsResponseList.Add(transactionsResponse);
            }

            return transactionsResponseList.ToArray();
        }
    }
}
