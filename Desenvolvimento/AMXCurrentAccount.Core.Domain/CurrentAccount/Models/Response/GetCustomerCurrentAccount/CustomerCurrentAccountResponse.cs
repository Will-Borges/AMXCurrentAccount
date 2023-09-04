namespace AMXCurrentAccount.Core.Domain.CurrentAccount.Models.Response.GetCustomerCurrentAccount
{
    public class CustomerCurrentAccountResponse
    {
        public long CustomerId { get; private set; }
        public decimal InitialCredit { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public CurrentAccountResponse CurrentAccount { get; private set; }


        public CustomerCurrentAccountResponse(
            CurrentAccountResponse currentAccount,
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
