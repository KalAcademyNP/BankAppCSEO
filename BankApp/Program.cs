using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAccount = new Account();
            myAccount.AccountName = "My checking";
            myAccount.AccountType = TypeOfAccounts.Checking;
            myAccount.Deposit(1000);
            Console.WriteLine($"AN: {myAccount.AccountNumber}, Accountname: {myAccount.AccountName}, B: {myAccount.Balance:C}, CD: {myAccount.CreatedDate}, AT: {myAccount.AccountType}");


            var myAccount2 = new Account();
            myAccount2.AccountName = "My Savings";
            myAccount2.AccountType = TypeOfAccounts.Savings;
            Console.WriteLine($"AN: {myAccount2.AccountNumber}, Accountname: {myAccount2.AccountName}, B: {myAccount2.Balance:C}, CD: {myAccount2.CreatedDate}, AT: {myAccount2.AccountType}");

            var myAccount3 = new Account();
            myAccount3.AccountName = "My Savings";
            Console.WriteLine($"AN: {myAccount3.AccountNumber}, Accountname: {myAccount3.AccountName}, B: {myAccount3.Balance:C}, CD: {myAccount3.CreatedDate}, AT: {myAccount3.AccountType}");

        }



    }
}
