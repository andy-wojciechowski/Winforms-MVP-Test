using CardCollectorMVPTest.Forms;
using CardCollectorMVPTest.Interfaces.Presenters;
using CardCollectorMVPTest.Interfaces.Views;
using CardCollectorStandard.Domain.Interfaces.Facades;
using System.Linq;

namespace CardCollectorMVPTest.Presenters
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
            this.View.SetGridDataSource(this.CardFacade.GetAllCardSets(), new string[] { "Name" }.ToList());
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
