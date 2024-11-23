using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagementSystem.Repository.TripRepository;
using TransportManagementSystem.Utility;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Repository
{
    public class TripRepository:ITripRepository
    {
        SqlCommand cmd = null;
        string connectionstring;
        public TripRepository()
        {
            connectionstring = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();

        }     
        public int ScheduleTrip(int vehicleId, int routeId, DateTime departureDate, DateTime arrivalDate)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO Trips (VehicleID, RouteID, DepartureDate, ArrivalDate, Status, TripType) ");
                sb.Append("VALUES (@VehicleID, @RouteID, @DepartureDate, @ArrivalDate, 'Scheduled', 'Passenger')");

                cmd.CommandText = sb.ToString();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VehicleID", vehicleId);
                cmd.Parameters.AddWithValue("@RouteID", routeId);
                cmd.Parameters.AddWithValue("@DepartureDate", departureDate);
                cmd.Parameters.AddWithValue("@ArrivalDate", arrivalDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                return cmd.ExecuteNonQuery();


                   
            }
        }
        public int CancelTrip(int tripId)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE Trips ");
                sb.Append("SET Status = 'Cancelled' ");
                sb.Append("WHERE TripID = @TripID");

                cmd.CommandText = sb.ToString();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TripID", tripId);
                cmd.Connection = connection;

                connection.Open();

                return cmd.ExecuteNonQuery();
             
            }
        }
        public int BookTrip(Booking booking)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO Bookings (TripID, PassengerID, BookingDate, Status) ");
                sb.Append("VALUES (@TripID, @PassengerID, @BookingDate, 'confirmed')");

                cmd.CommandText = sb.ToString();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TripID", booking.TripId);
                cmd.Parameters.AddWithValue("@PassengerID", booking.PassengerId);
                cmd.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                cmd.Connection = connection;

                connection.Open();
                return cmd.ExecuteNonQuery(); 
            }
        }
        public int CancelBooking(int bookingId)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE Bookings ");
                sb.Append("SET Status = 'Cancelled' ");
                sb.Append("WHERE BookingID = @BookingID ");

                cmd.CommandText = sb.ToString();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@BookingID", bookingId);
                cmd.Connection = connection;

                connection.Open();
                return cmd.ExecuteNonQuery(); 
            }
        }
        public int AllocateDriver(int tripId, int driverId)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE Drivers ");
                sb.Append("SET TripId = @TripId ");
                sb.Append("WHERE DriverId = @DriverId and isavailable=1");

                cmd.CommandText = sb.ToString();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TripId", tripId);
                cmd.Parameters.AddWithValue("@DriverId", driverId);
                cmd.Connection = connection;

                connection.Open();

                return cmd.ExecuteNonQuery();
            }
        }
        public int DeallocateDriver(int tripId)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE Drivers ");
                sb.Append("SET DriverName = NULL,isavailable=0");
                sb.Append("WHERE TripID = @TripID");

                cmd.CommandText = sb.ToString();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TripID", tripId);
                cmd.Connection = connection;

                connection.Open();

                return cmd.ExecuteNonQuery();
              
            }
        }
        public List<Booking> GetBookingsByPassenger(int passengerId)
        {
            List<Booking> bookings = new List<Booking>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT BookingID, TripID, PassengerID, BookingDate, Status ");
                sb.Append("FROM Bookings ");
                sb.Append("WHERE PassengerID = @PassengerID");

                cmd.CommandText = sb.ToString();
                cmd.Parameters.Clear();
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@PassengerID", passengerId);
                
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Booking booking = new Booking
                    {
                        BookingId = (int)(reader["BookingID"]),
                        TripId = (int)(reader["TripID"]),
                        PassengerId = (int)(reader["PassengerID"]),
                        BookingDate = (DateTime)(reader["BookingDate"]),
                        Status = (string)reader["Status"]
                    };

                    bookings.Add(booking);
                }
            }
            return bookings;
        }
        public List<Booking> GetBookingsByTrip(int tripId)
        {
            List<Booking> bookings = new List<Booking>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT BookingID, TripID, PassengerID, BookingDate, Status ");
                sb.Append("FROM Bookings ");
                sb.Append("WHERE TripID = @TripID");

                cmd.CommandText = sb.ToString();
                cmd.Parameters.Clear();
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@TripID", tripId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Booking booking = new Booking
                    {
                        BookingId = (int)(reader["BookingID"]),
                        TripId = (int)(reader["TripID"]),
                        PassengerId = (int)(reader["PassengerID"]),
                        BookingDate = (DateTime)(reader["BookingDate"]),
                        Status = (string)reader["Status"]
                    };

                    bookings.Add(booking);
                }
            }
            return bookings;
        }
        public List<Driver> GetAvailableDrivers()
        {
            List<Driver> drivers = new List<Driver>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
              
                cmd.CommandText = "SELECT * From Drivers where isavailable =1";
                cmd.Parameters.Clear();
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   Driver driver = new Driver
                    {
                        DriverId = (int)(reader["DriverId"]),
                        DriverName = (string)reader["DriverName"],
                        Gender= (string)(reader["gender"]),
                        IsAvailable = (bool)(reader["isavailable"]),
                        TripId = (int)(reader["TripID"]),
                       
                    };

                    drivers.Add(driver);
                }
            }
            return drivers;
        }






    }
}
