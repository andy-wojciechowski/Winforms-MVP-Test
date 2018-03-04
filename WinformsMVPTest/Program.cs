using WinformsMVPTest.DependencyResolution;
using WinformsMVPTest.Interfaces.Views;
using WinformsMVPTest.Interfaces.Presenters;
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
			ISetSelectionListView view = new SetSelectionList();
			using (var container = ObjectFactory.GetContainer())
			{
				var presenter = container.GetInstance<ISetSelectionPresenter>();
				presenter.SetView(view);
				view.SetPresenter(presenter);
			}
			Application.Run(view as SetSelectionList);
        }
    }
}
