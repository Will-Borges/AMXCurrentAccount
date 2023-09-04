namespace AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Request.PostCustomerCurrentAccount
{
    public class CurrentAccountRequest
    {
        public long CurrentAccountId { get; private set; }
        public int CurrentAccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public TransactionsCurrentAccountRequest[] Transactions { get; private set; }


        public CurrentAccountRequest() { }


        public void InsertCurrentAccount(
            int currentAccountNumber,
            decimal balance,
            TransactionsCurrentAccountRequest[] transactions)
        {
            CurrentAccountNumber = currentAccountNumber;
            Balance = balance;
            Transactions = transactions;
        }


        public static int CreateRandomNumberCurrentAccount()
        {
            Random random = new Random();
            int reandonNumber = random.Next(10000, 100000);

            return reandonNumber;
        }
    }
}
