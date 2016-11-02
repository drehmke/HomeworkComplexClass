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
                printString = String.Format("{0}'s {1} has a balance of {2:c} and is open. \n", FirstName, account.Type, account.Amount);
            }
            else
            {
                printString = String.Format("{0}'s {1} account is not currently open and has a balance of {2:c}. \n", FirstName, account.Type, account.Amount);
            }
            return printString;
        }
        public string Transfer(string from, string to, decimal amt)
        {
            Account[] accounts = { CheckingAccount, SavingsAccount };
            string printMe = "";
            foreach(Account acct in accounts)
            {
                if (acct.Type == from)
                {
                    decimal tempAmt = acct.Amount;
                    acct.Amount = acct.Amount - amt;
                    printMe += String.Format("{0:c} was moved from {1} to {2}. \n", amt, acct.Type, to);
                    printMe += String.Format("The new balance of {0} is {1:c}. \n", acct.Type, acct.Amount);
                    if( (tempAmt > 0) && (acct.Amount <=  0))
                    {
                        acct.isOpen = false;
                        printMe += String.Format("{0} account has been closed because the balance is zero or below. \n", acct.Type);
                    }
                }
                else
                {
                    decimal tempAmt = acct.Amount;
                    acct.Amount = acct.Amount + amt;
                    printMe += String.Format("{0:c} was moved to {1} from {2}. \n", amt, acct.Type, from);
                    printMe += String.Format("The new balance of {0} is {1:c}. \n", acct.Type, acct.Amount);
                    if ((tempAmt <= 0) && (acct.Amount > 0))
                    {
                        acct.isOpen = true;
                        printMe += String.Format("{0} account has been re-opened because it has a balance above zero. \n", acct.Type);
                    }
                }
            }
            return printMe;
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
            Account checkingAccount = new Account(1, 100m, "Checking", true);
            Account savingsAccount = new ComplexClass.Account(2, 0m, "Savings", false);
            Customer bankUser = new Customer("Alice", checkingAccount, savingsAccount);

            Console.WriteLine(bankUser.WriteInfo(bankUser.CheckingAccount));
            Console.WriteLine(bankUser.WriteInfo(bankUser.SavingsAccount));
            Console.WriteLine(bankUser.Transfer(bankUser.CheckingAccount.Type, bankUser.SavingsAccount.Type, 50m));
            Console.WriteLine(bankUser.Transfer(bankUser.SavingsAccount.Type, bankUser.CheckingAccount.Type, 75m));
            Console.ReadLine();
        }
    }
}
