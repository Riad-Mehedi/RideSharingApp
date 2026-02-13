namespace RideSharing.Pricing
{
    public class StandardPricing : IPricingStrategy
    {
        private const double RatePerKm = 0.50;

        public double CalculateFare(double distance, double baseFare)
        {
            return baseFare + (distance * RatePerKm);
        }

        public string GetStrategyName()
        {
            return "Standard Pricing";
        }
    }
}