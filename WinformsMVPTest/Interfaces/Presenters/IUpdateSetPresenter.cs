using WinformsMVPTest.Interfaces.Views;
using System;

namespace WinformsMVPTest.Interfaces.Presenters
{
	public interface IUpdateSetPresenter
	{
		void UpdateSet();
		void CancelUpdate();
		void SetView(IUpdateSetView View);
		void SetSetID(Guid setID);
	}
}
