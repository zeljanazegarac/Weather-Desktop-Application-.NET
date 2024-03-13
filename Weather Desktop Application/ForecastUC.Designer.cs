namespace Weather_Desktop_Application
{
    partial class ForecastUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picWeatherIcon = new System.Windows.Forms.PictureBox();
            this.labDT = new System.Windows.Forms.Label();
            this.labMainWeather = new System.Windows.Forms.Label();
            this.labWeatherDescription = new System.Windows.Forms.Label();
            this.labTemp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picWeatherIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picWeatherIcon
            // 
            this.picWeatherIcon.Location = new System.Drawing.Point(3, 3);
            this.picWeatherIcon.Name = "picWeatherIcon";
            this.picWeatherIcon.Size = new System.Drawing.Size(61, 54);
            this.picWeatherIcon.TabIndex = 0;
            this.picWeatherIcon.TabStop = false;
            // 
            // labDT
            // 
            this.labDT.AutoSize = true;
            this.labDT.Font = new System.Drawing.Font("Constantia", 10F);
            this.labDT.Location = new System.Drawing.Point(70, 3);
            this.labDT.Name = "labDT";
            this.labDT.Size = new System.Drawing.Size(53, 17);
            this.labDT.TabIndex = 1;
            this.labDT.Text = "Sunday";
            // 
            // labMainWeather
            // 
            this.labMainWeather.AutoSize = true;
            this.labMainWeather.Font = new System.Drawing.Font("Constantia", 10F);
            this.labMainWeather.Location = new System.Drawing.Point(70, 20);
            this.labMainWeather.Name = "labMainWeather";
            this.labMainWeather.Size = new System.Drawing.Size(40, 17);
            this.labMainWeather.TabIndex = 2;
            this.labMainWeather.Text = "Clear";
            // 
            // labWeatherDescription
            // 
            this.labWeatherDescription.AutoSize = true;
            this.labWeatherDescription.Font = new System.Drawing.Font("Constantia", 10F);
            this.labWeatherDescription.Location = new System.Drawing.Point(70, 37);
            this.labWeatherDescription.Name = "labWeatherDescription";
            this.labWeatherDescription.Size = new System.Drawing.Size(80, 17);
            this.labWeatherDescription.TabIndex = 3;
            this.labWeatherDescription.Text = "Description";
            // 
            // labTemp
            // 
            this.labTemp.AutoSize = true;
            this.labTemp.Font = new System.Drawing.Font("Constantia", 10F);
            this.labTemp.Location = new System.Drawing.Point(179, 3);
            this.labTemp.Name = "labTemp";
            this.labTemp.Size = new System.Drawing.Size(87, 17);
            this.labTemp.TabIndex = 4;
            this.labTemp.Text = "Temperature";
            // 
            // ForecastUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labTemp);
            this.Controls.Add(this.labWeatherDescription);
            this.Controls.Add(this.labMainWeather);
            this.Controls.Add(this.labDT);
            this.Controls.Add(this.picWeatherIcon);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ForecastUC";
            this.Size = new System.Drawing.Size(279, 64);
            ((System.ComponentModel.ISupportInitialize)(this.picWeatherIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox picWeatherIcon;
        public System.Windows.Forms.Label labMainWeather;
        public System.Windows.Forms.Label labWeatherDescription;
        public System.Windows.Forms.Label labDT;
        public System.Windows.Forms.Label labTemp;
    }
}
