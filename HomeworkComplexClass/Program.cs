using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexClass
{
    class Customer
    {
        public string FirstName { get; set; }
        public Account CheckingAccount { get; set; }
        public Account SavingsAccount { get; set; }
        public string WriteInfo(Account account)
        {
            string printString;
            if( account.isOpen == true)
            {
                printString = String.Format("{0}'s {1} has a balance of ${2}", FirstName, account.Type, account.Amount);
            }
            else
            {
                printString = String.Format("{0}'s {1} account is not currently open.", FirstName, account.Type);
            }
            return printString;
        }
        public Customer( string firstName, Account checking, Account savings )
        {
            this.FirstName = firstName;
            this.CheckingAccount = checking;
            this.SavingsAccount = savings;
        }
    }

    class Account
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public bool isOpen { get; set; }
        public Account(int id, decimal amount, string type, bool isOpen)
        {
            this.Id = id;
            this.Amount = amount;
            this.Type = type;
            this.isOpen = isOpen;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Account checkingAccount = new Account(1, 100.00m, "Checking", true);
            Account savingsAccount = new ComplexClass.Account(2, 0.00m, "Savings", false);
            Customer bankUser = new Customer("Alice", checkingAccount, savingsAccount);

            Console.WriteLine(bankUser.WriteInfo(bankUser.CheckingAccount));
            Console.WriteLine(bankUser.WriteInfo(bankUser.SavingsAccount));
            Console.ReadLine();
        }
    }
}
