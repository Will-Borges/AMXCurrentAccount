namespace AMXCurrentAccount.Core.Domain.CurrentAccount.Entities.PostCustomerCurrentAccount.Request
{
    public class CustomerCurrentAccountEntity
    {
        public long CustomerId { get; set; }
        public decimal InitialCredit { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public CurrentAccountEntity CurrentAccount { get; set; }


        public CustomerCurrentAccountEntity(
            CurrentAccountEntity currentAccount,
            long customerId,
            decimal initialCredit,
            string name,
            string surname)
        {
            CurrentAccount = currentAccount;
            CustomerId = customerId;
            InitialCredit = initialCredit;
            Name = name;
            Surname = surname;
        }
    }
}
