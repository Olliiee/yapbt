using org.strausshome.yapbt.DataConnection;
using System;
using System.Linq;

namespace org.strausshome.yapbt.YapbtHandle
{
    /// <summary>
    /// This class handles all pushback points.
    /// </summary>
    public class Point
    {
        #region PushbackPoints

        /// <summary>
        /// Remove all points belonging to a single pushback path.
        /// </summary>
        /// <param name="pushBackPath">The pushback path we are looking for.</param>
        /// <returns>True allright; False something went wrong.</returns>
        public bool RemovePushbackPoint(AirportPushBackPath pushBackPath)
        {
            try
            {
                using (var db = new YapbtDbEntities())
                {
                    // Find a list of all points, which belongs to this path.
                    var points = db.AirportPushPoints.Where(c => c.AirportPushBackPath == pushBackPath).ToList();

                    // If any point was found, remove it.
                    if (points.Any())
                    {
                        points.ForEach(delegate (AirportPushPoints point)
                        {
                            db.AirportPushPoints.Remove(point);
                            db.SaveChanges();
                        });
                    }

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// Remove a single pushback point.
        /// </summary>
        /// <param name="pushBackPoint">The single pushback point we are looking for.</param>
        /// <returns>True point deleted; False something went wrong.</returns>
        public bool RemovePushbackPoint(AirportPushPoints pushBackPoint)
        {
            try
            {
                // Checking if the point is set.
                if (pushBackPoint != null)
                {
                    using (var db = new YapbtDbEntities())
                    {
                        // Remove the pushback point.
                        db.AirportPushPoints.Remove(pushBackPoint);
                        db.SaveChanges();

                        return true;
                    } 
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        #endregion PushbackPoints
    }
}