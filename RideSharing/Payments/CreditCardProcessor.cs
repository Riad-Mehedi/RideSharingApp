using System;

namespace RideSharing.Payments
{
    public class CreditCardProcessor : IPaymentProcessor
    {
        public bool Pay(string paymentInfo, double amount)
        {
            try
            {
                // paymentInfo contains credit card number
                Console.WriteLine($"Processing credit card payment...");
                Console.WriteLine($"Card: ****-****-****-{paymentInfo.Substring(Math.Max(0, paymentInfo.Length - 4))}");
                Console.WriteLine($"Amount: ${amount:F2}");
                Console.WriteLine("Payment successful!");
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Credit card payment failed: {ex.Message}");
                return false;
            }
        }

        public string GetPaymentMethod()
        {
            return "Credit Card";
        }
    }
}