namespace TBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Ashwee", 2000);
            account.MakeDeposit(500, DateTime.Now, "Christmas Money");
            account.MakeWithdrawal(500, DateTime.Now, "Jetski");
            Console.WriteLine(account.Owner);
            Console.WriteLine( account.Number);
            Console.WriteLine(account.Balance);
            Console.WriteLine(account.GetAccountHistory());


        }
    }
}