namespace AMXCurrentAccount.Database.CurrentAccount.Models
{
    public class CurrentAccountDatabase
    {
        public long CurrentAccountId { get; set; }
        public int CurrentAccountNumber { get; set; }
        public decimal Balance { get; set; }
        public TransactionsCurrentAccountDatabase[] Transactions { get; set; }


        public CurrentAccountDatabase(
            long currentAccountId,
            int currentAccountNumber,
            decimal balance,
            TransactionsCurrentAccountDatabase[] transactions)
        {
            CurrentAccountId = currentAccountId;
            CurrentAccountNumber = currentAccountNumber;
            Balance = balance;
            Transactions = transactions;
        }
    }
}
