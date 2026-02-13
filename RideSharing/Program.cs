using System;
using System.Collections.Generic;
using RideSharing.Users;
using RideSharing.Management;
using RideSharing.Rides;
using RideSharing.UI;

namespace RideSharing
{
    class Program
    {
        private static RideManager rideManager = RideManager.GetInstance();
        private static List<Rider> riders = new List<Rider>();
        private static List<Ride> rides = new List<Ride>();
        private static int rideCounter = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║         RIDE SHARING SYSTEM            ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("\n Please register Drivers and Riders to begin.");

            bool exit = false;

            while (!exit)
            {
                MenuDisplay.ShowMainMenu();
                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        DriverOperations.RegisterDriver(rideManager);
                        break;

                    case "2":
                        RiderOperations.RegisterRider(riders);
                        break;

                    case "3":
                        DriverOperations.ViewAllDrivers(rideManager);
                        break;

                    case "4":
                        DriverOperations.ViewAvailableDriversByVehicle(rideManager);
                        break;

                    case "5":
                        RiderOperations.ViewAllRiders(riders);
                        break;

                    case "6":
                        RideOperations.CreateRide(riders, rideManager, rides, ref rideCounter);
                        break;

                    case "7":
                        RideOperations.UpdateRideStatus(rides);
                        break;

                    case "8":
                        RideOperations.ViewAllRides(rides);
                        break;

                    case "9":
                        PaymentOperations.ProcessPayment(rides);
                        break;

                    case "0":
                        exit = true;
                        MenuDisplay.ShowGoodbye();
                        break;

                    default:
                        MenuDisplay.ShowError("Invalid choice! Please try again.");
                        break;
                }

                if (!exit)
                {
                    MenuDisplay.PauseForUser();
                }
            }
        }
    }
}