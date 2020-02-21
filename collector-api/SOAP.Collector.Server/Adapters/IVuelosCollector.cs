using SOAP.Collector.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOAP.Collector.Server.Adapters
{
    public interface IVuelosCollector
    {
        List<Vuelo> GetVuelosIda(string origin, string destination, string departureDate, string adults);
        List<List<Vuelo>> GetVuelosIdaVuelta(string origin, string destination, string departureDate, string returnDate, string adults);
    }
}
