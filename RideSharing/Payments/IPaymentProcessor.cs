namespace RideSharing.Payments
{
    // Payment processor interface for Adapter Pattern
    public interface IPaymentProcessor
    {
        // Process payment
        bool Pay(string paymentInfo, double amount);

        string GetPaymentMethod();
    }
}