namespace RideSharing.Vehicles
{
    /// CNG vehicle implementation
    public class CNG : IVehicle
    {
        private const double BaseFare = 1.5;

        public string GetVehicleType()
        {
            return "CNG";
        }

        public double GetBaseFare()
        {
            return BaseFare;
        }
    }
}