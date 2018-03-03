using System;
using System.Windows.Forms;

namespace WinformsMVPTest.Interfaces.Views
{
	public interface ISetSelectionListView
	{
		bool IsDataBound { get; set; }
		DataGridView SetGrid { get; }
		Guid GetCurrentSelectRowId();
	}
}
