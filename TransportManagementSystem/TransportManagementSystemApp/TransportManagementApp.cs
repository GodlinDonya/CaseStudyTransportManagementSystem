using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TransportManagementSystem.Model;
using TransportManagementSystem.Repository;
using TransportManagementSystem.Service;

namespace TransportManagementSystem.TransportManagementSystemApp
{
    internal class TransportManagementApp
    {
        ITransportService transportService = new TransportService();
        ITripService tripservice = new TripService();

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Transport Management System Menu");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Delete Vehicle");
                Console.WriteLine("3. View All Vehicles");
                Console.WriteLine("4. Update Vehicle");
                Console.WriteLine("5. Schedule Trip");
                Console.WriteLine("6. Cancel Trip");
                Console.WriteLine("7. Book Trip");
                Console.WriteLine("8. Allocate Driver");
                Console.WriteLine("9. Deallocate Driver");
                Console.WriteLine("10. Get Bookings By Passenger Id");
                Console.WriteLine("11. Get Bookings By Trip Id");
                Console.WriteLine("12. Get Available Drivers");
                Console.WriteLine("13. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddVehicle();
                        break;
                    case 2:
                        DeleteVehicle();
                        break;
                    case 3:
                        ViewAllVehicles();
                        break;
                    case 4:
                        UpdateVehicle();
                        break;
                    case 5:
                        ScheduleTrip();
                        break;
                    case 6:
                        CancelTrip();
                        break;
                    case 7:
                        BookTrip();
                        break;
                    case 8:
                        AllocateDriver();
                        GetAvailableDrivers();
                        break;
                    case 9:
                        DeallocateDriver();
                        break;
                    case 10:
                        GetBookingsByPassenger();
                        break;
                    case 11:
                        GetBookingsByTrip();
                        break;
                    case 12:
                        GetAvailableDrivers();
                        break;
                    case 13:
                        exit = true;
                        Console.WriteLine("Exiting the application......");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.Please try again.");
                        break;
                }
            }
        }

        public void AddVehicle()
        {

            //Console.Write("Enter Vehicle ID: ");
            //int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Vehicle Model: ");
            string model = Console.ReadLine();
            Console.Write("Enter Vehicle Capacity: ");
            decimal capacity = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Vehicle Type: ");
            string type = Console.ReadLine();
            Console.Write("Enter Vehicle Status: ");
            string status = Console.ReadLine();

            Vehicle vehicle = new Vehicle(model, capacity, type, status);
            bool isAdded = transportService.AddVehicle(vehicle);

            if (isAdded)
                Console.WriteLine("Vehicle added successfully!");
            else
                Console.WriteLine("Failed to add vehicle.");
        }

        public void DeleteVehicle()
        {

            Console.Write("Enter Vehicle ID to delete: ");
            int vehicleId = int.Parse(Console.ReadLine());
            bool isDeleted =transportService.DeleteVehicle(vehicleId);

            if (isDeleted)
            {
                Console.WriteLine("Vehicle deleted successfully!");
            }
            else
            {
                Console.WriteLine("Failed to delete vehicle.");
            }
        }

        public void ViewAllVehicles()
        {

            var vehicles = transportService.GetAllVehicles();

            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles available.");
                return;
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }


        public void UpdateVehicle()
        {
            Console.WriteLine("Enter Vehicle Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Model:");
            string model = Console.ReadLine();
            Console.WriteLine("Enter Capacity:");
            decimal capacity = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Type:");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Status:");
            string status = Console.ReadLine();
            Vehicle vehicle = new Vehicle(id, model, capacity, type, status);
            bool isInserted = transportService.UpdateVehicle(vehicle);

            if (isInserted)
            {
                Console.WriteLine("Vehicle updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update vehicle.");
            }
        }
        public void ScheduleTrip()
        {

            Console.WriteLine("Enter Vehicle ID:");
            int vehicleId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Route ID:");
            int routeId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Departure Date (yyyy-mm-dd ):");
            DateTime departureDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Arrival Date (yyyy-mm-dd ):");
            DateTime arrivalDate = Convert.ToDateTime(Console.ReadLine());
            bool result = tripservice.ScheduleTrip(vehicleId, routeId, departureDate, arrivalDate);

            if (result)
            {
                Console.WriteLine("Trip successfully scheduled.");
            }
            else
            {
                Console.WriteLine("Failed to schedule trip.");
            }
        }
        public void CancelTrip()
        {
            Console.WriteLine("Enter the Trip ID to cancel:");
            int tripId = Convert.ToInt32(Console.ReadLine());

            bool isCancelled = tripservice.CancelTrip(tripId);

            if (isCancelled)
            {
                Console.WriteLine("Trip cancellation was successful.");
            }
            else
            {
                Console.WriteLine("Trip cancellation failed.");
            }
        }
        public void BookTrip()
        {
            Console.WriteLine("Enter Trip ID:");
            int tripId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Passenger ID:");
            int passengerId = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter Booking Date (yyyy-MM-dd):");
            DateTime bookingDate = DateTime.Now;
            Booking booking = new Booking
            {
                TripId = tripId,
                PassengerId = passengerId,
                BookingDate = bookingDate,
                Status = "confirmed"
            };
            bool isBooked = tripservice.BookTrip(booking);
            Console.WriteLine(isBooked ? "Booking Successful." : "Booking Failed.");

        }
        public void CancelBooking()
        {
            Console.WriteLine("Enter Booking ID:");
            int bookingId = int.Parse(Console.ReadLine());

            bool isCancelled = tripservice.CancelBooking(bookingId);
            Console.WriteLine(isCancelled ? "Booking successfully cancelled." : "Failed to cancel booking.");

        }
        private void AllocateDriver()
        {
            Console.WriteLine("Enter Trip ID:");
            int tripId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Driver ID:");
            int driverId = Convert.ToInt32(Console.ReadLine());

            //Trip trip = new Trip
            //{
            //    TripId = tripId
            //};

            bool result = tripservice.AllocateDriver(tripId, driverId);

            if (result)
            {
                Console.WriteLine($"Driver {driverId} successfully allocated to Trip {tripId}.");
            }
            else
            {
                Console.WriteLine($"Failed to allocate Driver {driverId} to Trip {tripId}.");
            }
        }
        private void DeallocateDriver()
        {
            Console.WriteLine("Enter Trip ID:");
            int tripId = Convert.ToInt32(Console.ReadLine());

            bool result = tripservice.DeallocateDriver(tripId);

            if (result)
            {
                Console.WriteLine($"Driver successfully deallocated from Trip {tripId}.");
            }
            else
            {
                Console.WriteLine($"Failed to deallocate driver from Trip {tripId}.");
            }
        }
        public void GetBookingsByPassenger()
        {

            Console.Write("Enter Passenger ID: ");
            int passengerId = Convert.ToInt32(Console.ReadLine());

            List<Booking> bookings = tripservice.GetBookingsByPassenger(passengerId);

            if (bookings.Count > 0)
            {
                Console.WriteLine("Bookings for the Passenger:");
                foreach (var booking in bookings)
                {
                    Console.WriteLine($"Booking ID: {booking.BookingId}, Trip ID: {booking.TripId}, Booking Date: {booking.BookingDate}, Status: {booking.Status}");
                }
            }
            else
            {
                Console.WriteLine($"No bookings found for Passenger ID {passengerId}.");
            }
        }
        public void GetBookingsByTrip()
        {

            Console.Write("Enter Trip ID: ");
            int tripId = Convert.ToInt32(Console.ReadLine());

            List<Booking> bookings = tripservice.GetBookingsByTrip(tripId);

            if (bookings.Count > 0)
            {
                Console.WriteLine($"Bookings for the Passenger for the Trip {tripId}:");
                foreach (var booking in bookings)
                {
                    Console.WriteLine($"Booking ID: {booking.BookingId}, Trip ID: {booking.TripId}, Passenger Id: {booking.PassengerId}, Booking Date: {booking.BookingDate}, Status: {booking.Status}");
                }
            }
            else
            {
                Console.WriteLine($"No bookings found for Passenger ID {tripId}.");
            }


        }
        public void GetAvailableDrivers()
        {

            List<Driver> drivers = tripservice.GetAvailableDrivers();

            if (drivers.Count > 0)
            {
                Console.WriteLine("The Available Drivers are");
                foreach (var driver in drivers)
                {
                    Console.WriteLine($"Driver ID: {driver.DriverId}, Driver Name: {driver.DriverName}, Trip ID: {driver.TripId}, Gender: {driver.Gender}");
                }
            }
            else
            {
                Console.WriteLine("No drivers are found");
            }
        }


    }

    }


       


    




