using System;
using System.Windows.Forms;
using CardCollectorMVPTest.Forms;

namespace CardCollectorMVPTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AutoMapperConfig.Configure();
            Application.Run(new SetSelectionList());
        }
    }
}
