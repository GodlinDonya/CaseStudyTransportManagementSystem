using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Model
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string Gender { get; set; }
        public int TripId { get; set; }
        public bool IsAvailable { get; set; } = false;


        public Driver()
        {

        }
        public Driver(int driverId, string driverName, string gender, int tripId,bool isavailable)
        {
            DriverId = driverId;
            DriverName = driverName;
            Gender = gender;
            TripId = tripId;
            IsAvailable = isavailable;

        }

    }
}
