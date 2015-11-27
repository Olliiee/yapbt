using System;
using System.Collections.Generic;
using System.Linq;
using Org.Strausshome.Yapbt.DataConnection;

namespace Org.Strausshome.Yapbt.YapbtHandle
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

                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// Add a list of points to the db.
        /// </summary>
        /// <param name="pointList">A list of points to add them into the db.</param>
        /// <returns>A possible list of points running into an error.</returns>
        public List<AirportPushPoints> AddPointsByList(List<AirportPushPoints> pointList)
        {
            List<AirportPushPoints> errorList = new List<AirportPushPoints>();

            // For each point in the list add it.
            foreach (var point in pointList)
            {
                if (!this.AddPoint(point))
                {
                    errorList.Add(point);
                }
            }

            return errorList;
        }

        /// <summary>
        /// Add a single point to the db.
        /// </summary>
        /// <param name="pointToAdd">The point object.</param>
        /// <returns>True everything ok; False something went wrong.</returns>
        public bool AddPoint(AirportPushPoints pointToAdd)
        {
            try
            {
                using (var db = new YapbtDbEntities())
                {
                    db.AirportPushPoints.Add(pointToAdd);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion PushbackPoints
    }
}