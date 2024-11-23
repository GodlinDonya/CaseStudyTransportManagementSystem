using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Service
{
    internal interface ITripService
    {
        bool ScheduleTrip(int vehicleId, int routeId, DateTime departureDate, DateTime arrivalDate);
        bool CancelTrip(int tripId);
        bool BookTrip(Booking booking);
        bool CancelBooking(int BookingId);
        bool AllocateDriver(int tripId, int driverId);
        bool DeallocateDriver(int tripId);
        List<Booking> GetBookingsByPassenger(int passengerId);
        List<Booking> GetBookingsByTrip(int tripId);
        List<Driver> GetAvailableDrivers();



    }
}
