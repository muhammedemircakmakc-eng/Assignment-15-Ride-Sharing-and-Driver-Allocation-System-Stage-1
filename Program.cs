using System;
using System.Collections.Generic;

namespace RideSharingSystem
{
    
    public class Vehicle
    {
        public string VehicleId { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int SeatCapacity { get; set; }

        public Vehicle(string vehicleId, string model, string licensePlate, int seatCapacity)
        {
            VehicleId = vehicleId;
            Model = model;
            LicensePlate = licensePlate;
            SeatCapacity = seatCapacity;
        }

        public override string ToString()
        {
            return $"{Model} (Plate: {LicensePlate}, Seats: {SeatCapacity})";
        }
    }

    
    public class Driver
    {
        public string DriverId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsAvailable { get; set; }
        public Vehicle AssignedVehicle { get; set; } 

        public Driver(string driverId, string name, string phone, Vehicle assignedVehicle)
        {
            DriverId = driverId;
            Name = name;
            Phone = phone;
            IsAvailable = true;
            AssignedVehicle = assignedVehicle;
        }

        public void UpdateAvailability(bool status)
        {
            IsAvailable = status;
        }

        public override string ToString()
        {
            return $"Driver: {Name}, Available: {IsAvailable}, Vehicle: {AssignedVehicle}";
        }
    }

    
    public class Passenger
    {
        public string PassengerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public double Rating { get; set; }

        public Passenger(string passengerId, string name, string phone, double rating = 5.0)
        {
            PassengerId = passengerId;
            Name = name;
            Phone = phone;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"Passenger: {Name} (Rating: {Rating})";
        }
    }

    
    public class RideRequest
    {
        public string RequestId { get; set; }
        public Passenger Requester { get; set; }
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public DateTime RequestTime { get; set; }
        public string Status { get; set; } 

        public RideRequest(string requestId, Passenger requester, string pickupLocation, string dropoffLocation)
        {
            RequestId = requestId;
            Requester = requester;
            PickupLocation = pickupLocation;
            DropoffLocation = dropoffLocation;
            RequestTime = DateTime.Now;
            Status = "Pending";
        }

        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
        }

        public override string ToString()
        {
            return $"Request {RequestId}: {Requester.Name} from {PickupLocation} to {DropoffLocation} [{Status}]";
        }
    }

    
    public class RideService
    {
        private List<Driver> _drivers;
        private List<Passenger> _passengers;
        private List<RideRequest> _requests;

        public RideService()
        {
            _drivers = new List<Driver>();
            _passengers = new List<Passenger>();
            _requests = new List<RideRequest>();
        }

        public void RegisterDriver(Driver driver)
        {
            _drivers.Add(driver);
            Console.WriteLine($"[Service] Driver registered: {driver.Name}");
        }

        public void RegisterPassenger(Passenger passenger)
        {
            _passengers.Add(passenger);
            Console.WriteLine($"[Service] Passenger registered: {passenger.Name}");
        }

        public RideRequest CreateRideRequest(Passenger passenger, string pickup, string dropoff)
        {
            string requestId = "REQ-" + (_requests.Count + 101);
            RideRequest request = new RideRequest(requestId, passenger, pickup, dropoff);
            _requests.Add(request);
            Console.WriteLine($"[Service] Ride request created: {request}");
            return request;
        }

        public void ListDrivers()
        {
            Console.WriteLine("\n--- Registered Drivers ---");
            foreach (var driver in _drivers)
            {
                Console.WriteLine(driver);
            }
        }

        public void ListPassengers()
        {
            Console.WriteLine("\n--- Registered Passengers ---");
            foreach (var passenger in _passengers)
            {
                Console.WriteLine(passenger);
            }
        }

        public void ListRequests()
        {
            Console.WriteLine("\n--- Ride Requests ---");
            foreach (var req in _requests)
            {
                Console.WriteLine(req);
            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Istanbul Esenyurt University - Object Based Programming ===");
            Console.WriteLine("=== Assignment 15: Ride-Sharing and Driver Allocation System ===");
            Console.WriteLine("=== Stage 1: Architecture Design Demonstration ===\n");

            
            RideService rideService = new RideService();

            
            Vehicle v1 = new Vehicle("V01", "Toyota Corolla", "34ABC123", 4);
            Vehicle v2 = new Vehicle("V02", "Honda Civic", "34XYZ789", 4);

            
            Driver d1 = new Driver("D01", "Ahmet Yılmaz", "+905551112233", v1);
            Driver d2 = new Driver("D02", "Mehmet Demir", "+905554445566", v2);

            rideService.RegisterDriver(d1);
            rideService.RegisterDriver(d2);

            
            Passenger p1 = new Passenger("P01", "Ayşe Kaya", "+905321234567", 4.8);
            Passenger p2 = new Passenger("P02", "Can Çelik", "+905339876543", 4.9);

            rideService.RegisterPassenger(p1);
            rideService.RegisterPassenger(p2);

            
            rideService.CreateRideRequest(p1, "Esenyurt Meydan", "Taksim Meydanı");
            rideService.CreateRideRequest(p2, "Avcılar Kampüs", "Bakırköy Sahil");

            
            rideService.ListDrivers();
            rideService.ListPassengers();
            rideService.ListRequests();

            Console.WriteLine("\nStage 1 Architecture Design completed successfully!");
        }
    }
}