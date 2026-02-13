using System;
using RideSharing.Users;

namespace RideSharing.Observers
{
    // Notifies drivers via App about ride status changes
    public class DriverNotifier : IRideObserver
    {
        private readonly Driver _driver;

        public DriverNotifier(Driver driver)
        {
            _driver = driver;
        }

        public void Update(string rideId, string status)
        {
            Console.WriteLine($"\n[App Notification to {_driver.Name}]: Ride {rideId} is now {status}");
        }
    }
}