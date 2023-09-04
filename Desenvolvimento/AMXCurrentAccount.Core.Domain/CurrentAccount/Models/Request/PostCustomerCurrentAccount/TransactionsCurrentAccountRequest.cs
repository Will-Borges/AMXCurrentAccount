namespace AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Request.PostCustomerCurrentAccount
{
    public class TransactionsCurrentAccountRequest
    {
        public long TransactionsId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public long SourceAccountId { get; private set; }
        public long DestinationAccountId { get; private set; }


        public TransactionsCurrentAccountRequest(
            decimal amount,
            long sourceAccountId,
            long destinationAccountId)
        {
            Amount = amount;
            Date = DateTime.Now;
            SourceAccountId = sourceAccountId;
            DestinationAccountId = destinationAccountId;
        }
    }
}
