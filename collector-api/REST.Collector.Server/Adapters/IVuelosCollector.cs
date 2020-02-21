using REST.Collector.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Collector.Server.Adapters
{
    interface IVuelosCollector
    {
        public List<Vuelo> GetVuelosIda(string origin, string destination, string departureDate, string adults);
        public List<List<Vuelo>> GetVuelosIdaVuelta(string origin, string destination, string departureDate, string returnDate, string adults);
    }
}
