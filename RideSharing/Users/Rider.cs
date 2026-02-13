using System;

namespace RideSharing.Users
{
    /// Rider class with wallet balance functionality
    public class Rider : User
    {
        public double WalletBalance { get; private set; }

        public Rider(string id, string name, string phone, double walletBalance = 0.0)
            : base(id, name, phone)
        {
            WalletBalance = walletBalance;
        }

        public void AddToWallet(double amount)
        {
            WalletBalance += amount;
            Console.WriteLine($"${amount:F2} added to wallet. New balance: ${WalletBalance:F2}");
        }

        public bool DeductFromWallet(double amount)
        {
            if (WalletBalance >= amount)
            {
                WalletBalance -= amount;
                return true;
            }
            return false;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("\n=== Rider Information ===");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Phone: {Phone}");
            Console.WriteLine($"Wallet Balance: ${WalletBalance:F2}");
            Console.WriteLine("--------------------------------");
        }

        public override string GetRole()
        {
            return "Rider";
        }
    }
}