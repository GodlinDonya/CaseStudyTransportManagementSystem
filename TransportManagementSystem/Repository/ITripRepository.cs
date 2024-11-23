using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Repository
{
    public interface ITripRepository
    {
        int ScheduleTrip(int vehicleId, int routeId, DateTime departureDate, DateTime arrivalDate);
        int CancelTrip(int tripId);
        int BookTrip(Booking booking);
        int CancelBooking(int bookingId);
        int AllocateDriver(int tripId, int driverId);
        int DeallocateDriver(int tripId);
        List<Booking> GetBookingsByPassenger(int passengerId);
        List<Booking> GetBookingsByTrip(int tripId);
        List<Driver> GetAvailableDrivers();
    }
}
