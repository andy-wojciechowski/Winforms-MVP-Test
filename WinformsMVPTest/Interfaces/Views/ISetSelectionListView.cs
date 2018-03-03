using System.Windows.Forms;
using WinformsMVPTest.Interfaces.Presenters;

namespace WinformsMVPTest.Interfaces.Views
{
	public interface ISetSelectionListView
	{
		DataGridView SetGrid { get; }
		void SetPresenter(ISetSelectionPresenter presenter);
	}
}
