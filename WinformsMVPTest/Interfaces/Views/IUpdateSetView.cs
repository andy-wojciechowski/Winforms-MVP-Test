using System;
using System.Windows.Forms;

namespace WinformsMVPTest.Interfaces.Views
{
	public interface IUpdateSetView
	{
		TextBox NameTextBox { get; }
		void CloseForm();
		Guid GetSetID();
	}
}
