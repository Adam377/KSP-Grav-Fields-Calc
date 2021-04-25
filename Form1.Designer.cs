namespace KSPGravFieldV2
{
    partial class Form1
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
            this.planetMoonSelectLabel = new System.Windows.Forms.Label();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.heightLabel = new System.Windows.Forms.Label();
            this.calcGFSButton = new System.Windows.Forms.Button();
            this.gravFieldAnswerTextBox = new System.Windows.Forms.TextBox();
            this.bodyComboBox = new System.Windows.Forms.ComboBox();
            this.calcSpeedButton = new System.Windows.Forms.Button();
            this.CalcGeoStationaryHeightButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // planetMoonSelectLabel
            // 
            this.planetMoonSelectLabel.AutoSize = true;
            this.planetMoonSelectLabel.Location = new System.Drawing.Point(120, 19);
            this.planetMoonSelectLabel.Name = "planetMoonSelectLabel";
            this.planetMoonSelectLabel.Size = new System.Drawing.Size(102, 13);
            this.planetMoonSelectLabel.TabIndex = 1;
            this.planetMoonSelectLabel.Text = "Select Planet/Moon";
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(13, 49);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(100, 20);
            this.heightTextBox.TabIndex = 2;
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(120, 53);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(129, 13);
            this.heightLabel.TabIndex = 3;
            this.heightLabel.Text = "Height Above Surface (m)";
            // 
            // calcGFSButton
            // 
            this.calcGFSButton.Location = new System.Drawing.Point(12, 106);
            this.calcGFSButton.Name = "calcGFSButton";
            this.calcGFSButton.Size = new System.Drawing.Size(117, 23);
            this.calcGFSButton.TabIndex = 4;
            this.calcGFSButton.Text = "Calculate Grav Field Strength";
            this.calcGFSButton.UseVisualStyleBackColor = true;
            this.calcGFSButton.Click += new System.EventHandler(this.CalcGFSButton_Click);
            // 
            // gravFieldAnswerTextBox
            // 
            this.gravFieldAnswerTextBox.Location = new System.Drawing.Point(12, 164);
            this.gravFieldAnswerTextBox.Name = "gravFieldAnswerTextBox";
            this.gravFieldAnswerTextBox.ReadOnly = true;
            this.gravFieldAnswerTextBox.Size = new System.Drawing.Size(229, 20);
            this.gravFieldAnswerTextBox.TabIndex = 5;
            this.gravFieldAnswerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bodyComboBox
            // 
            this.bodyComboBox.FormattingEnabled = true;
            this.bodyComboBox.Location = new System.Drawing.Point(14, 16);
            this.bodyComboBox.Name = "bodyComboBox";
            this.bodyComboBox.Size = new System.Drawing.Size(99, 21);
            this.bodyComboBox.TabIndex = 6;
            this.bodyComboBox.SelectedIndexChanged += new System.EventHandler(this.bodyComboBox_SelectedIndexChanged_1);
            // 
            // calcSpeedButton
            // 
            this.calcSpeedButton.Location = new System.Drawing.Point(135, 106);
            this.calcSpeedButton.Name = "calcSpeedButton";
            this.calcSpeedButton.Size = new System.Drawing.Size(107, 23);
            this.calcSpeedButton.TabIndex = 7;
            this.calcSpeedButton.Text = "Calculate Speed";
            this.calcSpeedButton.UseVisualStyleBackColor = true;
            this.calcSpeedButton.Click += new System.EventHandler(this.calcSpeedButton_Click);
            // 
            // CalcGeoStationaryHeightButton
            // 
            this.CalcGeoStationaryHeightButton.Location = new System.Drawing.Point(13, 135);
            this.CalcGeoStationaryHeightButton.Name = "CalcGeoStationaryHeightButton";
            this.CalcGeoStationaryHeightButton.Size = new System.Drawing.Size(228, 23);
            this.CalcGeoStationaryHeightButton.TabIndex = 8;
            this.CalcGeoStationaryHeightButton.Text = "Geostationary Height Above Surface";
            this.CalcGeoStationaryHeightButton.UseVisualStyleBackColor = true;
            this.CalcGeoStationaryHeightButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.CalcGeoStationaryHeightButton);
            this.Controls.Add(this.calcSpeedButton);
            this.Controls.Add(this.bodyComboBox);
            this.Controls.Add(this.gravFieldAnswerTextBox);
            this.Controls.Add(this.calcGFSButton);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.planetMoonSelectLabel);
            this.Name = "Form1";
            this.Text = "KSP Grav Field Calc";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label planetMoonSelectLabel;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Button calcGFSButton;
        private System.Windows.Forms.TextBox gravFieldAnswerTextBox;
        private System.Windows.Forms.ComboBox bodyComboBox;
        private System.Windows.Forms.Button calcSpeedButton;
        private System.Windows.Forms.Button CalcGeoStationaryHeightButton;
    }
}

