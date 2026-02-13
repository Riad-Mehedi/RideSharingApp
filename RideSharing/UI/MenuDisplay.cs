using System;

namespace RideSharing.UI
{
    public static class MenuDisplay
    {
        public static void ShowMainMenu()
        {
            Console.WriteLine("\n\n╔════════════════════════════════════════╗");
            Console.WriteLine("║            MAIN MENU                   ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("1. Register Driver");
            Console.WriteLine("2. Register Rider");
            Console.WriteLine("3. View All Drivers");
            Console.WriteLine("4. View Available Drivers by Vehicle Type");
            Console.WriteLine("5. View All Riders");
            Console.WriteLine("6. Create Ride");
            Console.WriteLine("7. Update Ride Status");
            Console.WriteLine("8. View All Rides");
            Console.WriteLine("9. Process Payment");
            Console.WriteLine("0. Exit");
            Console.Write("\nEnter your choice: ");
        }

        public static void ShowHeader(string title)
        {
           Console.WriteLine($"\n\n╔════════════════════════════════════════╗");
           Console.WriteLine($"║ {title.PadRight(38)} ║");
           Console.WriteLine("╚════════════════════════════════════════╝");
        }

        public static void ShowSuccess(string message)
        {
            Console.WriteLine($"\n✅ {message}");
        }

        public static void ShowError(string message)
        {
            Console.WriteLine($"\n❌ {message}");
        }

        public static void ShowInfo(string message)
        {
            Console.WriteLine($"\n {message}");
        }

        public static void PauseForUser()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static void ShowGoodbye()
        {
            Console.WriteLine("\nThank you for using Ride Sharing System!");
        }
    }
}