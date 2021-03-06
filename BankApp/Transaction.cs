﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public enum TypeOfTransactions
    {
        Debit,
        Credit
    }
    public class Transaction
    {
        public int TransactionId { get; set; }
        public TypeOfTransactions TransactionType { get; set; }

        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }

        public string Description { get; set; }

        public int AccountNumber { get; set; }
        public Account Account { get; set; }

    }
}
