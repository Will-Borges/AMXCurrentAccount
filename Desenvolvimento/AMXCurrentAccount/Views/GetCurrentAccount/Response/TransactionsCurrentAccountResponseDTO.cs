namespace AMXCurrentAccount.Views.GetCurrentAccount.Response
{
    public class TransactionsCurrentAccountResponseDTO
    {
        public long TransactionsId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public long SourceAccountId { get; set; }
        public long DestinationAccountId { get; set; }


        public TransactionsCurrentAccountResponseDTO(
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
