using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Model
{
    internal class Passenger
    {
       
            public int PassengerID { get; set; } 
            public string FirstName { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public string Email { get; set; } 
            public string PhoneNumber { get; set; }
            public Passenger() { }
            public Passenger(int passengerID, string firstName, string gender, int age, string email, string phoneNumber)
            {
                //PassengerID = passengerID;
                FirstName = firstName;
                Gender = gender;
                Age = age;
                Email = email;
                PhoneNumber = phoneNumber;
            }

            public override string ToString()
            {
                return $"PassengerID: {PassengerID}, Name: {FirstName}, Gender: {Gender}, Age: {Age}, Email: {Email}, Phone: {PhoneNumber}";
            }
        

    }
}
