using System.Collections.Generic;
using System.Linq;
using Org.Strausshome.Yapbt.DataConnection;

namespace Org.Strausshome.Yapbt.YapbtHandle
{
    /// <summary>
    /// This class handles all pushback paths related stuff.
    /// </summary>
    public class Path
    {
        #region PushbackPath

        /// <summary>
        /// Add a list of paths to the db.
        /// </summary>
        /// <param name="pathList">A list of paths.</param>
        /// <returns>A list of all paths that made trouble.</returns>
        public List<AirportPushBackPath> AddPathByList(List<AirportPushBackPath> pathList)
        {
            // The return list with error path objects. Hope it will always be null.
            List<AirportPushBackPath> errorPath = new List<AirportPushBackPath>();

            using (var db = new YapbtDbEntities())
            {
                foreach (var path in pathList)
                {
                    try
                    {
                        // Add the new path.
                        AirportPushBackPath newPath = new AirportPushBackPath();
                        newPath = path;
                        db.AirportPushBackPath.Add(newPath);

                        // TODO bulk inserts?
                        db.SaveChanges();
                    }
                    catch (System.Exception)
                    {
                        // unable to store it into the db. Add it to the list for an error message.
                        errorPath.Add(path);
                    }
                }
            }

            return errorPath;
        }

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

        #endregion PushbackPath
    }
}