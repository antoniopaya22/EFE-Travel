using Newtonsoft.Json.Linq;
using REST.Collector.Client.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace REST.Collector.Client.Data
{
    public class LocationData
    {
        public List<AmadeusLocation> locations { set; get; }

        public LocationData()
        {
            this.locations = new List<AmadeusLocation>();
            JArray json_loc = JArray.Parse(File.ReadAllText("locations.json"));
            foreach (dynamic dyn_loc in json_loc)
            {
                AmadeusLocation loc = new AmadeusLocation(dyn_loc);
                this.locations.Add(loc);
            }
        }
    }
}
