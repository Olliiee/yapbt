using System.Collections.Generic;
using System.Linq;
using Org.Strausshome.Yapbt.DataConnection;

namespace Org.Strausshome.Yapbt.YapbtHandle
{
    public class TempDb
    {
        /// <summary>
        /// Load all parking positions from temp table.
        /// </summary>
        /// <returns>All parking positions.</returns>
        public IEnumerable<TempParking> GetParkingPositions()
        {
            using (var db = new YapbtDbEntities())
            {
                return db.TempParking.ToList();
            }
        }

        /// <summary>
        /// Load all taxiway with the necessary start and stop point.
        /// </summary>
        /// <returns>Returns the taxiway list.</returns>
        public IEnumerable<Taxiway> GetTaxiways()
        {
            using (var db = new YapbtDbEntities())
            {
                // Load the complete taxiway list.
                var taxiwayList = db.TempTaxiway.Where(c => c.Type == "TAXI" || c.Type == "PATH").ToList();

                foreach (var taxiway in taxiwayList)
                {
                    Taxiway resultTaxiway = new Taxiway();

                    // Get the from point by it's index.
                    resultTaxiway.FromPoint = db.TempPoint
                        .Where(c => c.Index == taxiway.FromPoint)
                        .Single();

                    // Get the to point by it's index.
                    resultTaxiway.ToPoint = db.TempPoint
                        .Where(c => c.Index == taxiway.ToPoint)
                        .Single();

                    resultTaxiway.Type = taxiway.Type;

                    yield return resultTaxiway;
                }
            }
        }
    }
}
