using WinformsMVPTest.Interfaces.Views;

namespace WinformsMVPTest.Interfaces.Presenters
{
	public interface ISetSelectionPresenter
	{
		void GetAndFillData();
		void AddSet();
		void UpdateSet();
		void UpdateCollection();
		void SetView(ISetSelectionListView view);
		void UpdateLastSelectedRow();
	}
}
