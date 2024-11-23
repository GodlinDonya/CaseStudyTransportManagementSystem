using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Model
{
    public class Booking
    {

     
        public int BookingId { get; set; }
        public int TripId { get; set; }
        public int PassengerId { get; set; } 
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
      

        public Booking() { }
        public Booking(int bookingId, int tripID, int passengerId, DateTime bookingDate, string status)
        {
            //BookingID = bookingID;
            TripId = tripID;
            PassengerId = passengerId;
            BookingDate = bookingDate;
            Status = status;
        }

        public override string ToString()
        {
            return $"BookingID: {BookingId}, TripID: {TripId}, PassengerID: {PassengerId}, BookingDate: {BookingDate}, Status: {Status}";
        }
        

    }
}
