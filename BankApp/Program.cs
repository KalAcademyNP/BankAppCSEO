using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("******************************************");
            Console.WriteLine("Welcome to my bank!");
            Console.WriteLine("******************************************");

            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print all accounts");
                Console.WriteLine("5. Print all transactions");

                Console.Write("Please select an option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the bank!");
                        return;
                    case "1":
                        Console.Write("Account name: ");
                        var accountName = Console.ReadLine();
                        Console.Write("Email Address: ");
                        var emailAddress = Console.ReadLine();
                        Console.Write("Initial amount to deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Account type: ");
                        var accountTypes = Enum.GetNames(typeof(TypeOfAccounts));
                        for (int i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}. {accountTypes[i]}");
                        }
                        Console.Write("Select an option: ");
                        var accountType = Enum.Parse<TypeOfAccounts>(Console.ReadLine());

                        var myAccount = Bank.CreateAccount(accountName, emailAddress, accountType, amount);
                        Console.WriteLine($"AN: {myAccount.AccountNumber}, email Address: {myAccount.EmailAddress}, Accountname: {myAccount.AccountName}, B: {myAccount.Balance:C}, CD: {myAccount.CreatedDate}, AT: {myAccount.AccountType}");

                        break;
                    case "2":
                    case "3":
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                    default:
                        Console.WriteLine("Invalid option - try again!");
                        break;
                }
            }

        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email Address: ");
            var email = Console.ReadLine();

            var accounts = Bank.GetAccountsByEmailAddress(email);
            foreach (var a in accounts)
            {
                Console.WriteLine($"AN: {a.AccountNumber}, email Address: {a.EmailAddress}, Accountname: {a.AccountName}, B: {a.Balance:C}, CD: {a.CreatedDate}, AT: {a.AccountType}");
            }
        }
    }
}
