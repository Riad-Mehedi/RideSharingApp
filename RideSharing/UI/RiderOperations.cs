using System;
using System.Collections.Generic;
using RideSharing.Users;

namespace RideSharing.UI
{
    /// Handles all rider-related operations
    public static class RiderOperations
    {
        public static void RegisterRider(List<Rider> riders)
        {
            MenuDisplay.ShowHeader("REGISTER NEW RIDER");

            Console.Write("Enter Rider ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter Rider Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Initial Wallet Balance: $");
            double balance = double.Parse(Console.ReadLine());

            Rider rider = new Rider(id, name, phone, balance);
            riders.Add(rider);
            MenuDisplay.ShowSuccess("Rider registered successfully!");
        }

        public static void ViewAllRiders(List<Rider> riders)
        {
            Console.WriteLine("\n========== All Registered Riders ==========");
            if (riders.Count == 0)
            {
                Console.WriteLine("No riders registered yet.");
            }
            else
            {
                foreach (var rider in riders)
                {
                    rider.DisplayInfo();
                }
            }
            Console.WriteLine("----------------------------------");
        }
    }
}