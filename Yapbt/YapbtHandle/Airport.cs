using System.Linq;
using Org.Strausshome.Yapbt.DataConnection;

namespace Org.Strausshome.Yapbt.YapbtHandle
{
    public class AirportData
    {
        /// <summary>
        /// Get an airport by it's icao code.
        /// </summary>
        /// <param name="icaoCode">The necessary icao code.</param>
        /// <returns>Returns an airport or null.</returns>
        public Airport GetAirportByCode(string icaoCode)
        {
            if (icaoCode != string.Empty)
            {
                using (var db = new YapbtDbEntities())
                {
                    var airport = db.Airport
                        .Where(c => c.icao == icaoCode)
                        .FirstOrDefault();

                    if (airport != null)
                    {
                        return airport;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}
