using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Model
{
    internal class Route
    {
        public int RouteID { get; set; }
        public string StartDestination { get; set; }
        public string EndDestination { get; set; }
        public decimal Distance { get; set; }
        public Route()
        {

        }
        public Route(int routeID, string startDestination, string endDestination, decimal distance)
        {
            RouteID = routeID;
            StartDestination = startDestination;
            EndDestination = endDestination;
            Distance = distance;
        }

        
       

       
        public override string ToString()
        {
            return $"RouteID: {RouteID}, Start: {StartDestination}, End: {EndDestination}, Distance: {Distance}";
        }
    }
}
