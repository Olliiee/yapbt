using System.Windows.Forms;

namespace Org.Strausshome.Yapbt.YapbtEditor
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens the airport and variation selection form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenAirport_Click(object sender, System.EventArgs e)
        {
            AirportSelection airportSelector = new AirportSelection();
            airportSelector.ShowDialog();
        }
    }
}
