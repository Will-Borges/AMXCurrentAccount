namespace AMXCurrentAccount.Core.Domain.CurrentAccount.Adapters.Repositories
{
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Entities.PostCustomerCurrentAccount.Request;

    public interface ICurrentAccountRepository
    {
        Task<bool> VerifyCurrentAccountByCurrentAccountNumber(int currentAccountNumber);
    }
}
