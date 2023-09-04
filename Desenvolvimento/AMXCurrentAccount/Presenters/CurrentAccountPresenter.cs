namespace AMXCurrentAccount.Presenters
{
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Exceptions;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Interfaces;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Request.PostCustomerCurrentAccount;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Response.GetCustomerCurrentAccount;
    using AMXCurrentAccount.Presenters.Interfaces;
    using AMXCurrentAccount.Views.GetCurrentAccount.Response;
    using AMXCurrentAccount.Views.PostCustomerCurrentAccount.Request;

    public class CurrentAccountPresenter : ICurrentAccountPresenter
    {
        private readonly ICurrentAccountService _currentAccountService;


        public CurrentAccountPresenter(ICurrentAccountService currentAccountService)
        {
            _currentAccountService = currentAccountService;
        }

        public async Task PostCustomerCurrentAccount(CustomerCurrentAccountRequestDTO customerCurrentAccount)
        {
            ValidCustomerCurrentAccountRequestDTO(customerCurrentAccount);
            var request = CreatePostCustomerCurrentAccount(customerCurrentAccount);

            await _currentAccountService.PostCustomerCurrentAccount(request);
        }

        public async Task<CustomerCurrentAccountResponseDTO> GetCustomerCurrentAccount(int customerId)
        {
            var result = await _currentAccountService.GetCustomerCurrentAccount(customerId);

            var customerDto = CreateCustomerCurrentAccountResponseDTO(result);
            return customerDto;
        }

        private static void ValidCustomerCurrentAccountRequestDTO(CustomerCurrentAccountRequestDTO customerCurrentAccount)
        {
            if (customerCurrentAccount == null)
            {
                throw new CurrentAccountException("Error: The object CustomerCurrentAccountRequestDTO cannot be null");
            }
        }

        private static CustomerCurrentAccountRequest CreatePostCustomerCurrentAccount(CustomerCurrentAccountRequestDTO customerCurrentAccount)
        {
            var result = new CustomerCurrentAccountRequest(
                customerCurrentAccount.CustomerId,
                customerCurrentAccount.InitialCredit,
                customerCurrentAccount.Name,
                customerCurrentAccount.Surname);

            return result;
        }

        private static CustomerCurrentAccountResponseDTO CreateCustomerCurrentAccountResponseDTO(CustomerCurrentAccountResponse customerRequest)
        {
            var transactionsDto = CreateTransactionsCurrentAccountEntity(customerRequest.CurrentAccount.Transactions);

            var currentAccountDto = new CurrentAccountResponseDTO(
                customerRequest.CurrentAccount.CurrentAccountId,
                customerRequest.CurrentAccount.CurrentAccountNumber,
                customerRequest.CurrentAccount.Balance,
                transactionsDto);

            return new CustomerCurrentAccountResponseDTO(
                customerRequest.CustomerId, 
                customerRequest.InitialCredit,
                customerRequest.Name,
                customerRequest.Surname,
                currentAccountDto);
        }

        private static TransactionsCurrentAccountResponseDTO[] CreateTransactionsCurrentAccountEntity(TransactionsCurrentAccountResponse[] transactionsResponse)
        {
            var transactionsDtoList = new List<TransactionsCurrentAccountResponseDTO>();
            foreach (var transactionResponse in transactionsResponse)
            {
                var transactionDTO = new TransactionsCurrentAccountResponseDTO(
                    transactionResponse.TransactionsId,
                    transactionResponse.Amount,
                    transactionResponse.Date,
                    transactionResponse.SourceAccountId,
                    transactionResponse.DestinationAccountId);

                transactionsDtoList.Add(transactionDTO);
            }

            return transactionsDtoList.ToArray();
        }
    }
}
