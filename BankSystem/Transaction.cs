using System;
using System.Collections.Generic;

namespace BankingSystem
{
    public class Transaction
    {
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        public Transaction(string transactionType, decimal amount)
        {
            TransactionType = transactionType;
            Amount = amount;
            TransactionDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{TransactionType} of {Amount:N2} on {TransactionDate}";
        }
    }
}