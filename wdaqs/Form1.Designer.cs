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
            this.baud_txt = new System.Windows.Forms.TextBox();
            this.serial_ports = new System.Windows.Forms.ComboBox();
            this.load_data_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.altitude_txt = new System.Windows.Forms.Label();
            this.temp_chart = new LiveCharts.WinForms.CartesianChart();
            this.humidity_chart = new LiveCharts.WinForms.CartesianChart();
            this.pressure_chart = new LiveCharts.WinForms.CartesianChart();
            this.file_dialog = new System.Windows.Forms.OpenFileDialog();
            this.wind_speed_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gyroscope = new LiveCharts.WinForms.CartesianChart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.accelerometer = new LiveCharts.WinForms.CartesianChart();
            this.control_box.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // control_box
            // 
            this.control_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.control_box.Controls.Add(this.baud_txt);
            this.control_box.Controls.Add(this.serial_ports);
            this.control_box.Controls.Add(this.load_data_btn);
            this.control_box.Controls.Add(this.stop_btn);
            this.control_box.Controls.Add(this.start_btn);
            this.control_box.Controls.Add(this.label1);
            this.control_box.Location = new System.Drawing.Point(13, 13);
            this.control_box.Name = "control_box";
            this.control_box.Size = new System.Drawing.Size(1357, 75);
            this.control_box.TabIndex = 0;
            this.control_box.TabStop = false;
            this.control_box.Text = "Controles";
            // 
            // baud_txt
            // 
            this.baud_txt.Location = new System.Drawing.Point(350, 29);
            this.baud_txt.Name = "baud_txt";
            this.baud_txt.Size = new System.Drawing.Size(174, 20);
            this.baud_txt.TabIndex = 7;
            this.baud_txt.Text = "Velocidad de transmisión";
            // 
            // serial_ports
            // 
            this.serial_ports.FormattingEnabled = true;
            this.serial_ports.Location = new System.Drawing.Point(102, 29);
            this.serial_ports.Name = "serial_ports";
            this.serial_ports.Size = new System.Drawing.Size(227, 21);
            this.serial_ports.TabIndex = 5;
            // 
            // load_data_btn
            // 
            this.load_data_btn.Location = new System.Drawing.Point(733, 26);
            this.load_data_btn.Name = "load_data_btn";
            this.load_data_btn.Size = new System.Drawing.Size(147, 23);
            this.load_data_btn.TabIndex = 4;
            this.load_data_btn.Text = "Cargar Datos Anteriores";
            this.load_data_btn.UseVisualStyleBackColor = true;
            this.load_data_btn.Click += new System.EventHandler(this.load_data_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Location = new System.Drawing.Point(638, 26);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(75, 23);
            this.stop_btn.TabIndex = 3;
            this.stop_btn.Text = "Parar";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(547, 26);
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
            // altitude_txt
            // 
            this.altitude_txt.AutoSize = true;
            this.altitude_txt.Location = new System.Drawing.Point(5, 29);
            this.altitude_txt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.altitude_txt.Name = "altitude_txt";
            this.altitude_txt.Size = new System.Drawing.Size(48, 13);
            this.altitude_txt.TabIndex = 6;
            this.altitude_txt.Text = "Altitud: 0";
            // 
            // temp_chart
            // 
            this.temp_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.temp_chart.Location = new System.Drawing.Point(3, 3);
            this.temp_chart.Name = "temp_chart";
            this.temp_chart.Size = new System.Drawing.Size(553, 250);
            this.temp_chart.TabIndex = 0;
            this.temp_chart.Text = "cartesianChart1";
            // 
            // humidity_chart
            // 
            this.humidity_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.humidity_chart.Location = new System.Drawing.Point(562, 3);
            this.humidity_chart.Name = "humidity_chart";
            this.humidity_chart.Size = new System.Drawing.Size(554, 250);
            this.humidity_chart.TabIndex = 1;
            this.humidity_chart.Text = "cartesianChart1";
            // 
            // pressure_chart
            // 
            this.pressure_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pressure_chart.Location = new System.Drawing.Point(3, 261);
            this.pressure_chart.Name = "pressure_chart";
            this.pressure_chart.Size = new System.Drawing.Size(553, 250);
            this.pressure_chart.TabIndex = 2;
            this.pressure_chart.Text = "cartesianChart1";
            // 
            // file_dialog
            // 
            this.file_dialog.DefaultExt = "json";
            this.file_dialog.Filter = "JSON File (*.json)|*.json";
            this.file_dialog.InitialDirectory = "~\\wdaqs";
            // 
            // wind_speed_label
            // 
            this.wind_speed_label.AutoSize = true;
            this.wind_speed_label.Location = new System.Drawing.Point(5, 66);
            this.wind_speed_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.wind_speed_label.Name = "wind_speed_label";
            this.wind_speed_label.Size = new System.Drawing.Size(113, 13);
            this.wind_speed_label.TabIndex = 8;
            this.wind_speed_label.Text = "Velocidad de viento: 0";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.accelerometer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.gyroscope, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pressure_chart, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.humidity_chart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.temp_chart, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 109);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.37794F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.62206F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 273F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1119, 818);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // gyroscope
            // 
            this.gyroscope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gyroscope.Location = new System.Drawing.Point(3, 547);
            this.gyroscope.Name = "gyroscope";
            this.gyroscope.Size = new System.Drawing.Size(553, 250);
            this.gyroscope.TabIndex = 4;
            this.gyroscope.Text = "cartesianChart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.wind_speed_label);
            this.groupBox1.Controls.Add(this.altitude_txt);
            this.groupBox1.Location = new System.Drawing.Point(1137, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 818);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Otras informaciónes";
            // 
            // accelerometer
            // 
            this.accelerometer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accelerometer.Location = new System.Drawing.Point(562, 261);
            this.accelerometer.Name = "accelerometer";
            this.accelerometer.Size = new System.Drawing.Size(554, 250);
            this.accelerometer.TabIndex = 6;
            this.accelerometer.Text = "cartesianChart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 939);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.control_box);
            this.Name = "Form1";
            this.Text = "Weather Data Acquisition System (WDAQs)";
            this.control_box.ResumeLayout(false);
            this.control_box.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox control_box;
        private System.Windows.Forms.Button load_data_btn;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog file_dialog;
        private System.Windows.Forms.ComboBox serial_ports;
        private LiveCharts.WinForms.CartesianChart temp_chart;
        private LiveCharts.WinForms.CartesianChart humidity_chart;
        private LiveCharts.WinForms.CartesianChart pressure_chart;
        private System.Windows.Forms.Label altitude_txt;
        private System.Windows.Forms.Label wind_speed_label;
        private System.Windows.Forms.TextBox baud_txt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private LiveCharts.WinForms.CartesianChart gyroscope;
        private System.Windows.Forms.GroupBox groupBox1;
        private LiveCharts.WinForms.CartesianChart accelerometer;
    }
}

