namespace AMXCurrentAccount.Adapters.Persistence.CurrentAccount.Repositories
{
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Adapters.Repositories;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Entities.PostCustomerCurrentAccount.Request;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Exceptions;
    using AMXCurrentAccount.Database.CurrentAccount;
    using AMXCurrentAccount.Database.CurrentAccount.Models;

    public class CustomerCurrentAccountRepository : ICustomerCurrentAccountRepository
    {
        public async Task InsertCustomerCurrentAccount(CustomerCurrentAccountEntity customerEntity)
        {
            var transactionsDatabase = CreateTransactionsCurrentAccountDatabase(customerEntity.CurrentAccount.Transactions);
            var Current = CreateCurrentAccountDatabase(customerEntity.CurrentAccount, transactionsDatabase);
            var customerDatabase = CreateCustomerCurrentAccountDatabase(customerEntity, Current);

            try
            {
                AMXDatabase.CustomerCurrentAccountDatabase.Add(customerDatabase);
            }
            catch
            {
                throw new CurrentAccountException("Error while querying the database");
            }
        }

        public async Task<CustomerCurrentAccountEntity> GetCustomerCurrentAccountByCustomerId(int customerId)
        {
            try
            {
                var currentAccountDatabase = AMXDatabase.CustomerCurrentAccountDatabase.FirstOrDefault(q => q.CustomerId == customerId);

                var entity = CreateCustomerCurrentAccountEntity(currentAccountDatabase);

                return entity;
            }
            catch 
            {
                throw new CurrentAccountException("Error while querying the database");
            }
        }

        private static CustomerCurrentAccountEntity CreateCustomerCurrentAccountEntity(CustomerCurrentAccountDatabase customerDatabase)
        {
            if (customerDatabase == null)
            {
                return null;
            }

            var transactions = CreateTransactionsCurrentAccountEntity(customerDatabase.CurrentAccount.Transactions);
            var currentAccount = CreateCurrentAccountEntity(customerDatabase, transactions);

            return new CustomerCurrentAccountEntity(
                currentAccount,
                customerDatabase.CustomerId,
                customerDatabase.InitialCredit,
                customerDatabase.Name,
                customerDatabase.Surname);
        }

        private static CurrentAccountEntity CreateCurrentAccountEntity(
            CustomerCurrentAccountDatabase customerDatabase, TransactionsCurrentAccountEntity[] transactionsEntity)
        {
            return new CurrentAccountEntity(
               customerDatabase.CurrentAccount.CurrentAccountId,
               customerDatabase.CurrentAccount.CurrentAccountNumber,
               customerDatabase.CurrentAccount.Balance,
               transactionsEntity);
        }

        private static TransactionsCurrentAccountEntity[] CreateTransactionsCurrentAccountEntity(TransactionsCurrentAccountDatabase[] transactionsDatabase)
        {
            if (transactionsDatabase == null)
            {
                return null;
            }

            var transactionsEntityList = new List<TransactionsCurrentAccountEntity>();
            foreach (var transactionDatabase in transactionsDatabase)
            {
                var transactionsEntity = new TransactionsCurrentAccountEntity(
                    transactionDatabase.TransactionsId,
                    transactionDatabase.Amount,
                    transactionDatabase.Date,
                    transactionDatabase.SourceAccountId,
                    transactionDatabase.DestinationAccountId);

                transactionsEntityList.Add(transactionsEntity);
            }

            return transactionsEntityList.ToArray();
        }

        private static CurrentAccountDatabase CreateCurrentAccountDatabase(
            CurrentAccountEntity customerCurrentAccountEntity, TransactionsCurrentAccountDatabase[] transactionsDatabase)
        {
            return new CurrentAccountDatabase(
                       customerCurrentAccountEntity.CurrentAccountId,
                       customerCurrentAccountEntity.CurrentAccountNumber,
                       customerCurrentAccountEntity.Balance,
                       transactionsDatabase);
        }

        private static TransactionsCurrentAccountDatabase[] CreateTransactionsCurrentAccountDatabase(TransactionsCurrentAccountEntity[] transactionsEntity)
        {
            var transactionsDatabaseList = new List<TransactionsCurrentAccountDatabase>();
            foreach (var transactionEntity in transactionsEntity)
            {
                var transactiondatabase = new TransactionsCurrentAccountDatabase(
                    transactionEntity.TransactionsId,
                    transactionEntity.Amount,
                    transactionEntity.Date,
                    transactionEntity.SourceAccountId,
                    transactionEntity.DestinationAccountId);

                transactionsDatabaseList.Add(transactiondatabase);
            }

            return transactionsDatabaseList.ToArray();
        }

        private static CustomerCurrentAccountDatabase CreateCustomerCurrentAccountDatabase(
            CustomerCurrentAccountEntity customerEntity, CurrentAccountDatabase currentAccountDatabase)
        {
            return new CustomerCurrentAccountDatabase(
                currentAccountDatabase,
                customerEntity.CustomerId,
                customerEntity.InitialCredit,
                customerEntity.Name,
                customerEntity.Surname);
        }
    }
}
