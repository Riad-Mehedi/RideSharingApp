namespace RideSharing.Vehicles
{
    /// Car vehicle implementation
    public class Car : IVehicle
    {
        private const double BaseFare = 2.0;

        public string GetVehicleType()
        {
            return "Car";
        }

        public double GetBaseFare()
        {
            return BaseFare;
        }
    }
}