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
                        try
                        {
                            Console.Write("Account name: ");
                            var accountName = Console.ReadLine();
                            //if (string.IsNullOrEmpty(accountName))
                            //{
                            //    //raising/throwing
                            //    throw new ArgumentNullException("accountName", "Account name is required!");
                            //}
                            Console.Write("Email Address: ");
                            var emailAddress = Console.ReadLine();
                            //if (string.IsNullOrEmpty(emailAddress))
                            //{
                            //    //raising/throwing
                            //    throw new ArgumentNullException("Email Address", "Email Address is required!");
                            //}

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
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"Error - {ax.Message}");
                        }
                        catch (ArgumentException ax)
                        {
                            Console.WriteLine($"Error - {ax.Message}");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Amount is required!");
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong! Please try again!");
                        }


                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to deposit: ");
                        var depositAmount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNumber, depositAmount);
                        Console.WriteLine("Deposit completed successfully!");
                        break;

                    case "3":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to withdraw: ");
                        var withdrawalAmount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(accountNumber, withdrawalAmount);
                        Console.WriteLine("Withdrawal completed successfully!");
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        var transactions = Bank.GetTransactionsByAccountNumber(accountNumber);
                        foreach (var transaction in transactions)
                        {
                            Console.WriteLine($"TT: {transaction.TransactionType}, TD: {transaction.TransactionDate}, TA: {transaction.Amount}, AN: {transaction.AccountNumber}, D: {transaction.Description}");
                        }
                        break;
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
