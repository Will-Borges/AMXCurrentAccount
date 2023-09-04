using AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Request.PostCustomerCurrentAccount;

namespace AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Response.GetCustomerCurrentAccount
{
    public class CurrentAccountResponse
    {
        public long CurrentAccountId { get; private set; }
        public int CurrentAccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public TransactionsCurrentAccountResponse[] Transactions { get; private set; }


        public CurrentAccountResponse(
            long currentAccountId,
            int currentAccountNumber,
            decimal balance, 
            TransactionsCurrentAccountResponse[] transactions)
        {
            CurrentAccountId = currentAccountId;
            CurrentAccountNumber = currentAccountNumber;
            Balance = balance;
            Transactions = transactions;
        }
    }
}
