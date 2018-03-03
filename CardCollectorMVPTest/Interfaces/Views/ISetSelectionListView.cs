using System;
using System.Collections.Generic;

namespace CardCollectorMVPTest.Interfaces.Views
{
	public interface ISetSelectionListView
	{
		void SetGridDataSource(object source, IList<string> columnsToShow);
		Guid GetCurrentSelectRowId();
	}
}
