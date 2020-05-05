using System;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using Ninject;
using RJCP.IO.Ports;
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

            LoadSerialPorts();

            LineChart(temp_chart);
            LineChart(humidity_chart);
            LineChart(pressure_chart);
        }

        private void LoadSerialPorts()
        {
            foreach (var port in SerialPortStream.GetPortNames())
            {
                serial_ports.Items.Add(port);
            }
        }


        private void LineChart(CartesianChart chart)
        {
            chart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Temperatura",
                    Values = new ChartValues<double> {4, 6, 5, 2, 7}
                }
            };

            chart.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] {"Jan", "Feb", "Mar", "Apr", "May"}
            });

            chart.AxisY.Add(new Axis
            {
                Title = "Temperatura",
                LabelFormatter = value => value.ToString("C")
            });

            chart.LegendLocation = LegendLocation.Top;

            chart.DataClick += CartesianChart1OnDataClick;
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            ShowMessage("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            var portNumber = serial_ports.SelectedText;
            if (string.IsNullOrWhiteSpace(portNumber))
            {
                ShowMessage("Por favor, selecciona una puerta serial");
                return;
            }

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