using org.strausshome.yapbt.DataConnection;

namespace org.strausshome.yapbt.YapbtHandle
{
    // This class handles adding and deleting yapbt data.
    public class YapbtDataHandling
    {
        /// <summary>
        /// Remove a variation from db.
        /// </summary>
        /// <param name="airport">The airport variation object to delete.</param>
        /// <returns></returns>
        public bool removeAirportVariation (AirportVariations airport)
        {
            Variation airportVariation = new Variation();

            return airportVariation.DeleteVariation(airport);
        }

        /// <summary>
        /// Add a new variation from db.
        /// </summary>
        /// <param name="airport">The airport variation object to add.</param>
        /// <returns></returns>
        public bool AddAirportVariation (AirportVariations airport)
        {
            Variation airportVariation = new Variation();

            return airportVariation.AddNewVariation(airport);
        }
    }
}
