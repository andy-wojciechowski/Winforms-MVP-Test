using System;
using System.Windows.Forms;
using WinformsMVPTest.DependencyResolution;
using WinformsMVPTest.Interfaces.Presenters;
using WinformsMVPTest.Interfaces.Views;

namespace WinformsMVPTest.Views
{
	public partial class SetSelectionList : Form, ISetSelectionListView
    {
        public ISetSelectionPresenter Presenter { get; set; }
		public bool IsDataBound { get; set; }

		public DataGridView SetGrid => this.setGrid;

		private DataGridViewRow _lastSelectedRow;

        public SetSelectionList()
        {
            InitializeComponent();
            using (var container = ObjectFactory.GetContainer())
            {
                this.Presenter = container.GetInstance<ISetSelectionPresenter>();
            }
            Presenter.SetView(this);
        }

        public Guid GetCurrentSelectRowId()
        {
            return (Guid)this.setGrid.Rows[_lastSelectedRow.Index].Cells["ID"].Value;
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
            if (this.setGrid.Rows.Count != 0 && IsDataBound)
            {
                if (this.setGrid.SelectedRows.Count == 0)
                {
                    _lastSelectedRow.Selected = true;
                }
                else
                {
                    _lastSelectedRow = this.setGrid.SelectedRows[0];
                }
            }
        }

        private void setGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Presenter.UpdateCollection();
        }

    }
}
