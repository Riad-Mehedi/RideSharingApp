# 🚗 Ride Sharing System 

A comprehensive C# console application implementing a ride-sharing platform similar to Uber or Pathao. This project demonstrates core Object-Oriented Programming principles and six essential Design Patterns.

## 📋 Table of Contents

- [Project Overview](#project-overview)
- [Design Patterns Implemented](#design-patterns-implemented)
- [Project Structure](#project-structure)
- [System Requirements](#system-requirements)
- [Installation & Setup](#installation--setup)
- [How to Run](#how-to-run)
- [Features](#features)
- [Design Pattern Details](#design-pattern-details)
- [OOP Principles](#oop-principles)
- [Usage Guide](#usage-guide)
- [Testing](#testing)

---

## 🎯 Project Overview

This Ride Sharing System is designed to manage riders, drivers, rides, and payments in a professional and scalable manner. The system allows:

- **User Management**: Register and manage riders and drivers
- **Vehicle Management**: Support for multiple vehicle types (Bike, CNG, Car)
- **Dynamic Pricing**: Different pricing strategies based on time and demand
- **Payment Processing**: Integration with multiple payment gateways
- **Real-time Notifications**: Status updates for riders and drivers

---

## 🏗️ Design Patterns Implemented

This project implements **6 major design patterns** as required:

### 1. **Factory Pattern** 
- **Purpose**: Create different vehicle types without exposing instantiation logic
- **Implementation**: `VehicleFactory` creates `Bike`, `CNG`, and `Car` objects
- **Location**: `Vehicles/VehicleFactory.cs`
- **Benefits**: 
  - Easy to add new vehicle types
  - Centralized vehicle creation
  - Loose coupling between client and concrete classes

### 2. **Singleton Pattern** 
- **Purpose**: Ensure only one instance of RideManager exists system-wide
- **Implementation**: `RideManager` with thread-safe double-check locking
- **Location**: `Management/RideManager.cs`
- **Benefits**:
  - Centralized driver registry
  - Global access point
  - Thread-safe implementation

### 3. **Strategy Pattern** 
- **Purpose**: Dynamic pricing calculation based on different strategies
- **Implementation**: `IPricingStrategy` with three concrete strategies
  - StandardPricing: $0.50/km
  - RushHourPricing: $1.00/km
  - MidnightPricing: $0.75/km
- **Location**: `Pricing/` folder
- **Benefits**:
  - Runtime algorithm switching
  - Easy to add new pricing models
  - Encapsulates pricing logic

### 4. **Adapter Pattern** 
- **Purpose**: Integrate external bKash payment gateway with our system
- **Implementation**: `BkashPaymentAdapter` adapts `BkashPaymentGateway` to `IPaymentProcessor`
- **Location**: `Payments/BkashPaymentAdapter.cs`
- **Benefits**:
  - Works with incompatible interfaces
  - No modification to existing BkashPaymentGateway
  - Flexible payment method integration

### 5. **Observer Pattern** 
- **Purpose**: Notify riders and drivers when ride status changes
- **Implementation**: `IRideObserver` with `RiderNotifier` (SMS) and `DriverNotifier` (App)
- **Location**: `Observers/` folder
- **Benefits**:
  - Loose coupling between Ride and Notifiers
  - Easy to add new notification types
  - Automatic updates on state change

### 6. **Inheritance & Polymorphism** 
- **Purpose**: Create user hierarchy with shared behavior
- **Implementation**: Abstract `User` class with `Rider` and `Driver` subclasses
- **Location**: `Users/` folder
- **Benefits**:
  - Code reusability
  - Polymorphic behavior
  - Clear IS-A relationships
---

## 📁 Project Structure
```
RideSharing/
│
├── README.md                           # Project documentation
├── Program.cs                          # Main entry point
├── RideSharing.csproj                  # Project configuration
│
├── Users/                              # User Management (Inheritance & Polymorphism)
│   ├── User.cs                         # Abstract base class
│   ├── Rider.cs                        # Rider with wallet balance
│   └── Driver.cs                       # Driver with vehicle and availability
│
├── Vehicles/                           # Vehicle Management (Factory Pattern)
│   ├── IVehicle.cs                     # Vehicle interface
│   ├── Bike.cs                         # Bike ($2 base fare)
│   ├── CNG.cs                          # CNG ($3 base fare)
│   ├── Car.cs                          # Car ($5 base fare)
│   └── VehicleFactory.cs               # Factory for creating vehicles
│
├── Management/                         # Driver Registry (Singleton Pattern)
│   └── RideManager.cs                  # Singleton driver manager
│
├── Rides/                              # Ride Management
│   └── Ride.cs                         # Ride entity with observers
│
├── Pricing/                            # Pricing Strategies (Strategy Pattern)
│   ├── IPricingStrategy.cs             # Strategy interface
│   ├── StandardPricing.cs              # Standard pricing ($0.50/km)
│   ├── RushHourPricing.cs              # Rush hour pricing ($1.00/km)
│   └── MidnightPricing.cs              # Midnight pricing ($0.75/km)
│
├── Payments/                           # Payment Processing (Adapter Pattern)
│   ├── IPaymentProcessor.cs            # Payment interface
│   ├── BkashPaymentGateway.cs          # External bKash gateway (locked)
│   ├── BkashPaymentAdapter.cs          # Adapter for bKash
│   └── CreditCardProcessor.cs          # Credit card processor
│
├── Observers/                          # Notification System (Observer Pattern)
│   ├── IRideObserver.cs                # Observer interface
│   ├── RiderNotifier.cs                # SMS notifications for riders
│   └── DriverNotifier.cs               # App notifications for drivers
│
└── UI/                                 # User Interface Operations
    ├── MenuDisplay.cs                  # Display and formatting logic
    ├── DriverOperations.cs             # Driver-related operations
    ├── RiderOperations.cs              # Rider-related operations
    ├── RideOperations.cs               # Ride-related operations
    └── PaymentOperations.cs            # Payment-related operations
```

**Total Files: 28 C# files**

---

## 💻 System Requirements

### Prerequisites
- **.NET SDK 6.0** or higher
- **Visual Studio Code** (recommended) or Visual Studio
- **Git Bash** or PowerShell (for terminal commands)

### Development Environment
- **Operating System**: Windows 10/11, macOS, or Linux
- **IDE**: Visual Studio Code with C# extension
- **Terminal**: Git Bash, PowerShell, or CMD

---

## 🚀 Installation & Setup

### Step 1: Clone or Download the Project
```bash
# If using Git
git clone <repository-url>

# Or download and extract the ZIP file
```

### Step 2: Navigate to Project Folder
```bash
cd RideSharing
```

### Step 3: Restore Dependencies
```bash
dotnet restore
```

### Step 4: Build the Project
```bash
dotnet build
```

You should see: **Build succeeded**

---

## ▶️ How to Run

### Method 1: Using Terminal
```bash
dotnet run
```

### Method 2: Using VS Code
1. Open the project in VS Code
2. Press `F5` to run in debug mode
3. Or press `Ctrl + F5` to run without debugging

### Method 3: Using Built Executable
```bash
dotnet build
cd bin/Debug/net6.0/
./RideSharing.exe    # Windows
./RideSharing        # macOS/Linux
```

---

## 🎮 Features

### 1. User Management
- ✅ Register Riders with wallet balance
- ✅ Register Drivers with vehicle assignment
- ✅ View all users
- ✅ Display user information polymorphically

### 2. Vehicle Management
- ✅ Three vehicle types: Bike ($2), CNG ($3), Car ($5)
- ✅ Factory-based vehicle creation
- ✅ Easy to extend with new vehicle types

### 3. Driver Management
- ✅ Centralized driver registry (Singleton)
- ✅ Filter drivers by vehicle type
- ✅ Track driver availability status
- ✅ Thread-safe operations

### 4. Ride Management
- ✅ Create rides with rider, driver, and distance
- ✅ Dynamic pricing strategy selection
- ✅ Ride status tracking: Requested → Accepted → In Progress → Completed
- ✅ Observer-based notifications

### 5. Pricing System
- ✅ Standard Pricing: $0.50 per km
- ✅ Rush Hour Pricing: $1.00 per km
- ✅ Midnight Pricing: $0.75 per km
- ✅ Runtime strategy switching

### 6. Payment Processing
- ✅ bKash payment integration (Adapter Pattern)
- ✅ Credit Card payment support
- ✅ Wallet deduction for riders
- ✅ Transaction tracking

### 7. Notification System
- ✅ SMS notifications for riders
- ✅ App notifications for drivers
- ✅ Automatic updates on status change
- ✅ Observable pattern implementation

---

## 🔍 Design Pattern Details

### Factory Pattern Implementation

**Problem:** Need to create different vehicle types without tight coupling

**Solution:** VehicleFactory centralizes object creation
```csharp
// Usage
IVehicle vehicle = VehicleFactory.CreateVehicle("Bike");
```

**Benefits:**
- Single point of vehicle creation
- Easy to add new vehicle types
- Client code doesn't need to know concrete classes

---

### Singleton Pattern Implementation

**Problem:** Need single centralized driver registry

**Solution:** RideManager with thread-safe singleton
```csharp
// Always returns the same instance
RideManager manager = RideManager.GetInstance();
```

**Benefits:**
- Only one instance exists
- Global access point
- Thread-safe with double-check locking

---

### Strategy Pattern Implementation

**Problem:** Need different pricing algorithms

**Solution:** IPricingStrategy with concrete implementations
```csharp
// Switch strategies at runtime
ride.SetPricingStrategy(new RushHourPricing());
double fare = ride.CalculateFare();
```

**Benefits:**
- Runtime algorithm selection
- Easy to add new strategies
- Encapsulated pricing logic

---

### Adapter Pattern Implementation

**Problem:** BkashPaymentGateway has incompatible interface

**Solution:** BkashPaymentAdapter bridges the gap
```csharp
// Works with IPaymentProcessor interface
IPaymentProcessor payment = new BkashPaymentAdapter();
payment.Pay(phoneNumber, amount);
```

**Benefits:**
- Integrates external APIs seamlessly
- No modification to BkashPaymentGateway
- Consistent payment interface

---

### Observer Pattern Implementation

**Problem:** Need to notify multiple parties on state change

**Solution:** IRideObserver with concrete notifiers
```csharp
// Add observers
ride.AddObserver(new RiderNotifier(rider));
ride.AddObserver(new DriverNotifier(driver));

// All observers notified automatically
ride.SetStatus("Accepted");
```

**Benefits:**
- Loose coupling
- Easy to add new observer types
- Automatic notifications

---

## 🎯 OOP Principles Demonstrated

### 1. Encapsulation
- Private fields with public properties
- Data hiding in classes
- Controlled access to object state

### 2. Inheritance
- User → Rider, Driver hierarchy
- Code reusability through base class
- IS-A relationships

### 3. Polymorphism
- Abstract methods in User class
- Different implementations in derived classes
- Runtime method binding

### 4. Abstraction
- Interfaces (IVehicle, IPricingStrategy, etc.)
- Abstract classes (User)
- Hide implementation details

### 5. SOLID Principles
- **S**ingle Responsibility: Each class has one job
- **O**pen/Closed: Easy to extend, closed for modification
- **L**iskov Substitution: Derived classes work as base
- **I**nterface Segregation: Focused interfaces
- **D**ependency Inversion: Depend on abstractions

---

## 📖 Usage Guide

### Example Workflow

#### 1. Register Drivers
```
Choose option: 1
Enter Driver ID: D001
Enter Driver Name: Ahmed Ali
Enter Phone Number: 01711111111
Select Vehicle Type: 1 (Bike)
✅ Driver registered successfully!
```

#### 2. Register Riders
```
Choose option: 2
Enter Rider ID: R001
Enter Rider Name: Sara Khan
Enter Phone Number: 01722222222
Enter Initial Wallet Balance: 500
✅ Rider registered successfully!
```

#### 3. Create Ride
```
Choose option: 6
Select Rider: 1 (Sara Khan)
Select Driver: 1 (Ahmed Ali - Bike)
Enter Distance: 10 km
Select Pricing Strategy: 2 (Rush Hour)

✅ Ride created successfully!
Fare: $12.00 ($2 base + $10 for 10km at $1/km)

[SMS to Sara Khan]: Ride RIDE0001 is now Requested
[App Notification to Ahmed Ali]: Ride RIDE0001 is now Requested
```

#### 4. Update Ride Status (Observer Pattern Demo)
```
Choose option: 7
Select Ride: 1 (RIDE0001)
Select New Status: 2 (Accepted)

[SMS to Sara Khan]: Ride RIDE0001 is now Accepted
[App Notification to Ahmed Ali]: Ride RIDE0001 is now Accepted
✅ Ride status updated!
```

#### 5. Process Payment (Adapter Pattern Demo)
```
Choose option: 9
Select Ride: 1 (RIDE0001 - $12.00)
Select Payment Method: 1 (bKash)
Enter bKash Phone Number: 01722222222

bKash: Sending $12.00 to 01722222222
bKash: TXN1234 successful
✅ Payment of $12.00 completed successfully!
```

---

## 🧪 Testing

### Test Cases

#### Test 1: Factory Pattern
- Create Bike, CNG, Car vehicles
- Verify correct base fares
- **Expected**: Different vehicle objects with correct fares

#### Test 2: Singleton Pattern
- Call `RideManager.GetInstance()` multiple times
- Compare instances
- **Expected**: Same instance returned

#### Test 3: Strategy Pattern
- Create ride with Standard pricing
- Switch to Rush Hour pricing
- Calculate fares
- **Expected**: Different fare calculations

#### Test 4: Adapter Pattern
- Process payment via bKash
- Process payment via Credit Card
- **Expected**: Both work through same interface

#### Test 5: Observer Pattern
- Update ride status
- Check console output
- **Expected**: Both rider and driver notified

#### Test 6: Inheritance & Polymorphism
- Call `DisplayInfo()` on Rider and Driver
- **Expected**: Different implementations execute

---

## 🎓 Learning Outcomes

This project demonstrates:

1. ✅ **Design Pattern Implementation**: All 6 patterns correctly applied
2. ✅ **OOP Mastery**: Encapsulation, Inheritance, Polymorphism, Abstraction
3. ✅ **Clean Code**: Proper organization and separation of concerns
4. ✅ **SOLID Principles**: Professional code architecture
5. ✅ **Real-World Application**: Practical ride-sharing system
6. ✅ **Scalability**: Easy to extend and maintain
