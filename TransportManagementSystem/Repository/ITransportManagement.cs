

using TransportManagementSystem.Model;

namespace TransportManagementSystem.Repository
{
    public interface ITransportManagement
    {
        List<Vehicle> GetAllVehicles();
        int AddVehicle(Vehicle vehicle);
        int UpdateVehicle(Vehicle vehicle);
        int DeleteVehicle(int VehicleId);
        




        //bool updateVehicle(Vehicle vehicle);
        //int DeleteVehicle(Vehicle vehicle);


        //bool scheduleTrip(Vehicle vehicle);
        //bool cancelTrip(Vehicle vehicle);
        //bool bookTrip(Vehicle vehicle);
        //bool cancelBooking(Vehicle vehicle);
        //bool allocateDriver(Vehicle vehicle);
        //bool deallocateDriver(Vehicle vehicle);
        //bool getBookingsByPassenger(Vehicle vehicle);
        //bool getBookingsByTrip(Vehicle vehicle);
        //bool getAvailableDrivers(Vehicle vehicle);

        //Vehicle GetVehicleByType(string type);
    }
}
