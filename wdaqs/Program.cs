using System;
using System.Threading;
using System.Windows.Forms;
using wdaqs.shared.Services.Log;

namespace wdaqs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var log = new LogService();

            using (var logger = log.GetLogger())
            {
                // Add handler to handle the exception raised by main threads
                Application.ThreadException += Application_ThreadException;

                // Add handler to handle the exception raised by additional threads
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());

                    logger.Information("Started wdaqs application successfully");
                }
                catch (Exception exception)
                {
                    logger.Error(exception, "An exception has occurred running the code");
                }
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var log = new LogService();

            using (var logger = log.GetLogger())
            {
                var exception = e.ExceptionObject as Exception ?? new Exception("An unhandled exception occurred");

                logger.Error(exception, "An exception occurred");
            }

        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var log = new LogService();

            using (var logger = log.GetLogger())
            {
                var exception = e.Exception ?? new Exception("An application thread exception occurred");

                logger.Error(exception, "An exception occurred");
            }

        }
    }
}