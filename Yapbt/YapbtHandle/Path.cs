using System.Collections.Generic;
using System.Linq;
using org.strausshome.yapbt.DataConnection;

namespace org.strausshome.yapbt.YapbtHandle
{
    /// <summary>
    /// This class handles all pushback paths related stuff.
    /// </summary>
    public class Path
    {
        #region PushbackPath

        /// <summary>
        /// Remove all pushback paths belonging to a position.
        /// </summary>
        /// <param name="position">The position it will lookup for.</param>
        /// <returns>True everything was ok; False something went wrong.</returns>
        public bool RemoveAllPushbackPathOfPosition(AirportPositions position)
        {
            using (var db = new YapbtDbEntities())
            {
                Point point = new Point();

                // Find all pushback paths belonging to the position.
                var pushBackPath = db.AirportPushBackPath.Where(c => c.positionid == position.positionid).ToList();

                // If any path was found.
                if (pushBackPath.Any())
                {
                    // For each path remove the positions and the path.
                    pushBackPath.ForEach(delegate (AirportPushBackPath pushpath)
                    {
                        point.RemovePushbackPoint(pushpath);
                        db.AirportPushBackPath.Remove(pushpath);
                        db.SaveChanges();
                    });
                }

                return true;
            }
        }

        internal bool AddPathByList(AirportPositions position, List<AirportPushBackPath> paths)
        {
            using (var db = new YapbtDbEntities())
            {
                Point point = new Point();

                // Find all pushback paths belonging to the position.
                var pushBackPath = db.AirportPushBackPath.Where(c => c.positionid == position.positionid).ToList();

                // If any path was found.
                if (pushBackPath.Any())
                {
                    // For each path remove the positions and the path.
                    pushBackPath.ForEach(delegate (AirportPushBackPath pushpath)
                    {
                        point.RemovePushbackPoint(pushpath);
                        db.AirportPushBackPath.Remove(pushpath);
                        db.SaveChanges();
                    });
                }

                return true;
            }
        }

        #endregion PushbackPath
    }
}