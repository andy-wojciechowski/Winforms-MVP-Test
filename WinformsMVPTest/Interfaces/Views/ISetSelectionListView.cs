using System;
using System.Collections.Generic;

namespace WinformsMVPTest.Interfaces.Views
{
	public interface ISetSelectionListView
	{
		void SetGridDataSource(object source, IList<string> columnsToShow);
		Guid GetCurrentSelectRowId();
	}
}
