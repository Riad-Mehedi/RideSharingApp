using System;
using RideSharing.Users;

namespace RideSharing.Observers
{
    // Notifies riders via SMS about ride status changes
    public class RiderNotifier : IRideObserver
    {
        private readonly Rider _rider;

        public RiderNotifier(Rider rider)
        {
            _rider = rider;
        }

        public void Update(string rideId, string status)
        {
            Console.WriteLine($"\n[SMS to {_rider.Name} ({_rider.Phone})]: Ride {rideId} is now {status}");
        }
    }
}