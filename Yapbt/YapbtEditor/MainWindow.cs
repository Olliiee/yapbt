using System;
using System.IO;
using System.Windows.Forms;
using Org.Strausshome.Yapbt.Codes;
using Org.Strausshome.Yapbt.DataConnection;
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
            this.fields.Codes = new MsgCodes();
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Save the new airport variation to the sqlite db.
        /// </summary>
        /// <param name="variationName"></param>
        /// <param name="bglFileName">  </param>
        private void AddAirportVariationToDb(string variationName, string bglFileName, ReturnCodes.FsVersion code)
        {
            AirportVariations variation = new AirportVariations();
            Variation manageVariation = new Variation();

            variation.bglfile = bglFileName;
            variation.variationname = variationName;
            variation.flightsim = code.ToString();
            variation.airportid = this.fields.CurrentAirport.airportid;
            variation.Airport = this.fields.CurrentAirport;
            variation.cts = DateTime.Now;
            variation.variationid = Guid.NewGuid();

            if (manageVariation.AddNewVariation(variation))
            {
                MessageBox.Show("Airport variation saved.", "New airport variation"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);

                this.fields.CurrentVariation = variation;
                AddNewPath.Enabled = true;
            }
            else
            {
                MessageBox.Show("Unable to save the new variation.", "New airport variation"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                AddNewPath.Enabled = false;
            }
        }

        /// <summary>
        /// Enable the add a new path mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">     </param>
        private void AddNewPath_Click(object sender, System.EventArgs e)
        {
            // Focus and clear all overlays on the map.
            YapbtBrowser.Focus();
            YapbtBrowser.Document.InvokeScript("clearOverlays");
            YapbtBrowser.Document.InvokeScript("EnableNewPath");

            MessageBox.Show("Please double click a gate or parking position on the map."
                , "Select parking position"
                , MessageBoxButtons.OK
                , MessageBoxIcon.Information);

            SaveNewPath.Enabled = true;
        }

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
            YapbtBrowser.Focus();

            AddNewPath.Enabled = true;

            CurrentStatusLabel.Text = "Loading finished.";
            Application.DoEvents();
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

            // Still there? Let's go on. Check if bgl tool converter path is set.
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
            AirportData airportData = new AirportData();
            MsgCodes msg = new MsgCodes();

            // open the dialog and check the result.
            if (airportSelector.ShowDialog(this) == DialogResult.OK)
            {
                // Get the information by the airport selector form.
                bool addNewVariation = airportSelector.AddNewVariation;
                ReturnCodes.FsVersion fsVersion = airportSelector.Code;
                string icaoCode = airportSelector.IcaoCode;
                string variatioName = airportSelector.VariatioName;
                bool newVariation = airportSelector.AddNewVariation;

                // Get the current airport object from db.
                this.fields.CurrentAirport = airportData.GetAirportByCode(icaoCode);

                // Center the view to the airport.
                this.SetNewAirportCenter(this.fields.CurrentAirport);

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

                    // Insert the temp data if the return code is ok.
                    if (code == ReturnCodes.Codes.ResetOk)
                    {
                        this.StoreData(bglReader);

                        // Create the new variation.
                        if (newVariation)
                        {
                            this.AddAirportVariationToDb(variatioName, System.IO.Path.GetFileName(openBglXmlFileDialog.FileName), fsVersion);
                        }
                    }
                    else
                    {
                        MessageBoxData boxData = fields.Codes.CreateMessage(code);
                        MessageBox.Show(boxData.Message, boxData.Caption, boxData.Buttons, boxData.Icon);
                    }
                }
            }
        }

        /// <summary>
        /// Read the XML data by type and store in into the SQLite db.
        /// </summary>
        /// <param name="bglReader"></param>
        private void StoreData(DataReader.ReadBglData bglReader)
        {
            CurrentStatusLabel.Text = "Loading new stuff ...";

            bglReader.StoreParkingPos();

            CurrentStatusLabel.Text = "Loading taxiways.";
            Application.DoEvents();

            bglReader.StoreTaxiway();

            CurrentStatusLabel.Text = "Loading moving points.";
            Application.DoEvents();

            bglReader.StorePoints();

            // Only draw the map if all data is available.
            this.CreateMap();
        }

        /// <summary>
        /// Set a new center to the selected airport.
        /// </summary>
        /// <param name="airport">The airport object.</param>
        private void SetNewAirportCenter(Airport airport)
        {
            if (airport != null)
            {
                object[] positions = { airport.latitude, airport.longitude };
                YapbtBrowser.Document.InvokeScript("setNewView", positions);
            }
        }

        #endregion Private Methods

        private void saveNewPath_Click(object sender, EventArgs e)
        {
            string json = "";
            foreach (HtmlElement el in YapbtBrowser.Document.GetElementsByTagName("div"))
            {
                if (el.GetAttribute("id") == "json")
                {
                    json = el.InnerText;
                    YapbtBrowser.Document.InvokeScript("ResetPushBackPath");

                    // TODO YapbtHandle code clean up and review.
                }
            }
        }
    }
}