namespace RideSharing.Pricing
{
    public interface IPricingStrategy
    {
        double CalculateFare(double distance, double baseFare);

        /// Get the name of the pricing strategy
        string GetStrategyName();
    }
}