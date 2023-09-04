namespace AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Response.GetCustomerCurrentAccount
{
    public class TransactionsCurrentAccountResponse
    {
        public long TransactionsId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public long SourceAccountId { get; private set; }
        public long DestinationAccountId { get; private set; }


        public TransactionsCurrentAccountResponse(
            long transactionsId,
            decimal amount,
            long sourceAccountId,
            DateTime date,
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
