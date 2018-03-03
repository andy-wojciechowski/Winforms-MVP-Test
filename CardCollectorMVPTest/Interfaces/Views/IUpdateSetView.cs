using System;

namespace CardCollectorMVPTest.Interfaces.Views
{
	public interface IUpdateSetView
	{
		string GetCardToAdd();
		void CloseForm();
		Guid GetSetID();
	}
}
