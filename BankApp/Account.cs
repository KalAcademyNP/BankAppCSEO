using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    /// <summary>
    /// This class represents a bank account
    /// where you can deposit or withdraw money from
    /// </summary>
    class Account
    {
        #region Properties
        /// <summary>
        /// Account number for the bank account
        /// </summary>
        public int AccountNumber { get; private set; }
        public string AccountName { get; set; }

        public decimal Balance { get; private set; }
        public string AccountType { get; set; }
        public DateTime CreatedDate { get; set; }

        public string EmailAddress { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Deposit money into your account
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        public void Deposit(decimal amount)
        {
            //Balance = Balance + amount
            Balance += amount;
        }
        
        /// <summary>
        /// Withdraw money from your account
        /// </summary>
        /// <param name="amount">Amount to withdraw</param>
        /// <returns>New balance</returns>
        public decimal Withdraw(decimal amount)
        {
            Balance -= amount;
            return Balance;
        }

        #endregion

    }
}
