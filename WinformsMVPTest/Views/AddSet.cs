using System;
using System.Windows.Forms;
using WinformsMVPTest.Interfaces.Presenters;
using WinformsMVPTest.Interfaces.Views;

namespace WinformsMVPTest.Views
{
	public partial class AddSet : Form, IAddSetView
	{
		public IAddSetPresenter Presenter { get; set; }

		public TextBox NameTextBox => this.txtName;

		public TextBox CardsTextBox => this.txtCards;

		public AddSet()
		{
			InitializeComponent();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Presenter.CancelCreateSet();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Presenter.CreateSet();
		}

		public void CloseForm()
		{
			this.Close();
		}

		public void SetPresenter(IAddSetPresenter presenter)
		{
			this.Presenter = presenter;
		}
	}
}
