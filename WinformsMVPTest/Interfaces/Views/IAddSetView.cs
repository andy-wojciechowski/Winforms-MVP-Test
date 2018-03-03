using System.Windows.Forms;

namespace WinformsMVPTest.Interfaces.Views
{
    public interface IAddSetView
    {
		TextBox NameTextBox { get; }
		TextBox CardsTextBox { get; }
        void CloseForm();
    }
}
