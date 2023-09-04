namespace AMXCurrentAccount.Core.Domain.CurrentAccount.Interfaces
{
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Request.PostCustomerCurrentAccount;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Response.GetCustomerCurrentAccount;

    public interface ICurrentAccountService
    {
        Task PostCustomerCurrentAccount(CustomerCurrentAccountRequest customerCurrentAccount);
        Task<CustomerCurrentAccountResponse> GetCustomerCurrentAccount(int customerId);
    }
}
