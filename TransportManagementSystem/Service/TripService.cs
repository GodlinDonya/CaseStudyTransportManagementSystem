using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Exceptions;
using TransportManagementSystem.Model;
using TransportManagementSystem.Repository;

namespace TransportManagementSystem.Service
{
    internal class TripService:ITripService
    {
        readonly ITripRepository _tripRepository;

        public TripService()
        {
            _tripRepository = new TripRepository();
        }

        public bool ScheduleTrip(int vehicleId, int routeId, DateTime departureDate, DateTime arrivalDate)
        {
            try
            {
                
                int isScheduled = _tripRepository.ScheduleTrip(vehicleId, routeId, departureDate, arrivalDate);              
                if (isScheduled>0)
                {
                    Console.WriteLine("Trip has been scheduled successfully.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to schedule trip. Please check the input values.");
                    return false;
                }
            }
            catch (Exception ex)
            {
             
                Console.WriteLine($"Error scheduling trip: {ex.Message}");
                return false;
            }
        }
        public bool CancelTrip(int tripId)
        {
            try
            {


                int isCancelled = _tripRepository.CancelTrip(tripId);

                if (isCancelled > 0)
                {
                    Console.WriteLine($"Trip with ID {tripId} has been successfully cancelled.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Failed to cancel the trip with ID {tripId}. It may not exist.");
                    return false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error scheduling trip: {ex.Message}");
                return false;
            }


        }
        public bool BookTrip(Booking booking)
        {
            try
            {
                int booked = _tripRepository.BookTrip(booking);

                if (booked > 0)
                {
                    Console.WriteLine($"Trip successfully booked for PassengerID {booking.PassengerId} on TripID {booking.TripId}.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Booking failed for PassengerID {booking.PassengerId} on TripID {booking.TripId}. Please check the details.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while booking trip: {ex.Message}");
                return false;
            }
        }
        public bool CancelBooking(int bookingId)
        {
            try
            {
                int cancelled = _tripRepository.CancelBooking(bookingId);

                if (cancelled > 0)
                {
                    Console.WriteLine($"Booking with ID {bookingId} has been successfully cancelled.");
                    return true;
                }
                else
                {
                    throw new BookingNotFound($"{ bookingId} Not found");
                    return false;
                }
            }
            catch (BookingNotFound bex)
            {
                Console.WriteLine(bex.Message); ;
                return false;
            }
        }
        public bool AllocateDriver(int tripId, int driverId)
        {
            try
            {
                int allocationResult = _tripRepository.AllocateDriver(tripId, driverId);

                if (allocationResult > 0)
                {
                    Console.WriteLine($"Driver with ID {driverId} has been successfully allocated to trip {tripId}.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Failed to allocate driver with ID {driverId} to trip {tripId}. Please check if the driver or trip exists.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error allocating driver: {ex.Message}");
                return false;
            }
        }
        public bool DeallocateDriver(int tripId)
        {
            try
            {

                int deallocationResult = _tripRepository.DeallocateDriver(tripId);

                if (deallocationResult > 0)
                {
                    Console.WriteLine($"Driver has been successfully deallocated to trip {tripId}.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Failed to deallocate driver to trip {tripId}. Please check if the trip exists.");
                    return false;
                }
            }
            
            catch (Exception ex)
            {
                Console.WriteLine($"Error deallocating driver from Trip {tripId}: {ex.Message}");
                return false;
            }
        }
        public List<Booking> GetBookingsByPassenger(int passengerId)
        {
            try
            {
                List<Booking> bookings = _tripRepository.GetBookingsByPassenger(passengerId);
                if (bookings.Count == 0)
                {
                    Console.WriteLine($"No bookings found for Passenger ID {passengerId}");
                }
                return bookings;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching bookings: {ex.Message}");
                return new List<Booking>();
            }
        }
        public List<Booking> GetBookingsByTrip(int tripId)
        {
            try
            {
                List<Booking> bookings = _tripRepository.GetBookingsByTrip(tripId);
                if (bookings.Count == 0)
                {
                    Console.WriteLine($"No bookings found for Passenger ID {tripId}");
                }
                return bookings;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching bookings: {ex.Message}");
                return new List<Booking>();
            }
        }
        public List<Driver> GetAvailableDrivers()
        {
            try
            {
                List<Driver> drivers = _tripRepository.GetAvailableDrivers();
                if (drivers.Count == 0)
                {
                    Console.WriteLine($"No Drivers found Available");
                }
                return drivers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching Available Drivers: {ex.Message}");
                return new List<Driver>();
            }
        }





    }
}
