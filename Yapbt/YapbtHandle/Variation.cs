using System;
using System.Collections.Generic;
using System.Linq;
using Org.Strausshome.Yapbt.DataConnection;

namespace Org.Strausshome.Yapbt.YapbtHandle
{
    /// <summary>
    /// This class handles all the variation data.
    /// </summary>
    public class Variation
    {
        #region Variation

        /// <summary>
        /// Return a variation list by a specific airport code.
        /// </summary>
        /// <param name="icaoCode">The airport we are looking for.</param>
        /// <returns>Returns a list of variation objects.</returns>
        public List<AirportVariations> VariationsByAirport(string icaoCode)
        {
            using (var db = new YapbtDbEntities())
            {
                try
                {
                    return db.AirportVariations.Where(c => c.Airport.icao == icaoCode).ToList();
                }
                catch (Exception)
                {
                    return null;
                    throw;
                }
            }
        }

        /// <summary>
        /// Add a new airport variation by object.
        /// </summary>
        /// <param name="airport">The airport object to add.</param>
        /// <returns>True variation added to db; False something went wrong.</returns>
        public bool AddNewVariation(AirportVariations airport)
        {
            using (var db = new YapbtDbEntities())
            {
                try
                {
                    db.AirportVariations.Add(airport);
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }

            return true;
        }

        /// <summary>
        /// Add a new airport variation.
        /// </summary>
        /// <param name="variationName">The name of the airport variation.</param>
        /// <param name="airport">      The airport it will reference to.</param>
        /// <returns>True variation added to db; False something went wrong.</returns>
        public bool AddNewVariation(string variationName, Airport airport)
        {
            // Use the YapbtDbEntities to store the data.
            using (var db = new YapbtDbEntities())
            {
                try
                {
                    // Create a new variation, add the data and safe it.
                    AirportVariations variation = new AirportVariations();

                    variation.Airport = airport;
                    variation.variationname = variationName;
                    variation.cts = DateTime.Now;

                    // Add the new variation to the db.
                    db.AirportVariations.Add(variation);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //
        /// <summary>
        /// Adding a airport variations and all positions, paths and pusback points to the db.
        /// </summary>
        /// <param name="variationName">The airport variation name.</param>
        /// <param name="airport">      The airport object.</param>
        /// <param name="positionList"> A list of positions.</param>
        /// <param name="pathList">     A list of posible paths.</param>
        /// <param name="pointList">    A list of push back points.</param>
        /// <returns></returns>
        public bool AddNewVariationList(string variationName,
            Airport airport,
            List<AirportPositions> positionList,
            List<AirportPushBackPath> pathList,
            List<AirportPushPoints> pointList)
        {
            List<AirportPositions> errorPositionList = new List<AirportPositions>();
            List<AirportPushBackPath> errorPathList = new List<AirportPushBackPath>();
            List<AirportPushPoints> errorPointList = new List<AirportPushPoints>();

            // Use the YapbtDbEntities to store the data.
            using (var db = new YapbtDbEntities())
            {
                try
                {
                    AddVariation(variationName, airport, db);

                    // Adding the positions to the db.
                    Position position = new Position();
                    Path path = new Path();
                    Point point = new Point();

                    // For each position it will add a path and it's points.
                    errorPositionList = position.AddNewPosition(positionList);

                    foreach (var errorPosition in errorPositionList)
                    {
                        positionList.Remove(errorPosition);

                        var pathToRemoveList = pathList.Where(c => c.AirportPositions == errorPosition).ToList();

                        foreach (var pathToRemove in pathToRemoveList)
                        {
                            pathList.Remove(pathToRemove);
                            pointList = this.RemovePoints(pointList, pathToRemove);
                        }
                    }

                    //Add the path list data to the db
                    errorPathList = path.AddPathByList(pathList);

                    foreach (var pathToRemove in errorPathList)
                    {
                        pathList.Remove(pathToRemove);
                        pointList = this.RemovePoints(pointList, pathToRemove);
                    }

                    // Add the point list to the data.
                    errorPointList = point.AddPointsByList(pointList);

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Delete a variation and all necessary data (positions, paths).
        /// </summary>
        /// <param name="variation">The variation to delete.</param>
        /// <returns>True variation was delted; False not able.</returns>
        public bool DeleteVariation(AirportVariations variation)
        {
            using (var db = new YapbtDbEntities())
            {
                Position position = new Position();

                //TODO Remove Pushbackpath and positions.
                position.RemoveAllPositions(variation);

                db.AirportVariations.Remove(variation);
                db.SaveChanges();

                return true;
            }
        }

        static void AddVariation(string variationName, Airport airport, YapbtDbEntities db)
        {
            // Create a new variation, add the data and safe it.
            AirportVariations variation = new AirportVariations();

            variation.Airport = airport;
            variation.variationname = variationName;
            variation.cts = DateTime.Now;

            // Add the new variation to the db.
            db.AirportVariations.Add(variation);
            db.SaveChanges();
        }

        List<AirportPushPoints> RemovePoints(List<AirportPushPoints> pointList, AirportPushBackPath pathToRemove)
        {
            var pointsToRemoveList = pointList.Where(c => c.AirportPushBackPath == pathToRemove).ToList();

            foreach (var pointToRemove in pointsToRemoveList)
            {
                pointList.Remove(pointToRemove);
            }

            return pointList;
        }

        #endregion Variation
    }
}