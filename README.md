# Ride Sharing System (Uber/Pathao)

A console-based ride-sharing application built with C# demonstrating Object-Oriented Programming principles and Design Patterns.

---

## 📋 Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Design Patterns Used](#design-patterns-used)
- [Project Structure](#project-structure)
- [System Requirements](#system-requirements)
- [How to Run the Application](#how-to-run-the-application)
- [Usage Guide](#usage-guide)
- [Technologies Used](#technologies-used)

---

## 🎯 Project Overview

This Ride Sharing System is a comprehensive C# console application that simulates the core functionality of ride-sharing platforms like Uber and Pathao. The system allows users to register as drivers or riders, create rides with dynamic pricing strategies, process payments through multiple methods, and receive real-time notifications about ride status updates.

**Key Highlights:**
- Implements 6 major design patterns
- Follows SOLID principles
- Clean code architecture with separation of concerns
- Menu-driven interface for easy interaction

---

## ✨ Features

### User Management
- ✅ Register drivers with different vehicle types
- ✅ Register riders with wallet balance
- ✅ View all registered users
- ✅ Filter drivers by vehicle type and availability

### Ride Management
- ✅ Create rides with rider and driver selection
- ✅ Calculate fares using different pricing strategies
- ✅ Update ride status (Requested → Accepted → In Progress → Completed)
- ✅ View all rides and their details

### Payment Processing
- ✅ Support for multiple payment methods (bKash, Credit Card)
- ✅ Wallet-based transactions
- ✅ Payment confirmation and receipt

### Notifications
- ✅ SMS notifications for riders
- ✅ App notifications for drivers
- ✅ Real-time status updates

---

## 🏗️ Design Patterns Used

### 1. **Factory Pattern** 
**Location:** `Vehicles/VehicleFactory.cs`

**Purpose:** Creates different types of vehicles (Bike, CNG, Car) without exposing instantiation logic.

**Components:**
- `IVehicle.cs` - Interface
- `Bike.cs`, `CNG.cs`, `Car.cs` - Concrete implementations
- `VehicleFactory.cs` - Factory class with `CreateVehicle()` method

**Example:**
```csharp
IVehicle vehicle = VehicleFactory.CreateVehicle("Bike");
```

---

### 2. **Singleton Pattern**
**Location:** `Management/RideManager.cs`

**Purpose:** Ensures only one instance of RideManager exists throughout the application to manage all drivers centrally.

**Implementation:**
- Private constructor
- Private static instance with thread-safe double-check locking
- Public `GetInstance()` method

**Example:**
```csharp
RideManager manager = RideManager.GetInstance();
```

---

### 3. **Strategy Pattern**
**Location:** `Pricing/` folder

**Purpose:** Allows dynamic selection of pricing algorithms at runtime.

**Components:**
- `IPricingStrategy.cs` - Strategy interface
- `StandardPricing.cs` - $0.50 per km
- `RushHourPricing.cs` - $1.00 per km
- `MidnightPricing.cs` - $0.75 per km

**Example:**
```csharp
ride.SetPricingStrategy(new RushHourPricing());
double fare = ride.CalculateFare();
```

---

### 4. **Adapter Pattern**
**Location:** `Payments/BkashPaymentAdapter.cs`

**Purpose:** Adapts the incompatible `BkashPaymentGateway` interface to work with the `IPaymentProcessor` interface.

**Components:**
- `IPaymentProcessor.cs` - Target interface
- `BkashPaymentGateway.cs` - External service (Adaptee)
- `BkashPaymentAdapter.cs` - Adapter class
- `CreditCardProcessor.cs` - Direct implementation

**Example:**
```csharp
IPaymentProcessor payment = new BkashPaymentAdapter();
payment.Pay("01711111111", 100.00);
```

---

### 5. **Observer Pattern**
**Location:** `Observers/` folder

**Purpose:** Notifies multiple observers (Rider, Driver) when ride status changes.

**Components:**
- `IRideObserver.cs` - Observer interface
- `RiderNotifier.cs` - Sends SMS to riders
- `DriverNotifier.cs` - Sends app notifications to drivers

**Example:**
```csharp
ride.AddObserver(new RiderNotifier(rider));
ride.AddObserver(new DriverNotifier(driver));
ride.SetStatus("Accepted"); // Both get notified
```

---

### 6. **Inheritance & Polymorphism**
**Location:** `Users/` folder

**Purpose:** Provides a common base class for all users with specialized behavior in derived classes.

**Components:**
- `User.cs` - Abstract base class
- `Rider.cs` - Extends User with wallet functionality
- `Driver.cs` - Extends User with vehicle and availability

**Example:**
```csharp
User user = new Rider("R001", "Sara", "01711111111", 500.0);
user.DisplayInfo(); // Polymorphic call
```

---

## 📁 Project Structure

```
RideSharing/
│
├── Program.cs                          # Main entry point
├── RideSharing.csproj                  # Project configuration file
├── README.md                           # Project documentation
│
├── Users/                              # User Management (Inheritance & Polymorphism)
│   ├── User.cs                         # Abstract base class
│   ├── Rider.cs                        # Rider with wallet
│   └── Driver.cs                       # Driver with vehicle
│
├── Vehicles/                           # Vehicle Management (Factory Pattern)
│   ├── IVehicle.cs                     # Vehicle interface
│   ├── Bike.cs                         # Bike implementation ($2)
│   ├── CNG.cs                          # CNG implementation ($3)
│   ├── Car.cs                          # Car implementation ($5)
│   └── VehicleFactory.cs               # Factory for creating vehicles
│
├── Management/                         # Central Management (Singleton Pattern)
│   └── RideManager.cs                  # Singleton driver registry
│
├── Rides/                              # Ride Management
│   └── Ride.cs                         # Ride with Strategy & Observer patterns
│
├── Pricing/                            # Pricing Strategies (Strategy Pattern)
│   ├── IPricingStrategy.cs             # Strategy interface
│   ├── StandardPricing.cs              # Standard pricing ($0.50/km)
│   ├── RushHourPricing.cs              # Rush hour pricing ($1.00/km)
│   └── MidnightPricing.cs              # Midnight pricing ($0.75/km)
│
├── Payments/                           # Payment Processing (Adapter Pattern)
│   ├── IPaymentProcessor.cs            # Payment interface
│   ├── BkashPaymentGateway.cs          # External bKash service
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

---

## 💻 System Requirements

### Prerequisites

1. **.NET SDK** (Version 6.0 or higher)
   - Download from: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)

2. **Text Editor or IDE** (Choose one)
   - Visual Studio Code (Recommended)
   - Visual Studio 2022
   - JetBrains Rider

3. **Operating System**
   - Windows 10/11
   - macOS
   - Linux

---

## 🚀 How to Run the Application

### Method 1: Using Command Line / Terminal

#### Step 1: Navigate to Project Directory
```bash
cd RideSharing
```

#### Step 2: Restore Dependencies
```bash
dotnet restore
```

#### Step 3: Build the Project
```bash
dotnet build
```

#### Step 4: Run the Application
```bash
dotnet run
```

---

### Method 2: Using Visual Studio Code

#### Step 1: Open Project
1. Open VS Code
2. Click **File** → **Open Folder**
3. Select the `RideSharing` folder

#### Step 2: Open Terminal
- Press `` Ctrl + ` `` (backtick) or
- Go to **Terminal** → **New Terminal**

#### Step 3: Run Commands
```bash
dotnet restore
dotnet build
dotnet run
```

#### Alternative: Use F5 (Debug Mode)
1. Press `F5`
2. Select **C#** if prompted
3. Application will start

---

### Method 3: Using Visual Studio 2022

#### Step 1: Open Project
1. Open Visual Studio 2022
2. Click **Open a project or solution**
3. Select `RideSharing.csproj`

#### Step 2: Run Application
- Press `F5` or `Ctrl + F5`
- Or click the **green play button** (▶️)

---

## 📖 Usage Guide

### Starting the Application

When you run the application, you'll see:

```
╔════════════════════════════════════════╗
║   RIDE SHARING SYSTEM (Uber/Pathao)   ║
╚════════════════════════════════════════╝

Please register drivers and riders to begin.

╔════════════════════════════════════════╗
║            MAIN MENU                   ║
╚════════════════════════════════════════╝
1. Register Driver
2. Register Rider
3. View All Drivers
4. View Available Drivers by Vehicle Type
5. View All Riders
6. Create Ride
7. Update Ride Status
8. View All Rides
9. Process Payment
0. Exit

Enter your choice: 
```

---

### Step-by-Step Workflow

#### 1️⃣ **Register Drivers** (Option 1)

```
Enter your choice: 1

╔════════════════════════════════════════╗
║         REGISTER NEW DRIVER            ║
╚════════════════════════════════════════╝
Enter Driver ID: D001
Enter Driver Name: Ahmed Ali
Enter Phone Number: 01711111111

Select Vehicle Type:
1. Bike ($2 base fare)
2. CNG ($3 base fare)
3. Car ($5 base fare)
Enter choice (1-3): 1

✅ Driver registered successfully!
```

**Repeat** to register 2-3 drivers with different vehicle types.

---

#### 2️⃣ **Register Riders** (Option 2)

```
Enter your choice: 2

╔════════════════════════════════════════╗
║         REGISTER NEW RIDER             ║
╚════════════════════════════════════════╝
Enter Rider ID: R001
Enter Rider Name: Sara Khan
Enter Phone Number: 01744444444
Enter Initial Wallet Balance: $500

✅ Rider registered successfully!
```

**Repeat** to register 2-3 riders.

---

#### 3️⃣ **Create a Ride** (Option 6)

```
Enter your choice: 6

Available Riders:
1. Sara Khan (ID: R001)
Select Rider (enter number): 1

Available Drivers:
1. Ahmed Ali - Bike (ID: D001)
Select Driver (enter number): 1

Enter Distance (km): 10

Select Pricing Strategy:
1. Standard Pricing ($0.50/km)
2. Rush Hour Pricing ($1.00/km)
3. Midnight Pricing ($0.75/km)
Enter choice (1-3): 2

Pricing strategy set to: Rush Hour Pricing

=== Ride Information ===
Ride ID: RIDE0001
Rider: Sara Khan
Driver: Ahmed Ali
Vehicle: Bike
Distance: 10 km
Status: Requested
Pricing Strategy: Rush Hour Pricing
Fare: $12.00
=======================

[SMS to Sara Khan (01744444444)]: Ride RIDE0001 is now Requested
[App Notification to Ahmed Ali]: Ride RIDE0001 is now Requested

✅ Ride created successfully!
```

---

#### 4️⃣ **Update Ride Status** (Option 7) - **Observer Pattern Demo**

```
Enter your choice: 7

Active Rides:
1. RIDE0001 - Sara Khan to Ahmed Ali - Status: Requested

Select Ride (enter number): 1

Select New Status:
1. Requested
2. Accepted
3. In Progress
4. Completed
Enter choice (1-4): 2

[SMS to Sara Khan (01744444444)]: Ride RIDE0001 is now Accepted
[App Notification to Ahmed Ali]: Ride RIDE0001 is now Accepted

✅ Ride status updated to: Accepted
```

**Notice:** Both Rider and Driver receive notifications! (Observer Pattern)

---

#### 5️⃣ **Process Payment** (Option 9) - **Adapter Pattern Demo**

```
Enter your choice: 9

Completed Rides:
1. RIDE0001 - Fare: $12.00

Select Ride for Payment (enter number): 1

Ride: RIDE0001
Total Fare: $12.00

Select Payment Method:
1. bKash
2. Credit Card
Enter choice (1-2): 1

Enter bKash Phone Number: 01744444444

💳 Processing payment via bKash...
bKash: Sending $12 to 01744444444
TXN1234
bKash: TXN1234 successful

✅ Payment of $12.00 completed successfully!
Amount deducted from Sara Khan's wallet.
Remaining balance: $488.00
```

---

## 🛠️ Technologies Used

- **Language:** C# 10.0
- **Framework:** .NET 6.0
- **Architecture:** Layered Architecture
- **Design Patterns:** Factory, Singleton, Strategy, Adapter, Observer
- **Principles:** SOLID, DRY, Separation of Concerns

---

## 🎓 Learning Outcomes

This project demonstrates:

1. ✅ **Factory Pattern** - Centralized object creation
2. ✅ **Singleton Pattern** - Single instance management
3. ✅ **Strategy Pattern** - Runtime algorithm selection
4. ✅ **Adapter Pattern** - Interface compatibility
5. ✅ **Observer Pattern** - Event notification system
6. ✅ **Inheritance & Polymorphism** - Code reusability
7. ✅ **SOLID Principles** - Clean code architecture
8. ✅ **Separation of Concerns** - Organized code structure

---

## 📞 Troubleshooting

### Issue: "dotnet command not found"
**Solution:** 
- Install .NET SDK from [dotnet.microsoft.com](https://dotnet.microsoft.com/download)
- Restart terminal after installation

### Issue: Build errors
**Solution:**
```bash
dotnet clean
dotnet restore
dotnet build
```

### Issue: Can't see output
**Solution:**
- Make sure you're running `dotnet run` in the **RideSharing** folder
- Check that all `.cs` files are properly saved
