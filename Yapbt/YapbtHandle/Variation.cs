using org.strausshome.yapbt.DataConnection;
using System;

namespace org.strausshome.yapbt.YapbtHandle
{
    /// <summary>
    /// This class handles all the variation data.
    /// </summary>
    public class Variation
    {
        #region Variation

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

        #endregion Variation
    }
}