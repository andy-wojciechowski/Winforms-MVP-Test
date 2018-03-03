using System.Windows.Forms;
using WinformsMVPTest.Interfaces.Presenters;

namespace WinformsMVPTest.Interfaces.Views
{
    public interface IAddSetView
    {
		TextBox NameTextBox { get; }
		TextBox CardsTextBox { get; }
        void CloseForm();
		void SetPresenter(IAddSetPresenter presenter);
    }
}
