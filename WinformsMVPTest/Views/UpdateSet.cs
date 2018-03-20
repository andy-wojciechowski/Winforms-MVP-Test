using System;
using System.Windows.Forms;
using WinformsMVPTest.Interfaces.Presenters;
using WinformsMVPTest.Interfaces.Views;

namespace WinformsMVPTest.Views
{
	public partial class UpdateSet : Form, IUpdateSetView
	{
		public IUpdateSetPresenter Presenter { get; set; }
		public TextBox NameTextBox => this.txtCardName;

		public UpdateSet()
		{
			InitializeComponent();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Presenter.CancelUpdate();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Presenter.UpdateSet();
		}

		public void CloseForm()
		{
			this.Close();
		}

		public void SetPresenter(IUpdateSetPresenter presenter)
		{
			this.Presenter = presenter;
		}
	}
}
