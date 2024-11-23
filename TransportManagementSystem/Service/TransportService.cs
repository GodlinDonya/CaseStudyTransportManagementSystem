using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Exceptions;
using TransportManagementSystem.Model;
using TransportManagementSystem.Repository;

namespace TransportManagementSystem.Service
{
    public class TransportService : ITransportService

    {
        readonly ITransportManagement _transportManagement;
        public TransportService()
        {
            _transportManagement = new TransportManagement();
        }
        public bool AddVehicle(Vehicle vehicle)
        {
            try
            {
                var existingVehicles = _transportManagement.GetAllVehicles();
                var vehicleExist = existingVehicles.Find(v => v.Model == vehicle.Model);

                if (vehicleExist == null)
                {
                    _transportManagement.AddVehicle(vehicle);
                    Console.WriteLine("Vehicle addition Completed");
                    return true;
                }
                else
                {
                    throw new VehicleAlreadyExistException($"{vehicle.Model} already exist");
                }
            }
            catch (VehicleAlreadyExistException vae)
            {
                Console.WriteLine(vae.Message);
                return false;
            }
        }



        public List<Vehicle> GetAllVehicles()
        {
            try
            {
                return _transportManagement.GetAllVehicles();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Couldn't find any vehicles: {ex.Message}");
                return new List<Vehicle>();
            }
        }

        public bool UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                int result = _transportManagement.UpdateVehicle(vehicle);

                if (result > 0)
                {
                    Console.WriteLine("Vehicle updation Completed.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Vehicle updation failed. Vehicle ID may not exist.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteVehicle(int vehicleId)
        {
            try
            {
                int result = _transportManagement.DeleteVehicle(vehicleId);

                if (result > 0)
                {
                    Console.WriteLine("Vehicle deletion completed.");
                    return true;
                }
                else
                {
                    throw new VehicleNotFoundException($"{vehicleId} not found.");
                }
            }
            catch (VehicleNotFoundException vex)
            {
                Console.WriteLine(vex.Message);
                return false;


                //public int DeleteVehicle(int vehicleId)
                //{
                //    // Simulated database logic
                //    if (vehicleId == 999) 
                //        return 0; // 
                //    return 1; // 
                //}

            }
        }
    }
}
