using WinformsMVPTest.Views;
using WinformsMVPTest.Interfaces.Presenters;
using WinformsMVPTest.Interfaces.Views;
using WinformsMVPTest.Domain.Interfaces.Facades;
using System.Linq;
using System.Collections;
using System.Windows.Forms;

namespace WinformsMVPTest.Presenters
{
    public class SetSelectionPresenter : ISetSelectionPresenter
    {
        public ICardFacade CardFacade { get; set; }
        private ISetSelectionListView View { get; set; }

        public void AddSet()
        {
            using (var addSetForm = new AddSet())
            {
                addSetForm.FormClosed += (s, e) => this.GetAndFillData();
                addSetForm.ShowDialog(View as SetSelectionList);
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
			this.View.IsDataBound = false;
			this.View.SetGrid.DataSource = typeof(IList);
			this.View.SetGrid.DataSource = cards;
			this.View.IsDataBound = true;
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
            var setID = View.GetCurrentSelectRowId();
            using (var editCardCollectionForm = new EditCardCollection(setID))
            {
                editCardCollectionForm.ShowDialog(View as SetSelectionList);
            }
        }

        public void UpdateSet()
        {
            var setID = View.GetCurrentSelectRowId();
            using (var updateSetForm = new UpdateSet(setID))
            {
                updateSetForm.ShowDialog(View as SetSelectionList);
            }
        }
    }
}
