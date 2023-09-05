namespace AMXCurrentAccount.Presenters.Interfaces
{
    using AMXCurrentAccount.Views.GetCurrentAccount.Response;
    using AMXCurrentAccount.Views.PostCustomerCurrentAccount.Request;

    public interface ICurrentAccountPresenter
    {
        Task PostCustomerCurrentAccount(CustomerCurrentAccountRequestDTO customerCurrentAccount);
        Task<CustomerCurrentAccountResponseDTO> GetCustomerCurrentAccount(int customerId);
    }
}
