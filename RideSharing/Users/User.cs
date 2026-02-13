using System;

namespace RideSharing.Users
{
    /// Demonstrates Inheritance & Polymorphism
    public abstract class User
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public string Phone { get; protected set; }

        protected User(string id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }
        /// Abstract method to display user information
        public abstract void DisplayInfo();
        /// Abstract method to get user role
        public abstract string GetRole();
    }
}