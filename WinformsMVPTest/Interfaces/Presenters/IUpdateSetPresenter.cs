using WinformsMVPTest.Interfaces.Views;

namespace WinformsMVPTest.Interfaces.Presenters
{
	public interface IUpdateSetPresenter
	{
		void UpdateSet();
		void CancelUpdate();
		void SetView(IUpdateSetView View);
	}
}
