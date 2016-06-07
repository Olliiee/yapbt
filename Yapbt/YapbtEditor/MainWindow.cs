using System.IO;
using System.Windows.Forms;
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

        private void MainWindow_Shown(object sender, System.EventArgs e)
        {
            string dbValues = this.fields.Config.ReadConfig("bgltool");
            if (dbValues == string.Empty || dbValues == null)
            {
                if (setBglTool.ShowDialog() == DialogResult.OK)
                {
                    this.fields.Config.SetConfig("bgltool", setBglTool.FileName);
                }
            }

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
                ReturnCodes.FsVersion code = airportSelector.Code;
                string icaoCode = airportSelector.IcaoCode;
                string variatioName = airportSelector.VariatioName;

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

                    if (bglReader.ConvertAndResetDb(this.fields.Config.ReadConfig("bgltool"), openBglXmlFileDialog.FileName, Directory.GetCurrentDirectory() + "\\temp\\temp.xml") == ReturnCodes.Codes.ResetOk)
                    {
                        CurrentStatusLabel.Text = "Loading new stuff ...";
                        MessageBox.Show(msg.CreateMessage(bglReader.StoreParkingPos()));
                        MessageBox.Show(msg.CreateMessage(bglReader.StoreTaxiway()));
                        MessageBox.Show(msg.CreateMessage(bglReader.StorePoints()));
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }

                    this.CreateMap();
                }
            }
        }

        /// <summary>
        /// Load the gates into the map.
        /// </summary>
        private void CreateMap()
        {
            TempDb tempData = new TempDb();
            var data = tempData.GetParkingPositions();

            foreach (var parking in data)
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
                    MessageBox.Show(null, "Error! Unable to send the taxiways.", "Error: Internet connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        #endregion Private Methods
    }
}