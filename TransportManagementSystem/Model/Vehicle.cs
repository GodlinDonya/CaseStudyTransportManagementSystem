

namespace TransportManagementSystem.Model
{
    public class Vehicle
    {
       
        public int VehicleId { get; set; }
        public string Model { get; set; }
        public decimal Capacity { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }

        public Vehicle()
        {
            
        }
        public Vehicle(int id,string model,decimal capacity,string type,string status)
        {
            VehicleId = id;
            Model = model;
            Capacity = capacity;
            Type = type;
            Status = status;

        }
        public Vehicle(string model, decimal capacity, string type, string status)
        {
            
            Model = model;
            Capacity = capacity;
            Type = type;
            Status = status;

        }

        public override string ToString()
        {
            return $"Vehicle Id::{VehicleId}\tModel::{Model}\tCapacity::{Capacity}\tType::{Type}\tStatus::{Status}";
        }
    }
}
