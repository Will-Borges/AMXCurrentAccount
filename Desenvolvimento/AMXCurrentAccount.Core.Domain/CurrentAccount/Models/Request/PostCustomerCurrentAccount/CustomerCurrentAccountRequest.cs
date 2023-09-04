namespace AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Request.PostCustomerCurrentAccount
{
    public class CustomerCurrentAccountRequest
    {
        public long CustomerId { get; private set; }
        public decimal InitialCredit { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public CurrentAccountRequest CurrentAccount { get; private set; }
        

        public CustomerCurrentAccountRequest(long customerId, decimal initialCredit, string name, string surname)
        {
            CustomerId = customerId;
            InitialCredit = initialCredit;
            Name = name;
            Surname = surname;
        }

        public void AddCurrentAccount(CurrentAccountRequest currentAccount)
        {
            CurrentAccount = currentAccount;
        }
    }
}
