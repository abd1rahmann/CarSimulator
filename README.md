# 🚗 Car Simulator

This project is an object-oriented C# console application that simulates a car driver operating a vehicle under various conditions. The project is divided into two parts: a **console application** and a **services library**, following clean architecture principles such as SRP, DI, and interface-based development.

📍 **GitHub Repository:** [CarSimulator](https://github.com/abd1rahmann/CarSimulator)

---

## 🛠 Technologies & Tools

- C# (.NET 6 / .NET Core)
- Object-Oriented Programming (OOP)
- MSTest (Unit Testing)
- Moq (Dependency mocking)
- SRP (Single Responsibility Principle)
- Dependency Injection
- Interface-based Architecture
- Multi-project structure (Console + Services library)

---

## 🚀 Functionality Overview

### 👨‍✈️ Driver
- Has a fatigue level that increases when driving or refueling.
- Can take a break to reduce fatigue.
- Displays warnings when fatigue gets high, and critical messages at max level.

### 🚘 Car
- Has a fuel level that decreases when driving.
- Can move forward, backward, and turn left/right.
- Must be refueled when the tank is empty.
- Maintains a direction: North, East, South, or West.

### 🧭 Available Commands


---

## 📦 Project Structure

CarSimulator/
│
├── Bilsimulator/ # Console application
│ ├── Program.cs
│ ├── Menu.cs
│ ├── Car.cs
│ └── Driver.cs
│
├── Services/ # Logic services library
│ ├── CarServices/
│ │ ├── ICarService.cs
│ │ └── CarService.cs
│ └── DriverServices/
│ ├── IDriverService.cs
│ └── DriverService.cs
│
├── Bilsimulator.Tests/ # MSTest project
│ ├── MenuTests.cs
│ ├── CarServiceTests.cs
│ └── DriverServiceTests.cs

yaml
Kopiera

---

## ✅ Unit Testing

The project includes thorough unit tests using MSTest and Moq to ensure quality and maintainability:

### Sample test cases:
- Fatigue increases appropriately while driving.
- Direction updates correctly after turning.
- Fuel is correctly consumed and refilled.
- Invalid menu inputs are handled properly.
- Console interactions are mocked and verified.

> ✅ **All tests pass** and are isolated from the console UI using an `IConsole` abstraction.

---

## 📥 Getting Started

1. **Clone the repository:**
   git clone https://github.com/abd1rahmann/CarSimulator.git

   cd CarSimulator/Bilsimulator
dotnet run

---

## Run tests
dotnet test
