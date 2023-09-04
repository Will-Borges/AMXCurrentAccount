namespace AMXCurrentAccount.Database.CurrentAccount.Models
{
    public class TransactionsCurrentAccountDatabase
    {
        public long TransactionsId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public long SourceAccountId { get; set; }
        public long DestinationAccountId { get; set; }


        public TransactionsCurrentAccountDatabase(
            long transactionsId,
            decimal amount,
            DateTime date,
            long sourceAccountId,
            long destinationAccountId)
        {
            TransactionsId = transactionsId;
            Amount = amount;
            Date = date;
            SourceAccountId = sourceAccountId;
            DestinationAccountId = destinationAccountId;
        }
    }
}
