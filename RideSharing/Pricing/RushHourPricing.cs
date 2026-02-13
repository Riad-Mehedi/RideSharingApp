namespace RideSharing.Pricing
{
    public class RushHourPricing : IPricingStrategy
    {
        private const double RatePerKm = 1.00;

        public double CalculateFare(double distance, double baseFare)
        {
            return baseFare + (distance * RatePerKm);
        }

        public string GetStrategyName()
        {
            return "Rush Hour Pricing";
        }
    }
}