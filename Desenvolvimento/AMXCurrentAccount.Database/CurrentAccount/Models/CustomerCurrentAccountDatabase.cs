namespace AMXCurrentAccount.Database.CurrentAccount.Models
{
    public class CustomerCurrentAccountDatabase
    {
        public long CustomerId { get; set; }
        public decimal InitialCredit { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public CurrentAccountDatabase CurrentAccount { get; set; }


        public CustomerCurrentAccountDatabase(CurrentAccountDatabase currentAccount, long customerId, decimal initialCredit, string name, string surname)
        {
            CurrentAccount = currentAccount;
            CustomerId = customerId;
            InitialCredit = initialCredit;
            Name = name;
            Surname = surname;
        }
    }
}
