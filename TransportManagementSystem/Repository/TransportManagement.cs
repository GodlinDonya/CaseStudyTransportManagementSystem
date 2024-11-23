

using System.Data;
using System.Data.SqlClient;
using System.Text;
using TransportManagementSystem.Model;
using TransportManagementSystem.Utility;

namespace TransportManagementSystem.Repository
{
    public   class TransportManagement:ITransportManagement
    #region
    {
        //List<Vehicle> vehicles;

        //public TransportManagement()
        //{

        //    //vehicles = new List<Vehicle>(){
        //    //    new Vehicle(){VehicleId=101, Model="F101", Capacity=120M, Type="Van", Status="On Trip"},
        //    //    new Vehicle(){VehicleId=102, Model="F102", Capacity=150M, Type="Truck", Status="Maintenance"}
        //    //};


        //}
        //public bool AddVehicle(Vehicle vehicle)
        //{
        //    #region
        //    //vehicles.Add(vehicle);
        //    //return true;
        //    #endregion
        //}
        //public List<Vehicle> GetAllVehicles()
        //{

        //    return vehicles;

        //}
        //public Vehicle GetVehicleByType(string type)
        //{
        //    return vehicles.Find(v => v.Type == type);
        //}
        //public bool deleteVehicle(Vehicle vehicle)
        //{

        //    return true;
        //}
        #endregion

        SqlCommand cmd =null;
        string connectionstring;
        public TransportManagement()
        {
            connectionstring = DbConnUtil.GetConnectionString();
            cmd =new SqlCommand();
            
        }

        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring)) {
                cmd.CommandText = "Select * from Vehicles";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.VehicleId = (int)reader["VehicleId"];
                    vehicle.Model = (string)reader["Model"];
                    vehicle.Capacity = (decimal)reader["Capacity"];
                    vehicle.Type = (string)reader["Type"];
                    vehicle.Status = (string)reader["Status"];
                    vehicles.Add(vehicle);
                }
            }
            return vehicles;


        }
        public int AddVehicle(Vehicle vehicle)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                cmd.CommandText = "Insert into vehicles values(@Model,@Capacity,@Type,@Status);select scope_identity();";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@Capacity", vehicle.Capacity);
                cmd.Parameters.AddWithValue("@Type", vehicle.Type);
                cmd.Parameters.AddWithValue("@Status", vehicle.Status);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                //object result = cmd.ExecuteScalar();
                //return result != null ? Convert.ToInt32(result) : 0;
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteVehicle(int vehicleId)

        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            {
                cmd.CommandText = "delete from vehicles where @VehicleId=VehicleId;select scope_identity();";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                cmd.Connection= sqlConnection;
                sqlConnection.Open();
                return cmd.ExecuteNonQuery();


            }
        }

        public int UpdateVehicle(Vehicle vehicle)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                cmd.CommandText = "UPDATE Vehicles SET Model = @Model, Capacity = @Capacity, Type = @Type, Status = @Status WHERE VehicleId = @VehicleId";

               
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@Capacity", vehicle.Capacity);
                cmd.Parameters.AddWithValue("@Type", vehicle.Type);
                cmd.Parameters.AddWithValue("@Status", vehicle.Status);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                //int rowsAffected = 
                return cmd.ExecuteNonQuery();
            }
        }
       




        //public bool AddVehicle(Vehicle vehicle)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool DeleteVehicle(Vehicle vehicle)
        //{
        //    throw new NotImplementedException();
        //}
        //public bool updateVehicle(Vehicle vehicle)
        //{
        //    return true;
        //}
        //public bool scheduleTrip(Vehicle vehicle)
        //{
        //    return true;
        //}
        //public bool cancelTrip(Vehicle vehicle)
        //{
        //    return true;
        //}
        //public bool bookTrip(Vehicle vehicle)
        //{
        //    return true;
        //}
        //public bool cancelBooking(Vehicle vehicle)
        //{
        //    return true;
        //}
        //public bool allocateDriver(Vehicle vehicle)
        //{
        //    return true;
        //}
        //public bool deallocateDriver(Vehicle vehicle)
        //{
        //    return true;
        //}
        //public bool getBookingsByPassenger(Vehicle vehicle)
        //{
        //    return true;
        //}
        //public bool getBookingsByTrip(Vehicle vehicle)
        //{
        //    return true;
        //}
        //public bool getAvailableDrivers(Vehicle vehicle)
        //{
        //    return true;
        //}


    }
}
