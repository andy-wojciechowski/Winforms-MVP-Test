using System;
using System.Windows.Forms;
using WinformsMVPTest.Interfaces.Presenters;
using WinformsMVPTest.Interfaces.Views;

namespace WinformsMVPTest.Views
{
	public partial class SetSelectionList : Form, ISetSelectionListView
    {
        public ISetSelectionPresenter Presenter { get; set; }
		public DataGridView SetGrid => this.setGrid;

        public SetSelectionList()
        {
            InitializeComponent();
        }

        private void SetSelectionList_Load(object sender, EventArgs e)
        {
            Presenter.GetAndFillData();
        }

        private void AddSet_Click(object sender, EventArgs e)
        {
            Presenter.AddSet();
        }

        private void UpdateSet_Click(object sender, EventArgs e)
        {
            Presenter.UpdateSet();
        }

        private void setGrid_SelectionChanged(object sender, EventArgs e)
        {
			Presenter.UpdateLastSelectedRow();
        }

        private void setGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Presenter.UpdateCollection();
        }

		public void SetPresenter(ISetSelectionPresenter presenter)
		{
			this.Presenter = presenter;
		}
	}
}
