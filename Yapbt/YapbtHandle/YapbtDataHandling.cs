using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.strausshome.yapbt.DataConnection;

namespace org.strausshome.yapbt.YapbtHandle
{
    public class YapbtDataHandling
    {
        public bool removeAirportVariation(AirportVariations airport)
        {
            Variation airportVariation = new Variation();

            return airportVariation.DeleteVariation(airport);
        }        
    }
}
