using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Org.Strausshome.Yapbt.BglFileHandle;
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
        /// 
        /// </summary>
        /// <param name="bglFilePath"></param>
        /// <param name="xmlFilePath"></param>
        /// <param name="bglToolPath"></param>
        public void ConvertAndReadBgl(string bglFilePath, string xmlFilePath, string bglToolPath)
        {
            BglFile bgl = new BglFile();

            this.fields.BglFilePath = bglFilePath;
            this.fields.BglToolPath = bglToolPath;
            this.fields.XmlFilePath = xmlFilePath;

            if (bgl.ConevertBglFile(this.fields.BglToolPath, this.fields.BglFilePath, this.fields.XmlFilePath))
            {
                ResetDatabase dbReset = new ResetDatabase();

                if (dbReset.ResetTempDatabase() == Codes.ReturnCodes.Codes.ResetOk)
                {
                    this.StoreParkingPos();
                    this.StoreTaxiway();
                    this.StorePoints();
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void StorePoints()
        {
            XDocument xmlDoc = XDocument.Load(this.fields.XmlFilePath);

            IEnumerable<XElement> TaxiwayPoints = null;

            try
            {
                TaxiwayPoints =
                            from el in xmlDoc.Descendants("FSData").Descendants("Airport").Descendants("TaxiwayPoint")
                            select el;
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                using (var db = new YapbtDbEntities())
                {
                    foreach (XElement TaxiPoint in TaxiwayPoints)
                    {
                        var point = new TempPoint();

                        point.Bglid = Convert.ToInt64(TaxiPoint.Attribute("index").Value);
                        point.Latitude = Convert.ToDouble(TaxiPoint.Attribute("lat").Value);
                        point.Longitude = Convert.ToDouble(TaxiPoint.Attribute("lon").Value);

                        db.TempPoint.Add(point);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void StoreTaxiway()
        {
            XDocument xmlDoc = XDocument.Load(this.fields.XmlFilePath);

            IEnumerable<XElement> TaxiwayPaths = null;

            try
            {
                TaxiwayPaths =
                            from el in xmlDoc.Descendants("FSData").Descendants("Airport").Descendants("TaxiwayPath")
                            select el;
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                using (var db = new YapbtDbEntities())
                {
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
                throw;
            }
        }

        #endregion Private Methods

        #region Private Methods

        /// <summary>
        /// Saving all parking positions of the bgl file into the db.
        /// </summary>
        /// <param name="doc">The XML file.</param>
        /// <returns></returns>
        private void StoreParkingPos()
        {
            XDocument xmlDoc = XDocument.Load(this.fields.XmlFilePath);

            IEnumerable<XElement> ParkingPositions = null;

            try
            {
                ParkingPositions =
                            from el in xmlDoc.Descendants("FSData").Descendants("Airport").Descendants("TaxiwayParking")
                            select el;
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                using (var db = new YapbtDbEntities())
                {
                    foreach (XElement ParkingPosition in ParkingPositions)
                    {
                        TempParking parking = new TempParking();

                        parking.Bglid = Convert.ToInt64(ParkingPosition.Attribute("index").Value);
                        parking.Name = ParkingPosition.Attribute("name").Value;
                        parking.Number = Convert.ToInt64(ParkingPosition.Attribute("number").Value);
                        parking.Latitude = Convert.ToDouble(ParkingPosition.Attribute("lat").Value);
                        parking.Longitude = Convert.ToDouble(ParkingPosition.Attribute("lon").Value);

                        db.TempParking.Add(parking);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Private Methods
    }
}