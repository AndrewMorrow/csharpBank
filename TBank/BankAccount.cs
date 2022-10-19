using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TBank
{
    internal class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get
            {
                decimal balance = 0;
                foreach(var transaction in allTransactions)
                {
                    balance += transaction.Amount;
                }
                return balance;
            }
        }

        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string owner, decimal initialBalance)
        {
            Owner = owner;
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Transaction");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be greater than zero.");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be greater than zero.");
            }
            if(Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal.");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();
            report.AppendLine("Date\t\tAmount\tNote");

            foreach (var transaction in allTransactions)
            {
                report.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t{transaction.Notes}");
            }
            return report.ToString();
        }
    }
}
