namespace AMXCurrentAccount.Presenters.Interfaces
{
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Response.GetCustomerCurrentAccount;
    using AMXCurrentAccount.Views.PostCustomerCurrentAccount;

    public interface ICurrentAccountPresenter
    {
        Task PostCustomerCurrentAccount(CustomerCurrentAccountRequestDTO customerCurrentAccount);
        Task<CustomerCurrentAccountResponse> GetCustomerCurrentAccount(int currentAccountNumber);
    }
}
