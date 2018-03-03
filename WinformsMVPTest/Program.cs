using WinformsMVPTest.Views;
using System;
using System.Windows.Forms;

namespace WinformsMVPTest
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AutoMapperConfig.Configure();
            Application.Run(new SetSelectionList());
        }
    }
}
