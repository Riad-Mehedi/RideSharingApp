using System;
using System.Collections.Generic;
using RideSharing.Rides;
using RideSharing.Payments;

namespace RideSharing.UI
{
    /// Handles all payment-related operations
    public static class PaymentOperations
    {
        public static void ProcessPayment(List<Ride> rides)
        {
            MenuDisplay.ShowHeader("PROCESS PAYMENT");

            if (rides.Count == 0)
            {
                MenuDisplay.ShowError("No rides available for payment.");
                return;
            }

            // Show completed rides
            var completedRides = rides.FindAll(r => r.Status == "Completed");

            if (completedRides.Count == 0)
            {
                MenuDisplay.ShowError("No completed rides available for payment.");
                return;
            }

            Console.WriteLine("\nCompleted Rides:");
            for (int i = 0; i < completedRides.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {completedRides[i].Id} - Fare: ${completedRides[i].CalculateFare():F2}");
            }

            Console.Write("\nSelect Ride for Payment (Enter number): ");
            int rideIndex = int.Parse(Console.ReadLine()) - 1;

            if (rideIndex < 0 || rideIndex >= completedRides.Count)
            {
                MenuDisplay.ShowError("Invalid selection!");
                return;
            }

            Ride selectedRide = completedRides[rideIndex];
            double fare = selectedRide.CalculateFare();

            Console.WriteLine($"\nRide: {selectedRide.Id}");
            Console.WriteLine($"Total Fare: ${fare:F2}");

            Console.WriteLine("\nSelect Payment Method:");
            Console.WriteLine("1. bKash");
            Console.WriteLine("2. Credit Card");
            Console.Write("Enter choice (1-2): ");
            string paymentChoice = Console.ReadLine();

            IPaymentProcessor paymentProcessor;
            string paymentInfo;

            if (paymentChoice == "1")
            {
                paymentProcessor = new BkashPaymentAdapter();
                Console.Write("Enter bKash Phone Number: ");
                paymentInfo = Console.ReadLine();
            }
            else
            {
                paymentProcessor = new CreditCardProcessor();
                Console.Write("Enter Credit Card Number: ");
                paymentInfo = Console.ReadLine();
            }

            Console.WriteLine($"\n Processing payment via {paymentProcessor.GetPaymentMethod()}...");
            bool paymentSuccess = paymentProcessor.Pay(paymentInfo, fare);

            if (paymentSuccess)
            {
                MenuDisplay.ShowSuccess($"Payment of ${fare:F2} completed successfully!");

                // Deduct from rider's wallet if applicable
                if (selectedRide.Rider.DeductFromWallet(fare))
                {
                    Console.WriteLine($"Amount deducted from {selectedRide.Rider.Name}'s wallet.");
                    Console.WriteLine($"Remaining balance: ${selectedRide.Rider.WalletBalance:F2}");
                }
            }
            else
            {
                MenuDisplay.ShowError("Payment failed!");
            }
        }
    }
}