using System.Collections.Generic;
using System.Linq;
using org.strausshome.yapbt.DataConnection;

namespace org.strausshome.yapbt.YapbtHandle
{
    /// <summary>
    /// This class handles all position data.
    /// </summary>
    public class Position
    {
        #region Positions

        /// <summary>
        /// Add a new airport position to the db.
        /// </summary>
        /// <param name="position">The position object to add to the db.</param>
        /// <returns>True everything went well; False something went wrong.</returns>
        public bool AddNewPosition(AirportPositions position)
        {
            using (var db = new YapbtDbEntities())
            {
                try
                {
                    db.AirportPositions.Add(position);
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                    throw;
                }
            }
        }

        /// <summary>
        /// Add a list of positions to the db.
        /// </summary>
        /// <param name="positions">The list of positions.</param>
        /// <returns>True everything went well; False something went wrong.</returns>
        public bool AddNewPosition(List<AirportPositions> positions)
        {
            using (var db = new YapbtDbEntities())
            {
                try
                {
                    foreach (var position in positions)
                    {
                        db.AirportPositions.Add(position);


                    }

                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                    throw;
                }
            }
        }

        /// <summary>
        /// Remove all positions of an variation.
        /// </summary>
        /// <param name="variation">
        /// The airport variation. With this object, it will lookup for all positions.
        /// </param>
        /// <returns>True everything went well; False something went wrong.</returns>
        public bool RemoveAllPositions(AirportVariations variation)
        {
            using (var db = new YapbtDbEntities())
            {
                Path path = new Path();

                // Find a list of all positions, which belongs to this variation.
                var position = db.AirportPositions.Where(c => c.variationid == variation.variationid).ToList();

                // If any position is available.
                if (position.Any())
                {
                    // For each position, remove all pushback path and remove the position.
                    position.ForEach(delegate (AirportPositions pos)
                    {
                        path.RemoveAllPushbackPathOfPosition(pos);
                        db.AirportPositions.Remove(pos);
                        db.SaveChanges();
                    });
                }

                return true;
            }
        }

        #endregion Positions
    }
}