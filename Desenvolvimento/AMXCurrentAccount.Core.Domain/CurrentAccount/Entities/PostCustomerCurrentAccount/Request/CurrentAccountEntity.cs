namespace AMXCurrentAccount.Core.Domain.CurrentAccount.Entities.PostCustomerCurrentAccount.Request
{
    public class CurrentAccountEntity
    {
        public long CurrentAccountId { get; set; }
        public int CurrentAccountNumber { get; set; }
        public decimal Balance { get; set; }
        public TransactionsCurrentAccountEntity[] Transactions { get; set; }


        public CurrentAccountEntity(
            int currentAccountNumber,
            decimal balance,
            TransactionsCurrentAccountEntity[] transactions)
        {
            CurrentAccountId = 1;
            CurrentAccountNumber = currentAccountNumber;
            Balance = balance;
            Transactions = transactions;
        }

        public CurrentAccountEntity(
            long currentAccountId,
            int currentAccountNumber, 
            decimal balance,
            TransactionsCurrentAccountEntity[] transactions)
        {
            CurrentAccountId = currentAccountId;
            CurrentAccountNumber = currentAccountNumber;
            Balance = balance;
            Transactions = transactions;
        }
    }
}
