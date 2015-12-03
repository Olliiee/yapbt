namespace Org.Strausshome.Yapbt.YapbtEditor
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AirportGroup = new System.Windows.Forms.GroupBox();
            this.OpenAirport = new System.Windows.Forms.Button();
            this.openBglXmlFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.AirportGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // AirportGroup
            // 
            this.AirportGroup.Controls.Add(this.OpenAirport);
            this.AirportGroup.Location = new System.Drawing.Point(12, 12);
            this.AirportGroup.Name = "AirportGroup";
            this.AirportGroup.Size = new System.Drawing.Size(89, 83);
            this.AirportGroup.TabIndex = 1;
            this.AirportGroup.TabStop = false;
            this.AirportGroup.Text = "Airport";
            // 
            // OpenAirport
            // 
            this.OpenAirport.Image = global::Org.Strausshome.Yapbt.YapbtEditor.Properties.Resources.airliner;
            this.OpenAirport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.OpenAirport.Location = new System.Drawing.Point(6, 19);
            this.OpenAirport.Name = "OpenAirport";
            this.OpenAirport.Size = new System.Drawing.Size(75, 57);
            this.OpenAirport.TabIndex = 0;
            this.OpenAirport.Text = "Open airport";
            this.OpenAirport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.OpenAirport.UseVisualStyleBackColor = true;
            this.OpenAirport.Click += new System.EventHandler(this.OpenAirport_Click);
            // 
            // openBglXmlFileDialog
            // 
            this.openBglXmlFileDialog.Filter = "XML files|*.xml|BGL files|*.bgl";
            this.openBglXmlFileDialog.Title = "Open BGL file";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 418);
            this.Controls.Add(this.AirportGroup);
            this.Name = "MainWindow";
            this.Text = "YAPBT- Editor";
            this.AirportGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AirportGroup;
        private System.Windows.Forms.Button OpenAirport;
        private System.Windows.Forms.OpenFileDialog openBglXmlFileDialog;
    }
}

