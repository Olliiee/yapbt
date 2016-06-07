using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Org.Strausshome.Yapbt.BglFileHandle;
using Org.Strausshome.Yapbt.Codes;
using Org.Strausshome.Yapbt.DataConnection;

namespace Org.Strausshome.Yapbt.DataReader
{
    /// <summary>
    /// This class reads all BGL/XML data and store it into the sqlite database.
    /// </summary>
    public class ReadBglData
    {
        #region Private Fields

        private Fields fields = new Fields();

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Converts and reads a bgl file.
        /// </summary>
        /// <param name="inputFilePath">Location of the bgl file.</param>
        /// <param name="outputFilePath">Location of the XML file.</param>
        /// <param name="bglToolPath">Location of the bgl converter tool.</param>
        /// <returns>Returns a code about the status.</returns>
        public ReturnCodes.Codes ConvertAndResetDb(string bglToolPath, string inputFilePath, string outputFilePath)
        {
            BglFile bgl = new BglFile();

            this.fields.inputFilePath = inputFilePath;
            this.fields.BglToolPath = bglToolPath;
            this.fields.outputFilePath = outputFilePath;

            ReturnCodes.Codes code = ReturnCodes.Codes.Ok;

            if (Path.GetExtension(inputFilePath).ToLower() == ".bgl")
            {
                code = bgl.ConevertBglFile(this.fields.BglToolPath, this.fields.inputFilePath, this.fields.outputFilePath);
            }

            if (code == ReturnCodes.Codes.Ok)
            {
                ResetDatabase dbReset = new ResetDatabase();

                code = dbReset.ResetTempDatabase();
            }

            return code;
        }


        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Saving all points of the bgl file into the db.
        /// </summary>
        /// <returns>Returns a code about the status.</returns>
        public ReturnCodes.Codes StorePoints()
        {
            // Load the xml file.
            XDocument xmlDoc = XDocument.Load(this.fields.outputFilePath);

            IEnumerable<XElement> TaxiwayPoints = null;

            try
            {
                // Get all taxiway points.
                TaxiwayPoints =
                            from el in xmlDoc
                            .Descendants("FSData")
                            .Descendants("Airport")
                            .Descendants("TaxiwayPoint")
                            select el;
            }
            catch (Exception)
            {
                return ReturnCodes.Codes.XmlError;
            }

            try
            {
                using (var db = new YapbtDbEntities())
                {
                    foreach (XElement TaxiPoint in TaxiwayPoints)
                    {
                        var point = new TempPoint();

                        point.Index = Convert.ToInt64(TaxiPoint.Attribute("index").Value);

                        // Converting the latitude and longitude to string and double to avoid
                        // system culture problems.
                        string txt = TaxiPoint.Attribute("lat").Value.ToString(CultureInfo.InvariantCulture);

                        //back to a double
                        point.Latitude = double.Parse(txt, CultureInfo.InvariantCulture);

                        txt = TaxiPoint.Attribute("lon").Value.ToString(CultureInfo.InvariantCulture);

                        //back to a double
                        point.Longitude = double.Parse(txt, CultureInfo.InvariantCulture);

                        db.TempPoint.Add(point);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                return ReturnCodes.Codes.ImportError;
            }

            return ReturnCodes.Codes.ImportPointOk;
        }

        /// <summary>
        /// Saving all taxiways of the bgl file into the db.
        /// </summary>
        /// <returns>Returns a code about the status.</returns>
        public ReturnCodes.Codes StoreTaxiway()
        {
            // Load the xml file.
            XDocument xmlDoc = XDocument.Load(this.fields.outputFilePath);

            IEnumerable<XElement> TaxiwayPaths = null;

            try
            {
                // Get all taxiway paths.
                TaxiwayPaths =
                            from el in xmlDoc
                            .Elements("FSData")
                            .Elements("Airport")
                            .Elements("TaxiwayPath")
                            select el;
            }
            catch (Exception)
            {
                // Something went wrong, returning an error code.
                return ReturnCodes.Codes.XmlError;
            }

            try
            {
                using (var db = new YapbtDbEntities())
                {
                    // Reading all xml elements add the data to an object and save into the sqlite db.
                    foreach (XElement TaxiwayPath in TaxiwayPaths)
                    {
                        var path = new TempTaxiway();

                        path.FromPoint = Convert.ToInt64(TaxiwayPath.Attribute("start").Value);
                        path.ToPoint = Convert.ToInt64(TaxiwayPath.Attribute("end").Value);

                        db.TempTaxiway.Add(path);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                // Something went wrong, returning an error code.
                return ReturnCodes.Codes.ImportError;
            }

            return ReturnCodes.Codes.ImportTaxiwayOk;
        }

        #endregion Private Methods

        #region Private Methods

        /// <summary>
        /// Saving all parking positions of the bgl file into the db.
        /// </summary>
        /// <returns>Returns a code about the status.</returns>
        public ReturnCodes.Codes StoreParkingPos()
        {
            // Load the xml file.
            XDocument xmlDoc = XDocument.Load(this.fields.outputFilePath);

            IEnumerable<XElement> ParkingPositions = null;

            try
            {
                // Get all parking positions.
                ParkingPositions =
                            from el in xmlDoc
                            .Descendants("FSData")
                            .Descendants("Airport")
                            .Descendants("TaxiwayParking")
                            select el;
            }
            catch (Exception)
            {
                // Something went wrong, returning an error code.
                return ReturnCodes.Codes.XmlError;
            }

            try
            {
                using (var db = new YapbtDbEntities())
                {
                    // Reading all xml elements add the data to an object and save into the sqlite db.
                    foreach (XElement ParkingPosition in ParkingPositions)
                    {
                        TempParking parking = new TempParking();

                        parking.Index = Convert.ToInt64(ParkingPosition.Attribute("index").Value);
                        parking.Name = ParkingPosition.Attribute("name").Value;
                        parking.Number = Convert.ToInt64(ParkingPosition.Attribute("number").Value);

                        // Converting the latitude and longitude to string and double to avoid
                        // system culture problems.
                        string txt = ParkingPosition.Attribute("lat").Value.ToString(CultureInfo.InvariantCulture);

                        //back to a double
                        parking.Latitude = double.Parse(txt, CultureInfo.InvariantCulture);

                        txt = ParkingPosition.Attribute("lon").Value.ToString(CultureInfo.InvariantCulture);

                        //back to a double
                        parking.Longitude = double.Parse(txt, CultureInfo.InvariantCulture);

                        db.TempParking.Add(parking);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                // Something went wrong, returning an error code.
                return ReturnCodes.Codes.ImportError;
            }

            return ReturnCodes.Codes.ImportParkingPosOk;
        }

        #endregion Private Methods
    }
}