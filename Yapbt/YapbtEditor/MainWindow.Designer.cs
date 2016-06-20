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
            this.setBglTool = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.CurrentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.YapbtBrowser = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveNewPath = new System.Windows.Forms.Button();
            this.AddNewPath = new System.Windows.Forms.Button();
            this.AirportGroup.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // setBglTool
            // 
            this.setBglTool.Filter = "BGL Converter|*.exe";
            this.setBglTool.Title = "Set BGL converter tool";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.CurrentStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 581);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(950, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel1.Text = "Status: ";
            // 
            // CurrentStatusLabel
            // 
            this.CurrentStatusLabel.Name = "CurrentStatusLabel";
            this.CurrentStatusLabel.Size = new System.Drawing.Size(17, 17);
            this.CurrentStatusLabel.Text = "--";
            // 
            // YapbtBrowser
            // 
            this.YapbtBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.YapbtBrowser.IsWebBrowserContextMenuEnabled = false;
            this.YapbtBrowser.Location = new System.Drawing.Point(12, 101);
            this.YapbtBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.YapbtBrowser.Name = "YapbtBrowser";
            this.YapbtBrowser.ScriptErrorsSuppressed = true;
            this.YapbtBrowser.Size = new System.Drawing.Size(926, 477);
            this.YapbtBrowser.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveNewPath);
            this.groupBox1.Controls.Add(this.AddNewPath);
            this.groupBox1.Location = new System.Drawing.Point(108, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 83);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editor";
            // 
            // saveNewPath
            // 
            this.saveNewPath.Enabled = false;
            this.saveNewPath.Image = global::Org.Strausshome.Yapbt.YapbtEditor.Properties.Resources.save;
            this.saveNewPath.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveNewPath.Location = new System.Drawing.Point(124, 20);
            this.saveNewPath.Name = "saveNewPath";
            this.saveNewPath.Size = new System.Drawing.Size(83, 57);
            this.saveNewPath.TabIndex = 2;
            this.saveNewPath.Text = "Save the path";
            this.saveNewPath.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveNewPath.UseVisualStyleBackColor = true;
            this.saveNewPath.Click += new System.EventHandler(this.saveNewPath_Click);
            // 
            // AddNewPath
            // 
            this.AddNewPath.Enabled = false;
            this.AddNewPath.Image = global::Org.Strausshome.Yapbt.YapbtEditor.Properties.Resources.new_routes;
            this.AddNewPath.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddNewPath.Location = new System.Drawing.Point(6, 19);
            this.AddNewPath.Name = "AddNewPath";
            this.AddNewPath.Size = new System.Drawing.Size(112, 57);
            this.AddNewPath.TabIndex = 1;
            this.AddNewPath.Text = "Create a new path";
            this.AddNewPath.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AddNewPath.UseVisualStyleBackColor = true;
            this.AddNewPath.Click += new System.EventHandler(this.AddNewPath_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 603);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.YapbtBrowser);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.AirportGroup);
            this.Name = "MainWindow";
            this.Text = "YAPBT- Editor";
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.AirportGroup.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox AirportGroup;
        private System.Windows.Forms.Button OpenAirport;
        private System.Windows.Forms.OpenFileDialog openBglXmlFileDialog;
        private System.Windows.Forms.OpenFileDialog setBglTool;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel CurrentStatusLabel;
        private System.Windows.Forms.WebBrowser YapbtBrowser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddNewPath;
        private System.Windows.Forms.Button saveNewPath;
    }
}

