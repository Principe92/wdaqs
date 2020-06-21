using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using Ninject;
using RJCP.IO.Ports;
using Serilog.Events;
using wdaqs.shared;
using wdaqs.shared.Model;
using wdaqs.shared.Services;
using wdaqs.shared.Services.Log;
using wdaqs.shared.Services.Settings;
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace wdaqs
{
    public partial class Form1 : Form
    {
        private IKernel _kernel;

        private ILogService _logService;

        private IWdaqService _wdaqService;
        private IWdaqSettingService _settingSvc;

        public Form1()
        {
            InitializeComponent();

            stop_btn.Enabled = false;
            csv_export_btn.Enabled = false;

            baud_txt.Text = @"115200";

            InitServices();

            _logService.Log(LogEventLevel.Information, "Started wdaq program");
        }

        private void InitServices()
        {
            _kernel = new StandardKernel();

            _kernel.Load(new WdaqModule());

            _logService = _kernel.Get<ILogService>();

            _wdaqService = _kernel.Get<IWdaqService>();

            _wdaqService.DataReceived += WdaqReadingReceived;

            _wdaqService.CsvExported += CsvFileExported;

            LoadSerialPorts();

            LineChart(temp_chart, "Temperatura", "Temperatura");
            LineChart(humidity_chart, "Humedad", "Humedad");
            LineChart(pressure_chart, "Presión Barométrica", "Temperatura", "Presión", "Altitud");
            LineChart(accelerometer, "Acelerómetro", "X", "Y", "Z");
            LineChart(gyroscope, "Giroscopio", "X", "Y", "Z");

            _settingSvc = _kernel.Get<IWdaqSettingService>();
            var setting = _settingSvc.LoadSetting();

            path_txt.Text = setting.RunFolder;
        }

        private void CsvFileExported(object sender, string e)
        {
            ShowMessage($"El fichero ha sido exportado al: {e}");
        }

        private void WdaqReadingReceived(object sender, WdaqReading reading)
        {
            temp_chart.Series.First().Values.Add(reading.Temperature);

            humidity_chart.Series.First().Values.Add(reading.Humidity);

            pressure_chart.Series[0].Values.Add(reading.Pressure.Temperature);
            pressure_chart.Series[1].Values.Add(reading.Pressure.Pressure);
            pressure_chart.Series[2].Values.Add(reading.Pressure.Altitude);

            accelerometer.Series[0].Values.Add(reading.Accelerometer.XValue);
            accelerometer.Series[1].Values.Add(reading.Accelerometer.YValue);
            accelerometer.Series[2].Values.Add(reading.Accelerometer.ZValue);

            gyroscope.Series[0].Values.Add(reading.Gyroscope.XValue);
            gyroscope.Series[1].Values.Add(reading.Gyroscope.YValue);
            gyroscope.Series[2].Values.Add(reading.Gyroscope.ZValue);

            control_box.Invoke((MethodInvoker) (() =>
            {
                altitude_txt.Text = $"Altitud: {reading.Pressure.Altitude}";
                wind_speed_label.Text = $"Velocidad de viento: {reading.WindSensor.WindMph}";

            }));
        }

        private void LoadSerialPorts()
        {
            foreach (var port in SerialPortStream.GetPortNames())
            {
                serial_ports.Items.Add(port);
            }
        }


        private void LineChart(CartesianChart chart, string title, params string[] titles)
        {
            var series = titles.Select(x => new LineSeries
            {
                Title = x,
                Values = new ChartValues<decimal>()
            });

            chart.Series = new SeriesCollection();
            chart.Series.AddRange(series);

            chart.AxisY.Add(new Axis
            {
                Title = title,
                LabelFormatter = value => value.ToString(CultureInfo.CurrentCulture)
            });

            chart.LegendLocation = LegendLocation.Top;

            chart.DataClick += CartesianChart1OnDataClick;
        }

        private void ClearChart()
        {
            temp_chart.Series.First().Values = new ChartValues<decimal>();

            foreach (var series in pressure_chart.Series)
            {
                series.Values = new ChartValues<decimal>();
            }

            foreach (var series in gyroscope.Series)
            {
                series.Values = new ChartValues<decimal>();
            }

            foreach (var series in accelerometer.Series)
            {
                series.Values = new ChartValues<decimal>();
            }

            humidity_chart.Series.First().Values = new ChartValues<decimal>();

            altitude_txt.Text = @"Altitud: 0";

            wind_speed_label.Text = @"Velocided de Viento: 0";
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            ShowMessage("(" + chartPoint.X + ", " + chartPoint.Y + ")");

        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            var portNumber = (string) serial_ports.SelectedItem;
            if (string.IsNullOrWhiteSpace(portNumber))
            {
                ShowMessage("Por favor, selecciona una puerta serial");
                return;
            }

            if (!int.TryParse(baud_txt.Text, out var baudRate))
            {
                ShowMessage("Por favor, se necesita una velocidad de transmisión");
                return;
            }

            ClearChart();

            _wdaqService.Start(new WdaqRequest
            {
                PortNumber = portNumber,
                BaudRate = baudRate
            });

            start_btn.Enabled = false;
            load_data_btn.Enabled = false;
            csv_export_btn.Enabled = false;
            stop_btn.Enabled = true;
        }

        private void ShowMessage(string message)
        {
            control_box.Invoke((MethodInvoker) (() => { MessageBox.Show(message); }));
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            _wdaqService.Stop();

            start_btn.Enabled = true;
            stop_btn.Enabled = false;
            load_data_btn.Enabled = true;
            csv_export_btn.Enabled = true;
        }

        private void load_data_btn_Click(object sender, EventArgs e)
        {
            var dialog = file_dialog.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                ClearChart();

                _wdaqService.Load(file_dialog.FileName);
                csv_export_btn.Enabled = true;
            }
        }

        private void csv_export_btn_Click(object sender, EventArgs e)
        {
            try
            {
                _wdaqService.ExportToCsv();
            }
            catch (Exception exception)
            {
                _logService.Log(exception, LogEventLevel.Error, "Ha occurido un error");
            }
        }

        private void folder_change_Click(object sender, EventArgs e)
        {
            var setting = _settingSvc.LoadSetting();

            path_selector.SelectedPath = setting.RunFolder;

            var dialog = path_selector.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                _wdaqService.UpdateRunFolder(path_selector.SelectedPath);

                path_txt.Text = path_selector.SelectedPath;
            }
        }
    }
}