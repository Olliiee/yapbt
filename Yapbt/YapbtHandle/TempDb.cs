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
    }
}
