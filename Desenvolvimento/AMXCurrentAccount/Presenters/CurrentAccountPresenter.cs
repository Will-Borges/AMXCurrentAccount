namespace AMXCurrentAccount.Presenters
{
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Exceptions;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Interfaces;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Request.PostCustomerCurrentAccount;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Response.GetCustomerCurrentAccount;
    using AMXCurrentAccount.Presenters.Interfaces;
    using AMXCurrentAccount.Views.PostCustomerCurrentAccount;

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

        public async Task<CustomerCurrentAccountResponse> GetCustomerCurrentAccount(int customerId)
        {
            var result = await _currentAccountService.GetCustomerCurrentAccount(customerId);
            return result;
        }

        private static void ValidCustomerCurrentAccountRequestDTO(CustomerCurrentAccountRequestDTO customerCurrentAccount)
        {
            if (customerCurrentAccount == null)
            {
                throw new CurrentAccountException("Tha object CustomerCurrentAccountRequestDTO cannot be null");
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
    }
}
