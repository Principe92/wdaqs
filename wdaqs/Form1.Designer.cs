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
            this.serial_ports = new System.Windows.Forms.ComboBox();
            this.load_data_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.temp_box = new System.Windows.Forms.GroupBox();
            this.temp_chart = new LiveCharts.WinForms.CartesianChart();
            this.humidity_box = new System.Windows.Forms.GroupBox();
            this.humidity_chart = new LiveCharts.WinForms.CartesianChart();
            this.barometric_box = new System.Windows.Forms.GroupBox();
            this.pressure_chart = new LiveCharts.WinForms.CartesianChart();
            this.file_dialog = new System.Windows.Forms.OpenFileDialog();
            this.altitude_txt = new System.Windows.Forms.Label();
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
            this.control_box.Controls.Add(this.altitude_txt);
            this.control_box.Controls.Add(this.serial_ports);
            this.control_box.Controls.Add(this.load_data_btn);
            this.control_box.Controls.Add(this.stop_btn);
            this.control_box.Controls.Add(this.start_btn);
            this.control_box.Controls.Add(this.label1);
            this.control_box.Location = new System.Drawing.Point(26, 25);
            this.control_box.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.control_box.Name = "control_box";
            this.control_box.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.control_box.Size = new System.Drawing.Size(3200, 144);
            this.control_box.TabIndex = 0;
            this.control_box.TabStop = false;
            this.control_box.Text = "Controles";
            // 
            // serial_ports
            // 
            this.serial_ports.FormattingEnabled = true;
            this.serial_ports.Location = new System.Drawing.Point(204, 56);
            this.serial_ports.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.serial_ports.Name = "serial_ports";
            this.serial_ports.Size = new System.Drawing.Size(450, 33);
            this.serial_ports.TabIndex = 5;
            // 
            // load_data_btn
            // 
            this.load_data_btn.Location = new System.Drawing.Point(1254, 54);
            this.load_data_btn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.load_data_btn.Name = "load_data_btn";
            this.load_data_btn.Size = new System.Drawing.Size(294, 44);
            this.load_data_btn.TabIndex = 4;
            this.load_data_btn.Text = "Cargar Datos Anteriores";
            this.load_data_btn.UseVisualStyleBackColor = true;
            this.load_data_btn.Click += new System.EventHandler(this.load_data_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Location = new System.Drawing.Point(960, 50);
            this.stop_btn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(150, 44);
            this.stop_btn.TabIndex = 3;
            this.stop_btn.Text = "Parar";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(698, 50);
            this.start_btn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(150, 44);
            this.start_btn.TabIndex = 2;
            this.start_btn.Text = "Empezar";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Puerta Seriales";
            // 
            // temp_box
            // 
            this.temp_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.temp_box.Controls.Add(this.temp_chart);
            this.temp_box.Location = new System.Drawing.Point(24, 233);
            this.temp_box.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.temp_box.Name = "temp_box";
            this.temp_box.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.temp_box.Size = new System.Drawing.Size(1050, 858);
            this.temp_box.TabIndex = 1;
            this.temp_box.TabStop = false;
            this.temp_box.Text = "Temperatura";
            // 
            // temp_chart
            // 
            this.temp_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.temp_chart.Location = new System.Drawing.Point(12, 37);
            this.temp_chart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.temp_chart.Name = "temp_chart";
            this.temp_chart.Size = new System.Drawing.Size(1026, 800);
            this.temp_chart.TabIndex = 0;
            this.temp_chart.Text = "cartesianChart1";
            // 
            // humidity_box
            // 
            this.humidity_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.humidity_box.AutoSize = true;
            this.humidity_box.Controls.Add(this.humidity_chart);
            this.humidity_box.Location = new System.Drawing.Point(1086, 233);
            this.humidity_box.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.humidity_box.Name = "humidity_box";
            this.humidity_box.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.humidity_box.Size = new System.Drawing.Size(1118, 873);
            this.humidity_box.TabIndex = 2;
            this.humidity_box.TabStop = false;
            this.humidity_box.Text = "Humedad";
            // 
            // humidity_chart
            // 
            this.humidity_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.humidity_chart.Location = new System.Drawing.Point(12, 37);
            this.humidity_chart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.humidity_chart.Name = "humidity_chart";
            this.humidity_chart.Size = new System.Drawing.Size(1094, 800);
            this.humidity_chart.TabIndex = 1;
            this.humidity_chart.Text = "cartesianChart1";
            // 
            // barometric_box
            // 
            this.barometric_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barometric_box.Controls.Add(this.pressure_chart);
            this.barometric_box.Location = new System.Drawing.Point(2204, 233);
            this.barometric_box.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.barometric_box.Name = "barometric_box";
            this.barometric_box.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.barometric_box.Size = new System.Drawing.Size(1026, 858);
            this.barometric_box.TabIndex = 2;
            this.barometric_box.TabStop = false;
            this.barometric_box.Text = "Presión Barométrica";
            // 
            // pressure_chart
            // 
            this.pressure_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pressure_chart.Location = new System.Drawing.Point(20, 37);
            this.pressure_chart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pressure_chart.Name = "pressure_chart";
            this.pressure_chart.Size = new System.Drawing.Size(1002, 800);
            this.pressure_chart.TabIndex = 2;
            this.pressure_chart.Text = "cartesianChart1";
            // 
            // file_dialog
            // 
            this.file_dialog.DefaultExt = "json";
            this.file_dialog.Filter = "JSON File (*.json)|*.json";
            this.file_dialog.InitialDirectory = "~\\wdaqs";
            // 
            // altitude_txt
            // 
            this.altitude_txt.AutoSize = true;
            this.altitude_txt.Location = new System.Drawing.Point(2119, 64);
            this.altitude_txt.Name = "altitude_txt";
            this.altitude_txt.Size = new System.Drawing.Size(192, 50);
            this.altitude_txt.TabIndex = 6;
            this.altitude_txt.Text = "Altitud: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3250, 1088);
            this.Controls.Add(this.barometric_box);
            this.Controls.Add(this.humidity_box);
            this.Controls.Add(this.temp_box);
            this.Controls.Add(this.control_box);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
        private System.Windows.Forms.Label altitude_txt;
    }
}

