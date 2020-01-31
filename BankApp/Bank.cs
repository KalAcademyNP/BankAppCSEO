﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    static class Bank
    {
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

            if (initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
            }

            return account;
        }
    }
}
