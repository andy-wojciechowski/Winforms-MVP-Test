using CardCollectorMVPTest.Interfaces.Views;

namespace CardCollectorMVPTest.Interfaces.Presenters
{
	public interface IUpdateSetPresenter
	{
		void UpdateSet();
		void CancelUpdate();
		void SetView(IUpdateSetView View);
	}
}
