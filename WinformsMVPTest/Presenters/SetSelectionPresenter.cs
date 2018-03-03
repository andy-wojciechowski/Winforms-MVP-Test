using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using WinformsMVPTest.DependencyResolution;
using WinformsMVPTest.Domain.Interfaces.Facades;
using WinformsMVPTest.Interfaces.Presenters;
using WinformsMVPTest.Interfaces.Views;
using WinformsMVPTest.Views;

namespace WinformsMVPTest.Presenters
{
	public class SetSelectionPresenter : ISetSelectionPresenter
	{
		public ICardFacade CardFacade { get; set; }
		private ISetSelectionListView View { get; set; }
		private bool IsDataBound {get;set;}
		private DataGridViewRow _lastSelectedRow { get; set; }

        public void AddSet()
        {
			IAddSetView view = new AddSet();
			using (var container = ObjectFactory.GetContainer())
			{
				var presenter = container.GetInstance<IAddSetPresenter>();
				presenter.SetView(view);
				view.SetPresenter(presenter);
			}

			var form = (Form)view;
			using (form)
			{
				form.FormClosed += (s, e) => this.GetAndFillData();
				form.ShowDialog(View as SetSelectionList);
			}
        }

        public void SetView(ISetSelectionListView view)
        {
            this.View = view;
        }

        public void GetAndFillData()
        {
			var columnsToShow = new string[] { "Name" };
			var cards = this.CardFacade.GetAllCardSets();
			this.IsDataBound = false;
			this.View.SetGrid.DataSource = typeof(IList);
			this.View.SetGrid.DataSource = cards;
			this.IsDataBound = true;
			if (this.View.SetGrid.Rows.Count != 0) { this.View.SetGrid.Rows[0].Selected = true; }
			foreach (DataGridViewColumn column in this.View.SetGrid.Columns)
			{
				if (!columnsToShow.Contains(column.Name) || string.IsNullOrEmpty(column.Name))
				{
					column.Visible = false;
				}
			}
		}

        public void UpdateCollection()
        {
			var setID = this.GetCurrentlySelectedRow();
			IEditCardCollectionView editCardCollectionView = new EditCardCollection();
			using (var container = ObjectFactory.GetContainer())
			{
				var presenter = container.GetInstance<IEditCardCollectionPresenter>();
				presenter.SetView(editCardCollectionView);
				presenter.SetSetID(setID);
				editCardCollectionView.SetPresenter(presenter);
			}

			var form = (Form)editCardCollectionView;
			using (form)
			{
				form.ShowDialog(View as SetSelectionList);
			}
        }

        public void UpdateSet()
        {
			var setID = this.GetCurrentlySelectedRow();
			IUpdateSetView updateSetView = new UpdateSet();
			using (var container = ObjectFactory.GetContainer())
			{
				var presenter = container.GetInstance<IUpdateSetPresenter>();
				presenter.SetView(updateSetView);
				presenter.SetSetID(setID);
				updateSetView.SetPresenter(presenter);
			}

			var form = (Form)updateSetView;
			using (form)
			{
				form.ShowDialog(View as SetSelectionList);
			}
        }

		public void UpdateLastSelectedRow()
		{
			if (this.View.SetGrid.Rows.Count != 0 && this.IsDataBound)
			{
				if (this.View.SetGrid.SelectedRows.Count == 0)
				{
					_lastSelectedRow.Selected = true;
				}
				else
				{
					_lastSelectedRow = this.View.SetGrid.SelectedRows[0];
				}
			}
		}

		private Guid GetCurrentlySelectedRow()
		{
			return (Guid)this.View.SetGrid.Rows[_lastSelectedRow.Index].Cells["ID"].Value;
		}
	}
}
