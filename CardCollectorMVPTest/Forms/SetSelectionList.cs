using CardCollectorMVPTest.DependencyResolution;
using CardCollectorMVPTest.Presenters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CardCollectorMVPTest.Forms
{
    public interface ISetSelectionListView
    {
        void SetGridDataSource(object source, IList<string> columnsToShow);
        Guid GetCurrentSelectRowId();
    }

    public partial class SetSelectionList : Form, ISetSelectionListView
    {
        public ISetSelectionPresenter Presenter { get; set; }
        private DataGridViewRow _lastSelectedRow;
        private bool IsDataBound;

        public SetSelectionList()
        {
            InitializeComponent();
            using (var container = ObjectFactory.GetContainer())
            {
                this.Presenter = container.GetInstance<ISetSelectionPresenter>();
            }
            Presenter.SetView(this);
        }

        public void SetGridDataSource(object source, IList<string> columnsToShow)
        {
            IsDataBound = false;
            this.setGrid.DataSource = typeof(IList);
            this.setGrid.DataSource = source;
            IsDataBound = true;
            if (this.setGrid.Rows.Count != 0) { this.setGrid.Rows[0].Selected = true; }
            foreach (DataGridViewColumn column in this.setGrid.Columns)
            {
                if (!columnsToShow.Contains(column.Name) || string.IsNullOrEmpty(column.Name))
                {
                    column.Visible = false;
                }
            }
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
