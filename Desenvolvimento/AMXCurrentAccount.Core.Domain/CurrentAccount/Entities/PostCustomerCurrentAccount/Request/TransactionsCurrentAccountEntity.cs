namespace AMXCurrentAccount.Core.Domain.CurrentAccount.Entities.PostCustomerCurrentAccount.Request
{
    public class TransactionsCurrentAccountEntity
    {
        public long TransactionsId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public long SourceAccountId { get; set; }
        public long DestinationAccountId { get; set; }


        public TransactionsCurrentAccountEntity(
            decimal amount,
            DateTime date,
            long sourceAccountId,
            long destinationAccountId)
        {
            TransactionsId = 1;
            Amount = amount;
            Date = date;
            SourceAccountId = sourceAccountId;
            DestinationAccountId = destinationAccountId;
        }

        public TransactionsCurrentAccountEntity(
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
