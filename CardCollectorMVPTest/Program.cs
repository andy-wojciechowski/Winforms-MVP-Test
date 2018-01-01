using StructureMap;
using System;
using System.Windows.Forms;
using CardCollectorMVPTest.Forms;

namespace CardCollectorMVPTest
{
    static class Program
    {
        private static DependencyResolver _DependencyResolver;
        public static DependencyResolver DependencyResolver
        {
            get
            {
                return _DependencyResolver;
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AutoMapperConfig.Configure();
            var container = new Container(new MVPRegistry());
            _DependencyResolver = new DependencyResolver(container);
            Application.Run(new SetSelectionList());
        }
    }
}
