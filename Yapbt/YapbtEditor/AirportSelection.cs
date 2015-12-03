using System;
using System.Windows.Forms;
using Org.Strausshome.Yapbt.Codes;
using Org.Strausshome.Yapbt.YapbtHandle;

namespace Org.Strausshome.Yapbt.YapbtEditor
{
    /// <summary>
    /// Let the user select an airport and select a variation or add a new one.
    /// </summary>
    public partial class AirportSelection : Form
    {
        #region Public Constructors

        /// <summary>
        /// </summary>
        public AirportSelection()
        {
            InitializeComponent();

            this.Code = ReturnCodes.FsVersion.None;
            this.AddNewVariation = false;
        }

        #endregion Public Constructors

        #region Public Properties

        public bool AddNewVariation { get; set; }
        public ReturnCodes.FsVersion Code { get; set; }
        public string IcaoCode { get; set; }
        public string VariatioName { get; set; }

        #endregion Public Properties

        #region Private Methods

        /// <summary>
        /// Closed the window and return some data like ICAO code, variation name if the user wants
        /// to add a new one and which FS version.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">     </param>
        private void CloseWindow_Click(object sender, EventArgs e)
        {
            // Return a new variation.
            if (NewVariationName.Text != "Enter a new variation name"
                && NewVariationName.Text != ""
                && VariationList.Text == "Select a variation")
            {
                // A FS version was selected?
                if (Code != ReturnCodes.FsVersion.None)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select the Flight Simulator version (FS9 or FSX)."
                        , "Please select"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Return an exisiting variation.
            else if (NewVariationName.Text == "Enter a new variation name"
                && VariationList.Text != ""
                && VariationList.Text != "Select a variation")
            {
                this.AddNewVariation = false;
                this.Close();
            }

            // It's not clear what the user has selected.
            else if (NewVariationName.Text != "Enter a new variation name"
                && VariationList.Text != "Select a variation")
            {
                DialogResult result = MessageBox.Show("Yes: You want to add a new variation. No: You want to use the existing one."
                    , "Please select", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                // Add a new variation
                if (result == DialogResult.Yes)
                {
                    this.VariatioName = NewVariationName.Text;
                    this.AddNewVariation = true;
                    this.Close();
                }

                // Use an existing variation.
                else if (result == DialogResult.No)
                {
                    this.VariatioName = VariationList.Text;
                    this.AddNewVariation = false;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please add a new airport variation or select an existing one."
                        , "Please select"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// if an ICAO code was selected, enable the other fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">     </param>
        private void IcaoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable the fields.
            VariationList.Enabled = true;
            VariationList.Items.Clear();
            NewVariationBox.Enabled = true;

            // Load all variations for this ICAO code.
            Variation variation = new Variation();
            var loadedVariationList = variation.VariationsByAirport(IcaoList.Text);

            // Add the variations to the list.
            foreach (var item in loadedVariationList)
            {
                VariationList.Items.Add(item.variationname);
            }

            this.IcaoCode = IcaoList.Text;
        }

        /// <summary>
        /// Remove the standart text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">     </param>
        private void NewVariationName_Click(object sender, EventArgs e)
        {
            if (NewVariationName.Text == "Enter a new variation name")
            {
                NewVariationName.Text = string.Empty;
            }
        }

        /// <summary>
        /// Set the return code to Fs9.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbFS9_CheckedChanged(object sender, EventArgs e)
        {
            Code = ReturnCodes.FsVersion.Fs9;
        }

        /// <summary>
        /// Set the return code to FsX.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbFSX_CheckedChanged(object sender, EventArgs e)
        {
            Code = ReturnCodes.FsVersion.FsX;
        }

        #endregion Private Methods
    }
}