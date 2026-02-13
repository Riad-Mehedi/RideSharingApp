using System;
using RideSharing.Users;
using RideSharing.Vehicles;
using RideSharing.Management;

namespace RideSharing.UI
{
    /// <summary>
    /// Handles all driver-related operations
    /// </summary>
    public static class DriverOperations
    {
        public static void RegisterDriver(RideManager rideManager)
        {
            MenuDisplay.ShowHeader("REGISTER NEW DRIVER");

            Console.Write("Enter Driver ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter Driver Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Console.WriteLine("\nSelect Vehicle Type:");
            Console.WriteLine("1. Bike ($2 base fare)");
            Console.WriteLine("2. CNG ($3 base fare)");
            Console.WriteLine("3. Car ($5 base fare)");
            Console.Write("Enter choice (1-3): ");
            string vehicleChoice = Console.ReadLine();

            string vehicleType = vehicleChoice switch
            {
                "1" => "Bike",
                "2" => "CNG",
                "3" => "Car",
                _ => "Bike"
            };

            try
            {
                IVehicle vehicle = VehicleFactory.CreateVehicle(vehicleType);
                Driver driver = new Driver(id, name, phone, vehicle, true);
                rideManager.RegisterDriver(driver);
                MenuDisplay.ShowSuccess("Driver registered successfully!");
            }
            catch (Exception ex)
            {
                MenuDisplay.ShowError($"Error: {ex.Message}");
            }
        }

        public static void ViewAllDrivers(RideManager rideManager)
        {
            rideManager.DisplayAllDrivers();
        }

        public static void ViewAvailableDriversByVehicle(RideManager rideManager)
        {
            Console.WriteLine("\n\nSelect Vehicle Type to Filter:");
            Console.WriteLine("1. All");
            Console.WriteLine("2. Bike");
            Console.WriteLine("3. CNG");
            Console.WriteLine("4. Car");
            Console.Write("Enter choice (1-4): ");
            string choice = Console.ReadLine();

            string vehicleType = choice switch
            {
                "2" => "Bike",
                "3" => "CNG",
                "4" => "Car",
                _ => null
            };

            rideManager.DisplayAvailableDrivers(vehicleType);
        }
    }
}