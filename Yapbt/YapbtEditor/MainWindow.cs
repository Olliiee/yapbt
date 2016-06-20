﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Org.Strausshome.Yapbt.Codes;
using Org.Strausshome.Yapbt.Messages;
using Org.Strausshome.Yapbt.YapbtHandle;

namespace Org.Strausshome.Yapbt.YapbtEditor
{
    public partial class MainWindow : Form
    {
        #region Private Fields

        private Objects.Fields fields = new Objects.Fields();

        #endregion Private Fields

        #region Public Constructors

        public MainWindow()
        {
            InitializeComponent();

            this.fields.Config = new YapbtHandle.Configuration();
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Load the gates into the map.
        /// </summary>
        private void CreateMap()
        {
            TempDb tempData = new TempDb();

            // Let's start with the parking positions of this airport.
            var parkingData = tempData.GetParkingPositions();

            CurrentStatusLabel.Text = "Drawing the map.";
            Application.DoEvents();
            // TODO The same loading for the parking path.
            foreach (var parking in parkingData)
            {
                // Create an object array and add the parking position data.
                object[] args = { parking.Latitude, parking.Longitude, parking.Name + " " + parking.Number };

                try
                {
                    // Invoke into the addGate javascript.
                    YapbtBrowser.Document.InvokeScript("addGate", args);
                }
                catch
                {
                    MessageBox.Show(null, "Error! Unable to send the parking positions.",
                        "Error: Internet connection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    break;
                }
            }

            // Load the taxiways of this airport.
            var taxiwayData = tempData.GetTaxiways();

            foreach (var taxiway in taxiwayData)
            {
                // Create an object array and add the parking position data.
                object[] args = { taxiway.FromPoint.Latitude, taxiway.FromPoint.Longitude, taxiway.ToPoint.Latitude, taxiway.ToPoint.Longitude };
                
                try
                {
                    // Invoke into the addGate javascript.
                    YapbtBrowser.Document.InvokeScript("addTaxiway", args);
                    
                }
                catch
                {
                    MessageBox.Show(null, "Error! Unable to send the taxiway positions.",
                        "Error: Internet connection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    break;
                }
            }

            // Load the taxiways of this airport for parking positions only.
            var parkingwayData = tempData.GetParkingways();

            foreach (var taxiway in parkingwayData)
            {
                // Create an object array and add the parking position data.
                object[] args = { taxiway.FromPoint.Latitude, taxiway.FromPoint.Longitude, taxiway.ParkingPoint.Latitude, taxiway.ParkingPoint.Longitude };

                try
                {
                    // Invoke into the addGate javascript.
                    YapbtBrowser.Document.InvokeScript("addTaxiway", args);

                }
                catch
                {
                    MessageBox.Show(null, "Error! Unable to send the taxiway positions.",
                        "Error: Internet connection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    break;
                }
            }

            // Invoke into the FitToBounce javascript.
            YapbtBrowser.Document.InvokeScript("FitToBounce");
        }

        private void MainWindow_Shown(object sender, System.EventArgs e)
        {
            // First check the connection
            if (this.fields.Config.CheckDbConnection() == false)
            {
                MessageBox.Show("Unable to open the database connection. Please make sure, that the Ypabtdb.sqlite file is available in the SQLite folder.",
                    "Error: Unable to open database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            // Still there? Let's go on.
            // Check if bgl tool converter path is set.
            string dbValues = this.fields.Config.ReadConfig("bgltool");
            if (dbValues == string.Empty || dbValues == null)
            {
                if (setBglTool.ShowDialog() == DialogResult.OK)
                {
                    this.fields.Config.SetConfig("bgltool", setBglTool.FileName);
                }
            }

            // Check for the maps URL.
            dbValues = this.fields.Config.ReadConfig("mapsurl");
            if (dbValues != string.Empty && dbValues != null)
            {
                YapbtBrowser.Navigate(dbValues);
            }
        }

        /// <summary>
        /// Opens the airport and variation selection form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">     </param>
        private void OpenAirport_Click(object sender, System.EventArgs e)
        {
            AirportSelection airportSelector = new AirportSelection();
            MsgCodes msg = new MsgCodes();

            // open the dialog and check the result.
            if (airportSelector.ShowDialog(this) == DialogResult.OK)
            {
                bool addNewVariation = airportSelector.AddNewVariation;
                ReturnCodes.FsVersion fsVersion = airportSelector.Code;
                string icaoCode = airportSelector.IcaoCode;
                string variatioName = airportSelector.VariatioName;

                // Center the view to the airport.
                this.SetNewAirportCenter(icaoCode);

                // Ok load the bgl file and covert it.
                if (openBglXmlFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CurrentStatusLabel.Text = "Cleaning up old stuff ...";

                    if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\temp"))
                    {
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\temp");
                    }

                    DataReader.ReadBglData bglReader = new DataReader.ReadBglData();

                    CurrentStatusLabel.Text = "Resetting temp database ...";

                    ReturnCodes.Codes code = bglReader.ConvertAndResetDb(this.fields.Config.ReadConfig("bgltool"), openBglXmlFileDialog.FileName, Directory.GetCurrentDirectory() + "\\temp\\temp.xml");

                    if (code == ReturnCodes.Codes.ResetOk)
                    {
                        CurrentStatusLabel.Text = "Loading new stuff ...";

                        MessageBox.Show(msg.CreateMessage(bglReader.StoreParkingPos()), "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CurrentStatusLabel.Text = "Loading taxiways.";
                        Application.DoEvents();

                        MessageBox.Show(msg.CreateMessage(bglReader.StoreTaxiway()), "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CurrentStatusLabel.Text = "Loading moving points.";
                        Application.DoEvents();

                        MessageBox.Show(msg.CreateMessage(bglReader.StorePoints()), "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(code.ToString());
                        
                        
                    }

                    this.CreateMap();
                }
            }
        }

        /// <summary>
        /// Set a new center to the selected airport.
        /// </summary>
        /// <param name="icaoCode">The code of the airport.</param>
        private void SetNewAirportCenter(string icaoCode)
        {
            AirportData airportData = new AirportData();

            var airport = airportData.GetAirportByCode(icaoCode);

            if (airport != null)
            {
                object[] positions = { airport.latitude, airport.longitude };
                YapbtBrowser.Document.InvokeScript("setNewView", positions);
            }
        }

        #endregion Private Methods
    }
}