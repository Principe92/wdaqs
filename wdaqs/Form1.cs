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
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace wdaqs
{
    public partial class Form1 : Form
    {
        private IKernel _kernel;

        private ILogService _logService;

        private IWdaqService _wdaqService;

        public Form1()
        {
            InitializeComponent();

            stop_btn.Enabled = false;

            InitServices();
        }

        private void InitServices()
        {
            _kernel = new StandardKernel();

            _kernel.Load(new WdaqModule());

            _logService = _kernel.Get<ILogService>();
            _wdaqService = _kernel.Get<IWdaqService>();

            _wdaqService.DataReceived += WdaqReadingReceived;

            LoadSerialPorts();

            LineChart(temp_chart, "Temperatura");
            LineChart(humidity_chart, "Humedad");
            LineChart(pressure_chart, "Presión");
        }

        private void WdaqReadingReceived(object sender, WdaqReading reading)
        {
            var time = reading.Timestamp.Minute;

            temp_chart.Series.First().Values.Add(reading.Temperature);
            // temp_chart.AxisX.First().Labels.Add(time.ToString());

            humidity_chart.Series.First().Values.Add(reading.Humidity);
            // humidity_chart.AxisX.First().Labels.Add(time.ToString());

            pressure_chart.Series.First().Values.Add(reading.Pressure.Pressure);
            // pressure_chart.AxisX.First().Labels.Add(time.ToString());

        }

        private void LoadSerialPorts()
        {
            foreach (var port in SerialPortStream.GetPortNames())
            {
                serial_ports.Items.Add(port);
            }
        }


        private void LineChart(CartesianChart chart, string title)
        {
            chart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = title,
                    Values = new ChartValues<decimal> ()
                }
            };

            chart.AxisY.Add(new Axis
            {
                Title = title,
                LabelFormatter = value => value.ToString(CultureInfo.CurrentCulture)
            });

            chart.LegendLocation = LegendLocation.Top;

            chart.DataClick += CartesianChart1OnDataClick;
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            ShowMessage("(" + chartPoint.X + ", " + chartPoint.Y + ")");

        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            var portNumber = "1234"; // serial_ports.SelectedText;
            if (string.IsNullOrWhiteSpace(portNumber))
            {
                ShowMessage("Por favor, selecciona una puerta serial");
                return;
            }

            temp_chart.Series.First().Values = new ChartValues<decimal>();
            pressure_chart.Series.First().Values = new ChartValues<decimal>();
            humidity_chart.Series.First().Values = new ChartValues<decimal>();

            _wdaqService.Start(new WdaqRequest
            {
                PortNumber = portNumber
            });

            start_btn.Enabled = false;
            load_data_btn.Enabled = false;
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
        }

        private void load_data_btn_Click(object sender, EventArgs e)
        {
            var dialog = file_dialog.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                _wdaqService.Load(file_dialog.FileName);
            }
        }
    }
}