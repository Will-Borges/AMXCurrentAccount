namespace AMXCurrentAccount.Views.GetCurrentAccount.Response
{
    public class CurrentAccountResponseDTO
    {
        public long CurrentAccountId { get; set; }
        public int CurrentAccountNumber { get; set; }
        public decimal Balance { get; set; }
        public TransactionsCurrentAccountResponseDTO[] Transactions { get; set; }

        public CurrentAccountResponseDTO(
            long currentAccountId,
            int currentAccountNumber,
            decimal balance,
            TransactionsCurrentAccountResponseDTO[] transactions)
        {
            CurrentAccountId = currentAccountId;
            CurrentAccountNumber = currentAccountNumber;
            Balance = balance;
            Transactions = transactions;
        }
    }
}
