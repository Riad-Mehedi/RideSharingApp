namespace RideSharing.Vehicles
{
    /// Vehicle interface for Factory Pattern
    public interface IVehicle
    {
        string GetVehicleType();
        double GetBaseFare();
    }
}