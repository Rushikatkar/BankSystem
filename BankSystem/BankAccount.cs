using BankingSystem;
using System;
using System.Collections.Generic;

namespace BankingSystem
{
    internal class BankAccount
    {
        public int AccountId { get; private set; }
        public string HolderName { get; private set; }
        public decimal Balance { get; private set; }
        private List<Transaction> transactionHistory;

        public BankAccount(int accountId, string holderName, decimal initialDeposit)
        {
            AccountId = accountId;
            HolderName = holderName;
            Balance = initialDeposit;
            transactionHistory = new List<Transaction>();
            AddTransaction("Deposit", initialDeposit);
        }

        private void AddTransaction(string transactionType, decimal amount)
        {
            Transaction transaction = new Transaction(transactionType, amount);
            transactionHistory.Add(transaction);
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                AddTransaction("Deposit", amount);
                Console.WriteLine($"Successfully deposited {amount:N2}. New balance: {Balance:N2}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                AddTransaction("Withdrawal", amount);
                Console.WriteLine($"Successfully withdrew {amount:N2}. New balance: {Balance:N2}");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
            }
            else
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Account ID: {AccountId}, Holder: {HolderName}, Balance: {Balance:N2}");
        }

        public void ViewTransactionHistory()
        {
            Console.WriteLine($"Transaction history for Account ID: {AccountId}");
            foreach (var transaction in transactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}
