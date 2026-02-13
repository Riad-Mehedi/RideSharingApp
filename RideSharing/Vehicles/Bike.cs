namespace RideSharing.Vehicles
{
    /// Bike vehicle implementation
    public class Bike : IVehicle
    {
        private const double BaseFare = 1.0;

        public string GetVehicleType()
        {
            return "Bike";
        }

        public double GetBaseFare()
        {
            return BaseFare;
        }
    }
}