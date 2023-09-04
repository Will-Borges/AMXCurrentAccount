namespace AMXCurrentAccount.Database.CurrentAccount
{
    using AMXCurrentAccount.Database.CurrentAccount.Models;

    public static class AMXDatabase
    {
        public static List<CurrentAccountDatabase> CurrentAccountDatabase { get; set; }
        public static List<CustomerCurrentAccountDatabase> CustomerCurrentAccountDatabase { get; set; }


        public static void startDatabase()
        {
            CurrentAccountDatabase = new List<CurrentAccountDatabase>();
            CustomerCurrentAccountDatabase = new List<CustomerCurrentAccountDatabase>();
        }
    }
}
