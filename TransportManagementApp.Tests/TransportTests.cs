using NUnit.Framework;
using TransportManagementSystem.Exceptions;
using TransportManagementSystem.Model;
using TransportManagementSystem.Repository;
using TransportManagementSystem.Service;

namespace TransportManagementApp.Tests
{
    public class TransportTests
    {
        ITripRepository tripRepository = new TripRepository();
        ITransportManagement transportRepo=new TransportManagement();

        [Test]

        public void Test_to_BookTrip()
        {
            Booking booking = new Booking
            {
                TripId = 3,
                PassengerId = 2,
                BookingDate = new DateTime(2024, 10, 12),
                Status = "confirmed"

            };
            int bookingStatus = tripRepository.BookTrip(booking);
            Assert.That(1, Is.EqualTo(bookingStatus));

        }
        [Test]
        public void Test_to_AllocateDriver()
        {
            int TripId = 3;
            int DriverId = 3;
            int allocationStatus = tripRepository.AllocateDriver(TripId, DriverId);
            Assert.That(1, Is.EqualTo(allocationStatus));
        }
        [Test]
        public void Test_to_DeleteVehicle()
        {
            int Id = 3;
           
            int allocationStatus = transportRepo.DeleteVehicle(Id);
            Assert.That(1, Is.EqualTo(allocationStatus));
        }
        [Test]
        public void Test_To_DeleteVehicle_Throws_Exception()
        {

            //var service = new TransportService();
            var invalidVehicleId = 999;

            Assert.That(transportRepo.DeleteVehicle(invalidVehicleId), Throws.Exception);
            Assert.That(transportRepo.DeleteVehicle(invalidVehicleId), Throws.TypeOf<VehicleNotFoundException>());
            Exception ex = Assert.Throws<VehicleNotFoundException>(() => Test_to_DeleteVehicle());
            Assert.That(ex.Message, Is.EqualTo($"{invalidVehicleId} not found."));
        }
        //[Test]
        //public void Test_To_Bike_Throws_Exception()
        //{
        //    int id = 99;
        //    Assert.That(TransportManagement.DeleteVehicle(id), Throws.Exception);
        //    Assert.That(TransportManagement.DeleteVehicle(id), Throws.TypeOf<VehicleNotFoundException>());
        //    Exception ex = Assert.Throws<T>(() => Test_To_AddBike());
        //    Assert.That(ex.Message, Is.EqualTo("BikeNotFound"));

        //}



    }
}
