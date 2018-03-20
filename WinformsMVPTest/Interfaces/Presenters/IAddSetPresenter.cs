using WinformsMVPTest.Interfaces.Views;

namespace WinformsMVPTest.Interfaces.Presenters
{
	public interface IAddSetPresenter
	{
		void CreateSet();
		void CancelCreateSet();
		void SetView(IAddSetView View);
	}
}
