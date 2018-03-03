using CardCollectorMVPTest.Interfaces.Views;

namespace CardCollectorMVPTest.Interfaces.Presenters
{
	public interface ISetSelectionPresenter
	{
		void GetAndFillData();
		void AddSet();
		void UpdateSet();
		void UpdateCollection();
		void SetView(ISetSelectionListView view);
	}
}
