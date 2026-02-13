using System;
using RideSharing.Vehicles;

namespace RideSharing.Users
{
    /// Driver class with vehicle and availability status
    public class Driver : User
    {
        public IVehicle Vehicle { get; private set; }
        public bool IsAvailable { get; set; }

        public Driver(string id, string name, string phone, IVehicle vehicle, bool isAvailable = true)
            : base(id, name, phone)
        {
            Vehicle = vehicle;
            IsAvailable = isAvailable;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("\n=== Driver Information ===");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Phone: {Phone}");
            Console.WriteLine($"Vehicle: {Vehicle.GetVehicleType()} (Base Fare: ${Vehicle.GetBaseFare():F2})");
            Console.WriteLine($"Available: {(IsAvailable ? "Yes" : "No")}");
            Console.WriteLine("--------------------------------");
        }

        public override string GetRole()
        {
            return "Driver";
        }
    }
}