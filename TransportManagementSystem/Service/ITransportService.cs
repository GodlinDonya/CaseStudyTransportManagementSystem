using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Service
{
    internal interface ITransportService
    {
        bool AddVehicle(Vehicle vehicle);
        bool DeleteVehicle(int VehicleId);
        bool UpdateVehicle(Vehicle vehicle);
        List<Vehicle> GetAllVehicles();
    }
}
