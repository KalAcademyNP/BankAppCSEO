using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        private static List<Transaction> transactions = new List<Transaction>();

        /// <summary>
        /// Create a bank account
        /// </summary>
        /// <param name="accountName">Name of your account</param>
        /// <param name="emailAddress">Email address on your account</param>
        /// <param name="accountType">Type of account</param>
        /// <param name="initialDeposit">Initial amount to deposit</param>
        /// <returns>Newly created account</returns>
        public static Account CreateAccount(string accountName, string emailAddress, TypeOfAccounts accountType=TypeOfAccounts.Checking, decimal initialDeposit=0)
        {
            var account = new Account
            {
                AccountName = accountName,
                EmailAddress = emailAddress,
                AccountType = accountType
            };

            accounts.Add(account);

            if (initialDeposit > 0)
            {
                Deposit(account.AccountNumber, initialDeposit);
            }


            return account;
        }


        public static IEnumerable<Account> GetAccountsByEmailAddress(string emailAddress)
        {
            return accounts.Where(a => a.EmailAddress == emailAddress);
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                //throw exception
                return;
            }

            account.Deposit(amount);
            var transaction = new Transaction
            {
                TransactionDate = DateTime.UtcNow,
                TransactionType = TypeOfTransactions.Credit,
                Description = "Bank Deposit",
                Amount = amount,
                AccountNumber = accountNumber
            };

            transactions.Add(transaction);
        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                //throw exception
                return;
            }

            account.Withdraw(amount);
            var transaction = new Transaction
            {
                TransactionDate = DateTime.UtcNow,
                TransactionType = TypeOfTransactions.Debit,
                Description = "Bank Withdrawal",
                Amount = amount,
                AccountNumber = accountNumber
            };

            transactions.Add(transaction);
        }

        public static IEnumerable<Transaction> GetTransactionsByAccountNumber(int accountNumber)
        {
            return transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t =>t.TransactionDate);
        }

    }
}
