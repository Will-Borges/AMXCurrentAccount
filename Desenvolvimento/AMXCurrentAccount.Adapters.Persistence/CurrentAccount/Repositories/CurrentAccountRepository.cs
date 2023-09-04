namespace AMXCurrentAccount.Adapters.Persistence.CurrentAccount.Repositories
{
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Adapters.Repositories;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Exceptions;
    using AMXCurrentAccount.Database.CurrentAccount;

    public class CurrentAccountRepository : ICurrentAccountRepository
    {
        public async Task<bool> VerifyCurrentAccountByCurrentAccountNumber(int currentAccountNumber)
        {
            try
            {
                var result = AMXDatabase.CurrentAccountDatabase.Count(q => q.CurrentAccountNumber == currentAccountNumber);
                return result > 0;
            }
            catch
            {
                throw new CurrentAccountException("Error while querying the database.");
            }
        }
    }
}
