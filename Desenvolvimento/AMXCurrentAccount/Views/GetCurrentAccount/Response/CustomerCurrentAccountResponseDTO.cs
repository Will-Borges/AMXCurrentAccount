namespace AMXCurrentAccount.Views.GetCurrentAccount.Response
{
    public class CustomerCurrentAccountResponseDTO
    {
        public long CustomerId { get; set; }
        public decimal InitialCredit { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public CurrentAccountResponseDTO CurrentAccount { get; set; }


        public CustomerCurrentAccountResponseDTO(
            long customerId,
            decimal initialCredit,
            string name,
            string surname,
            CurrentAccountResponseDTO currentAccount)
        {
            CustomerId = customerId;
            InitialCredit = initialCredit;
            Name = name;
            Surname = surname;
            CurrentAccount = currentAccount;
        }
    }
}
