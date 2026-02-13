using System;
using System.Collections.Generic;
using RideSharing.Users;
using RideSharing.Pricing;
using RideSharing.Observers;

namespace RideSharing.Rides
{
    /// Represents a ride with observer and strategy patterns
    public class Ride
    {
        public string Id { get; private set; }
        public Rider Rider { get; private set; }
        public Driver Driver { get; private set; }
        public double Distance { get; private set; }
        public string Status { get; private set; }
        
        private IPricingStrategy _pricingStrategy;
        private List<IRideObserver> _observers;

        public Ride(string id, Rider rider, Driver driver, double distance)
        {
            Id = id;
            Rider = rider;
            Driver = driver;
            Distance = distance;
            Status = "Requested";
            _observers = new List<IRideObserver>();
            _pricingStrategy = new StandardPricing(); // Default strategy
        }

        /// Set the pricing strategy
        public void SetPricingStrategy(IPricingStrategy strategy)
        {
            _pricingStrategy = strategy;
            Console.WriteLine($"\nPricing strategy set to: {_pricingStrategy.GetStrategyName()}");
        }

        /// Calculate fare
        public double CalculateFare()
        {
            double baseFare = Driver.Vehicle.GetBaseFare();
            double fare = _pricingStrategy.CalculateFare(Distance, baseFare);
            return fare;
        }

        /// Add observer
        public void AddObserver(IRideObserver observer)
        {
            _observers.Add(observer);
        }

        /// Set ride status and notify all observers
        public void SetStatus(string newStatus)
        {
            Status = newStatus;
            NotifyObservers();
        }

        /// Notify all observers about status change
        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(Id, Status);
            }
        }

        /// Display ride information
        public void DisplayRideInfo()
        {
            Console.WriteLine("\n=== Ride Information ===");
            Console.WriteLine($"Ride ID: {Id}");
            Console.WriteLine($"Rider: {Rider.Name}");
            Console.WriteLine($"Driver: {Driver.Name}");
            Console.WriteLine($"Vehicle: {Driver.Vehicle.GetVehicleType()}");
            Console.WriteLine($"Distance: {Distance} km");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Pricing Strategy: {_pricingStrategy.GetStrategyName()}");
            Console.WriteLine($"Fare: ${CalculateFare():F2}");
            Console.WriteLine("------------------------------");
        }
    }
}