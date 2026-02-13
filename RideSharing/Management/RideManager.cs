using System;
using System.Collections.Generic;
using System.Linq;
using RideSharing.Users;

namespace RideSharing.Management
{
    // Implements Singleton Pattern
    public class RideManager
    {
        // Singleton instance
        private static RideManager _instance;
        private static readonly object _lock = new object();

        // List to store all registered drivers
        private List<Driver> _drivers;

        private RideManager()
        {
            _drivers = new List<Driver>();
        }

        // Get the singleton instance of RideManager
        // Thread-safe implementation
        public static RideManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new RideManager();
                    }
                }
            }
            return _instance;
        }

        // Register a new driver
        public void RegisterDriver(Driver driver)
        {
            _drivers.Add(driver);
            Console.WriteLine($"\nDriver {driver.Name} registered successfully with {driver.Vehicle.GetVehicleType()}!");
        }

        // Get all registered drivers
        public List<Driver> GetAllDrivers()
        {
            return new List<Driver>(_drivers);
        }

        // Get available drivers filtered by vehicle type
        public List<Driver> GetAvailableDrivers(string vehicleType = null)
        {
            var availableDrivers = _drivers.Where(d => d.IsAvailable);

            if (!string.IsNullOrEmpty(vehicleType))
            {
                availableDrivers = availableDrivers.Where(d => 
                    d.Vehicle.GetVehicleType().Equals(vehicleType, StringComparison.OrdinalIgnoreCase));
            }

            return availableDrivers.ToList();
        }

        // Display all drivers
        public void DisplayAllDrivers()
        {
            Console.WriteLine("\n========== All Registered Drivers ==========");
            if (_drivers.Count == 0)
            {
                Console.WriteLine("No drivers registered yet.");
            }
            else
            {
                foreach (var driver in _drivers)
                {
                    driver.DisplayInfo();
                }
            }
            Console.WriteLine("----------------------------------");
        }

        // Display available drivers by vehicle type
        public void DisplayAvailableDrivers(string vehicleType = null)
        {
            var drivers = GetAvailableDrivers(vehicleType);
            
            string title = string.IsNullOrEmpty(vehicleType) 
                ? "All Available Drivers" 
                : $"Available {vehicleType} Drivers";
            
            Console.WriteLine($"\n========== {title} ==========");
            if (drivers.Count == 0)
            {
                Console.WriteLine($"No available drivers{(string.IsNullOrEmpty(vehicleType) ? "" : $" with {vehicleType}")}.");
            }
            else
            {
                foreach (var driver in drivers)
                {
                    driver.DisplayInfo();
                }
            }
            Console.WriteLine("----------------------------------");
        }
    }
}