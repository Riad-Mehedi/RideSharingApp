using System;

namespace RideSharing.Vehicles
{
    /// Factory class to create different types of vehicles
    /// Implements Factory Pattern
    public class VehicleFactory
    {
        /// Create a vehicle based type
        public static IVehicle CreateVehicle(string type)
        {
            switch (type.ToUpper())
            {
                case "BIKE":
                    return new Bike();
                case "CNG":
                    return new CNG();
                case "CAR":
                    return new Car();
                default:
                    throw new ArgumentException($"Unknown vehicle type: {type}");
            }
        }
    }
}