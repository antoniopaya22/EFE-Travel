using SOAP.Collector.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOAP.Collector.Server.Adapters
{
    public interface IVuelosCollector
    {
        List<Vuelo> GetVuelos();
    }
}
