namespace AMXCurrentAccount.Views.PostCustomerCurrentAccount.Request
{
    public class CustomerCurrentAccountRequestDTO
    {
        public long CustomerId { get; set; }
        public decimal InitialCredit { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
