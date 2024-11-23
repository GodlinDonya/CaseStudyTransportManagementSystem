using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Exceptions
{
    internal class BookingNotFound:ApplicationException
    {
        public BookingNotFound()
        {
            
        }
        public BookingNotFound(string msg):base(msg) 
        {
            
        }

    }
}
