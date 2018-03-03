using System.Windows.Forms;
using WinformsMVPTest.Interfaces.Presenters;

namespace WinformsMVPTest.Interfaces.Views
{
	public interface IUpdateSetView
	{
		TextBox NameTextBox { get; }
		void CloseForm();
		void SetPresenter(IUpdateSetPresenter presenter);
	}
}
