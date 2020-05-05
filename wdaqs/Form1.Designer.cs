namespace wdaqs
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
            this.control_box = new System.Windows.Forms.GroupBox();
            this.load_data_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.temp_box = new System.Windows.Forms.GroupBox();
            this.humidity_box = new System.Windows.Forms.GroupBox();
            this.barometric_box = new System.Windows.Forms.GroupBox();
            this.file_dialog = new System.Windows.Forms.OpenFileDialog();
            this.serial_ports = new System.Windows.Forms.ComboBox();
            this.temp_chart = new LiveCharts.WinForms.CartesianChart();
            this.humidity_chart = new LiveCharts.WinForms.CartesianChart();
            this.pressure_chart = new LiveCharts.WinForms.CartesianChart();
            this.control_box.SuspendLayout();
            this.temp_box.SuspendLayout();
            this.humidity_box.SuspendLayout();
            this.barometric_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // control_box
            // 
            this.control_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.control_box.Controls.Add(this.serial_ports);
            this.control_box.Controls.Add(this.load_data_btn);
            this.control_box.Controls.Add(this.stop_btn);
            this.control_box.Controls.Add(this.start_btn);
            this.control_box.Controls.Add(this.label1);
            this.control_box.Location = new System.Drawing.Point(13, 13);
            this.control_box.Name = "control_box";
            this.control_box.Size = new System.Drawing.Size(1600, 75);
            this.control_box.TabIndex = 0;
            this.control_box.TabStop = false;
            this.control_box.Text = "Controles";
            // 
            // load_data_btn
            // 
            this.load_data_btn.Location = new System.Drawing.Point(627, 28);
            this.load_data_btn.Name = "load_data_btn";
            this.load_data_btn.Size = new System.Drawing.Size(147, 23);
            this.load_data_btn.TabIndex = 4;
            this.load_data_btn.Text = "Cargar Datos Anteriores";
            this.load_data_btn.UseVisualStyleBackColor = true;
            this.load_data_btn.Click += new System.EventHandler(this.load_data_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Location = new System.Drawing.Point(480, 26);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(75, 23);
            this.stop_btn.TabIndex = 3;
            this.stop_btn.Text = "Parar";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(349, 26);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(75, 23);
            this.start_btn.TabIndex = 2;
            this.start_btn.Text = "Empezar";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Puerta Seriales";
            // 
            // temp_box
            // 
            this.temp_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.temp_box.Controls.Add(this.temp_chart);
            this.temp_box.Location = new System.Drawing.Point(12, 121);
            this.temp_box.Name = "temp_box";
            this.temp_box.Size = new System.Drawing.Size(525, 446);
            this.temp_box.TabIndex = 1;
            this.temp_box.TabStop = false;
            this.temp_box.Text = "Temperatura";
            // 
            // humidity_box
            // 
            this.humidity_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.humidity_box.AutoSize = true;
            this.humidity_box.Controls.Add(this.humidity_chart);
            this.humidity_box.Location = new System.Drawing.Point(543, 121);
            this.humidity_box.Name = "humidity_box";
            this.humidity_box.Size = new System.Drawing.Size(559, 454);
            this.humidity_box.TabIndex = 2;
            this.humidity_box.TabStop = false;
            this.humidity_box.Text = "Humedad";
            // 
            // barometric_box
            // 
            this.barometric_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barometric_box.Controls.Add(this.pressure_chart);
            this.barometric_box.Location = new System.Drawing.Point(1102, 121);
            this.barometric_box.Name = "barometric_box";
            this.barometric_box.Size = new System.Drawing.Size(513, 446);
            this.barometric_box.TabIndex = 2;
            this.barometric_box.TabStop = false;
            this.barometric_box.Text = "Presión Barométrica";
            // 
            // file_dialog
            // 
            this.file_dialog.DefaultExt = "json";
            this.file_dialog.Filter = "JSON File (*.json)|*.json";
            this.file_dialog.InitialDirectory = "~\\wdaqs";
            // 
            // serial_ports
            // 
            this.serial_ports.FormattingEnabled = true;
            this.serial_ports.Location = new System.Drawing.Point(102, 29);
            this.serial_ports.Name = "serial_ports";
            this.serial_ports.Size = new System.Drawing.Size(227, 21);
            this.serial_ports.TabIndex = 5;
            // 
            // temp_chart
            // 
            this.temp_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.temp_chart.Location = new System.Drawing.Point(6, 19);
            this.temp_chart.Name = "temp_chart";
            this.temp_chart.Size = new System.Drawing.Size(513, 416);
            this.temp_chart.TabIndex = 0;
            this.temp_chart.Text = "cartesianChart1";
            // 
            // humidity_chart
            // 
            this.humidity_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.humidity_chart.Location = new System.Drawing.Point(6, 19);
            this.humidity_chart.Name = "humidity_chart";
            this.humidity_chart.Size = new System.Drawing.Size(547, 416);
            this.humidity_chart.TabIndex = 1;
            this.humidity_chart.Text = "cartesianChart1";
            // 
            // pressure_chart
            // 
            this.pressure_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pressure_chart.Location = new System.Drawing.Point(10, 19);
            this.pressure_chart.Name = "pressure_chart";
            this.pressure_chart.Size = new System.Drawing.Size(501, 416);
            this.pressure_chart.TabIndex = 2;
            this.pressure_chart.Text = "cartesianChart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1625, 566);
            this.Controls.Add(this.barometric_box);
            this.Controls.Add(this.humidity_box);
            this.Controls.Add(this.temp_box);
            this.Controls.Add(this.control_box);
            this.Name = "Form1";
            this.Text = "Weather Data Acquisition System (WDAQs)";
            this.control_box.ResumeLayout(false);
            this.control_box.PerformLayout();
            this.temp_box.ResumeLayout(false);
            this.humidity_box.ResumeLayout(false);
            this.barometric_box.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox control_box;
        private System.Windows.Forms.Button load_data_btn;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox temp_box;
        private System.Windows.Forms.GroupBox humidity_box;
        private System.Windows.Forms.GroupBox barometric_box;
        private System.Windows.Forms.OpenFileDialog file_dialog;
        private System.Windows.Forms.ComboBox serial_ports;
        private LiveCharts.WinForms.CartesianChart temp_chart;
        private LiveCharts.WinForms.CartesianChart humidity_chart;
        private LiveCharts.WinForms.CartesianChart pressure_chart;
    }
}

