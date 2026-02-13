using System;
using System.Collections.Generic;
using RideSharing.Users;
using RideSharing.Management;
using RideSharing.Rides;
using RideSharing.Pricing;
using RideSharing.Observers;

namespace RideSharing.UI
{
    /// Handles all ride-related operations
    public static class RideOperations
    {
        public static void CreateRide(List<Rider> riders, RideManager rideManager, 
                                     List<Ride> rides, ref int rideCounter)
        {
            MenuDisplay.ShowHeader("CREATE NEW RIDE");

            // Select Rider
            if (riders.Count == 0)
            {
                MenuDisplay.ShowError("No riders available. Please register a rider first.");
                return;
            }

            Console.WriteLine("\nAvailable Riders:");
            for (int i = 0; i < riders.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {riders[i].Name} (ID: {riders[i].Id})");
            }
            Console.Write("Select Rider (enter number): ");
            int riderIndex = int.Parse(Console.ReadLine()) - 1;

            if (riderIndex < 0 || riderIndex >= riders.Count)
            {
                MenuDisplay.ShowError("Invalid selection!");
                return;
            }

            Rider selectedRider = riders[riderIndex];

            // Select Driver
            var availableDrivers = rideManager.GetAvailableDrivers();
            if (availableDrivers.Count == 0)
            {
                MenuDisplay.ShowError("No drivers available at the moment.");
                return;
            }

            Console.WriteLine("\nAvailable Drivers:");
            for (int i = 0; i < availableDrivers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableDrivers[i].Name} - {availableDrivers[i].Vehicle.GetVehicleType()} (ID: {availableDrivers[i].Id})");
            }
            Console.Write("Select Driver (enter number): ");
            int driverIndex = int.Parse(Console.ReadLine()) - 1;

            if (driverIndex < 0 || driverIndex >= availableDrivers.Count)
            {
                MenuDisplay.ShowError("Invalid selection!");
                return;
            }

            Driver selectedDriver = availableDrivers[driverIndex];

            // Enter Distance
            Console.Write("\nEnter Distance (km): ");
            double distance = double.Parse(Console.ReadLine());

            // Create Ride
            string rideId = $"RIDE{rideCounter:D4}";
            rideCounter++;

            Ride ride = new Ride(rideId, selectedRider, selectedDriver, distance);

            // Add observers
            ride.AddObserver(new RiderNotifier(selectedRider));
            ride.AddObserver(new DriverNotifier(selectedDriver));

            // Select Pricing Strategy
            Console.WriteLine("\nSelect Pricing Strategy:");
            Console.WriteLine("1. Standard Pricing ($0.50/km)");
            Console.WriteLine("2. Rush Hour Pricing ($1.00/km)");
            Console.WriteLine("3. Midnight Pricing ($0.75/km)");
            Console.Write("Enter choice (1-3): ");
            string pricingChoice = Console.ReadLine();

            IPricingStrategy strategy = pricingChoice switch
            {
                "2" => new RushHourPricing(),
                "3" => new MidnightPricing(),
                _ => new StandardPricing()
            };

            ride.SetPricingStrategy(strategy);

            // Mark driver as unavailable
            selectedDriver.IsAvailable = false;

            rides.Add(ride);

            ride.DisplayRideInfo();
            MenuDisplay.ShowSuccess("Ride created successfully!");
        }

        public static void UpdateRideStatus(List<Ride> rides)
        {
            MenuDisplay.ShowHeader("UPDATE RIDE STATUS");

            if (rides.Count == 0)
            {
                MenuDisplay.ShowError("No rides available.");
                return;
            }

            Console.WriteLine("\nActive Rides:");
            for (int i = 0; i < rides.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {rides[i].Id} - {rides[i].Rider.Name} to {rides[i].Driver.Name} - Status: {rides[i].Status}");
            }

            Console.Write("\nSelect Ride (enter number): ");
            int rideIndex = int.Parse(Console.ReadLine()) - 1;

            if (rideIndex < 0 || rideIndex >= rides.Count)
            {
                MenuDisplay.ShowError("Invalid selection!");
                return;
            }

            Ride selectedRide = rides[rideIndex];

            Console.WriteLine("\nSelect New Status:");
            Console.WriteLine("1. Requested");
            Console.WriteLine("2. Accepted");
            Console.WriteLine("3. In Progress");
            Console.WriteLine("4. Completed");
            Console.Write("Enter choice (1-4): ");
            string statusChoice = Console.ReadLine();

            string newStatus = statusChoice switch
            {
                "1" => "Requested",
                "2" => "Accepted",
                "3" => "In Progress",
                "4" => "Completed",
                _ => selectedRide.Status
            };

            selectedRide.SetStatus(newStatus);

            // If ride completed, make driver available again
            if (newStatus == "Completed")
            {
                selectedRide.Driver.IsAvailable = true;
                Console.WriteLine($"\n✅ Driver {selectedRide.Driver.Name} is now available for new rides.");
            }

            MenuDisplay.ShowSuccess($"Ride status updated to: {newStatus}");
        }

        public static void ViewAllRides(List<Ride> rides)
        {
            Console.WriteLine("\n========== All Rides ==========");
            if (rides.Count == 0)
            {
                Console.WriteLine("No rides created yet.");
            }
            else
            {
                foreach (var ride in rides)
                {
                    ride.DisplayRideInfo();
                }
            }
            Console.WriteLine("----------------------------------");
        }
    }
}