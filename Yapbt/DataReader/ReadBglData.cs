using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using org.strausshome.yapbt.DataConnection;

namespace org.strausshome.yapbt.DataReader
{
    /// <summary>
    /// This class reads all BGL/XML data and store it into the sqlite database.
    /// </summary>
    public class ReadBglData
    {
        #region Private Fields

        private Fields fields = new Fields();

        #endregion Private Fields

        #region Public Constructors

        public ReadBglData(string filePath)
        {
            this.fields.FilePath = filePath;
        }

        #endregion Public Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private void StoreParkingPos(XDocument doc)
        {
            IEnumerable<XElement> ParkingPositions =
                    from el in doc.Descendants("FSData").Descendants("Airport").Descendants("TaxiwayParking")
                    select el;
            using (var db = new YapbtDbEntities())
            {
                foreach (XElement ParkingPosition in ParkingPositions)
                {
                    AirportPositions position = new AirportPositions();

                    
                }
            }

            
            
        }
    }
}