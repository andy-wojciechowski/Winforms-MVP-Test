using System;

namespace WinformsMVPTest.Interfaces.Views
{
	public interface IUpdateSetView
	{
		string GetCardToAdd();
		void CloseForm();
		Guid GetSetID();
	}
}
