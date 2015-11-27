using Org.Strausshome.Yapbt.DataConnection;

namespace Org.Strausshome.Yapbt.YapbtHandle
{
    /// <summary>
    ///  This class handles adding and deleting yapbt data and is the entry point.
    /// </summary>
    public class YapbtDataHandling
    {
        /// <summary>
        /// Remove a variation from db.
        /// </summary>
        /// <param name="airport">The airport variation object to delete.</param>
        /// <returns></returns>
        public bool RemoveAirportVariation(AirportVariations airport)
        {
            Variation airportVariation = new Variation();

            return airportVariation.DeleteVariation(airport);
        }

        /// <summary>
        /// Add a new variation from db.
        /// </summary>
        /// <param name="airport">The airport variation object to add.</param>
        /// <returns></returns>
        public bool AddAirportVariation(AirportVariations airport)
        {
            Variation airportVariation = new Variation();

            return airportVariation.AddNewVariation(airport);
        }
    }
}
