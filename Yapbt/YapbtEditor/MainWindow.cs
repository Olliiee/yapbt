using System.IO;
using System.Windows.Forms;
using Org.Strausshome.Yapbt.Codes;

namespace Org.Strausshome.Yapbt.YapbtEditor
{
    public partial class MainWindow : Form
    {
        private Objects.Fields fields = new Objects.Fields();

        public MainWindow()
        {
            InitializeComponent();

            fields.Config = new YapbtHandle.Configuration();
        }

        /// <summary>
        /// Opens the airport and variation selection form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenAirport_Click(object sender, System.EventArgs e)
        {
            AirportSelection airportSelector = new AirportSelection();
            if (airportSelector.ShowDialog(this) == DialogResult.OK)
            {
                bool addNewVariation = airportSelector.AddNewVariation;
                ReturnCodes.FsVersion code = airportSelector.Code;
                string icaoCode = airportSelector.IcaoCode;
                string variatioName = airportSelector.VariatioName;

                // Ok load the bgl file and covert it.
                if (openBglXmlFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\temp"))
                    {
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\temp");
                    }

                    DataReader.ReadBglData bglReader = new DataReader.ReadBglData();

                    if (Path.GetExtension(openBglXmlFileDialog.FileName).ToLower() == ".xml")
                    {
                        if (bglReader.ConvertAndReadBgl(openBglXmlFileDialog.FileName) == ReturnCodes.Codes.Ok)
                        {
                            MessageBox.Show("Ok");
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                    else if (Path.GetExtension(openBglXmlFileDialog.FileName).ToLower() == ".bgl")
                    {
                        if (bglReader.ConvertAndReadBgl(this.fields.Config.ReadConfig("bgltool"), openBglXmlFileDialog.FileName, "temp\temp.xml") == ReturnCodes.Codes.Error)
                        {
                            MessageBox.Show("Ok");
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                }
            }
        }
    }
}
