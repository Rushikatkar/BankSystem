using System;
using System.Collections.Generic;
using System.Globalization;

namespace BankingSystem
{
    class Account
    {
        public int AccountId { get; set; }
        public string HolderName { get; set; }
        public decimal Balance { get; set; }
        public List<string> TransactionHistory { get; set; } = new List<string>();
    }

    class Program
    {
        static Dictionary<int, Account> accounts = new Dictionary<int, Account>();
        static int nextAccountId = 1;

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- Banking System Main Menu ---");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Check Account Balance");
                Console.WriteLine("5. View Account Details");
                Console.WriteLine("6. View Transaction History");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        DepositMoney();
                        break;
                    case "3":
                        WithdrawMoney();
                        break;
                    case "4":
                        CheckAccountBalance();
                        break;
                    case "5":
                        ViewAccountDetails();
                        break;
                    case "6":
                        ViewTransactionHistory();
                        break;
                    case "7":
                        Console.Write("Are you sure you want to exit? (Y/N): ");
                        string confirm = Console.ReadLine()?.Trim().ToUpper();
                        if (confirm == "Y")
                            running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreateAccount()
        {
            Console.Write("Enter account holder name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || !IsNameValid(name))
            {
                Console.WriteLine("Invalid name. Name should only contain letters and spaces.");
                return;
            }

            Console.Write("Enter initial deposit: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal initialDeposit) || initialDeposit <= 0)
            {
                Console.WriteLine("Invalid amount. Initial deposit must be a positive number.");
                return;
            }

            var account = new Account
            {
                AccountId = nextAccountId++,
                HolderName = name,
                Balance = initialDeposit
            };
            accounts[account.AccountId] = account;

            Console.WriteLine($"Account created successfully! Account ID: {account.AccountId}");
        }

        static void DepositMoney()
        {
            Console.Write("Enter account ID: ");
            if (!int.TryParse(Console.ReadLine(), out int accountId) || !accounts.ContainsKey(accountId))
            {
                Console.WriteLine("Invalid account ID.");
                return;
            }

            Console.Write("Enter deposit amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount. Deposit must be positive.");
                return;
            }

            accounts[accountId].Balance += amount;
            accounts[accountId].TransactionHistory.Add(
                $"Deposited {amount:F2} on {DateTime.Now.ToString("g", CultureInfo.InvariantCulture)}"
            );
            Console.WriteLine("Deposit successful!");
        }

        static void WithdrawMoney()
        {
            Console.Write("Enter account ID: ");
            if (!int.TryParse(Console.ReadLine(), out int accountId) || !accounts.ContainsKey(accountId))
            {
                Console.WriteLine("Invalid account ID.");
                return;
            }

            Console.Write("Enter withdrawal amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount. Withdrawal must be positive.");
                return;
            }

            if (amount > accounts[accountId].Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            accounts[accountId].Balance -= amount;
            accounts[accountId].TransactionHistory.Add(
                $"Withdrew {amount:F2} on {DateTime.Now.ToString("g", CultureInfo.InvariantCulture)}"
            );
            Console.WriteLine("Withdrawal successful!");
        }

        static void CheckAccountBalance()
        {
            Console.Write("Enter account ID: ");
            if (!int.TryParse(Console.ReadLine(), out int accountId) || !accounts.ContainsKey(accountId))
            {
                Console.WriteLine("Invalid account ID.");
                return;
            }

            Console.WriteLine($"Current balance: {accounts[accountId].Balance:F2}");
        }

        static void ViewAccountDetails()
        {
            Console.Write("Enter account ID: ");
            if (!int.TryParse(Console.ReadLine(), out int accountId) || !accounts.ContainsKey(accountId))
            {
                Console.WriteLine("Invalid account ID.");
                return;
            }

            var account = accounts[accountId];
            Console.WriteLine("\n--- Account Details ---");
            Console.WriteLine($"Account ID: {account.AccountId}");
            Console.WriteLine($"Holder Name: {account.HolderName}");
            Console.WriteLine($"Balance: {account.Balance:F2}");
        }

        static void ViewTransactionHistory()
        {
            Console.Write("Enter account ID: ");
            if (!int.TryParse(Console.ReadLine(), out int accountId) || !accounts.ContainsKey(accountId))
            {
                Console.WriteLine("Invalid account ID.");
                return;
            }

            var transactions = accounts[accountId].TransactionHistory;
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions available.");
                return;
            }

            Console.WriteLine("\n--- Transaction History ---");
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        static bool IsNameValid(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    return false;
            }
            return true;
        }
    }
}
