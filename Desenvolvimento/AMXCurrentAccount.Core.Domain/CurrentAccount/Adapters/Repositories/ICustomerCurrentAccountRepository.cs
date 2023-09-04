namespace AMXCurrentAccount.Core.Domain.CurrentAccount.Adapters.Repositories
{
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Entities.PostCustomerCurrentAccount.Request;

    public interface ICustomerCurrentAccountRepository
    {
        Task InsertCustomerCurrentAccount(CustomerCurrentAccountEntity customerEntity);
        Task<CustomerCurrentAccountEntity> GetCustomerCurrentAccountByCustomerId(int customerId);
    }
}
