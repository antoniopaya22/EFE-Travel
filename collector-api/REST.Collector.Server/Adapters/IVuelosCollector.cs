using REST.Collector.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Collector.Server.Adapters
{
    interface IVuelosCollector
    {
        public List<Vuelo> GetVuelos();
    }
}
