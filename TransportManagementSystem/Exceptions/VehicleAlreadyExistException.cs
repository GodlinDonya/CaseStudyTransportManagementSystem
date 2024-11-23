    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace TransportManagementSystem.Exceptions
    {
        internal class VehicleAlreadyExistException:ApplicationException
        {
            public VehicleAlreadyExistException()
            {
            
            }
            public VehicleAlreadyExistException(string msg):base(msg)
            {
            
            }
        }
    }
