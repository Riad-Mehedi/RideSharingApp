namespace RideSharing.Observers
{
    // Observer interface for ride status updates
    // Implements Observer Pattern
    public interface IRideObserver
    {
        // Update method called when ride status changes
        void Update(string rideId, string status);
    }
}