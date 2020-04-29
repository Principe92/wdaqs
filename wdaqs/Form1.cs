using System;
using System.Windows.Forms;
using Ninject;
using wdaqs.shared;
using wdaqs.shared.Model;
using wdaqs.shared.Services;
using wdaqs.shared.Services.Log;

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
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            var portNumber = serial_port_txt.Text;
            if (string.IsNullOrWhiteSpace(portNumber))
            {
                ShowMessage("El número de puerto serial es necesario");
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
            control_box.Invoke((MethodInvoker)(() => { MessageBox.Show(message); }));
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
