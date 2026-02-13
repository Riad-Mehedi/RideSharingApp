namespace RideSharing.Pricing
{
    public class MidnightPricing : IPricingStrategy
    {
        private const double RatePerKm = 0.75;

        public double CalculateFare(double distance, double baseFare)
        {
            return baseFare + (distance * RatePerKm);
        }

        public string GetStrategyName()
        {
            return "Midnight Pricing";
        }
    }
}