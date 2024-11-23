using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Exceptions
{
    public class VehicleNotFoundException:ApplicationException
    {
        public VehicleNotFoundException()
        {
            
        }
        public VehicleNotFoundException(string msg):base(msg) 
        {
            
        }
    }
}
