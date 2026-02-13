using System;

namespace RideSharing.Payments
{
    // Adapter to integrate BkashPaymentGateway with IPaymentProcessor
    public class BkashPaymentAdapter : IPaymentProcessor
    {
        private readonly BkashPaymentGateway _bkashGateway;

        public BkashPaymentAdapter()
        {
            _bkashGateway = new BkashPaymentGateway();
        }

        public bool Pay(string paymentInfo, double amount)
        {
            try
            {
                // paymentInfo contains the phone number for bKash
                string transactionId = _bkashGateway.SendMoney(paymentInfo, amount);
                bool status = _bkashGateway.CheckStatus(transactionId);
                
                if (status)
                {
                    Console.WriteLine($"Payment of ${amount:F2} successful via bKash!");
                }
                
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"bKash payment failed: {ex.Message}");
                return false;
            }
        }

        public string GetPaymentMethod()
        {
            return "bKash";
        }
    }
}