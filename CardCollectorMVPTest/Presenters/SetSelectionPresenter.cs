using CardCollectorMVPTest.Forms;
using CardCollectorStandard.Domain.Facades;
using System.Linq;

namespace CardCollectorMVPTest.Presenters
{
    public interface ISetSelectionPresenter
    {
        void GetAndFillData();
        void AddSet();
        void UpdateSet();
        void UpdateCollection();
        void SetView(SetSelectionList view);
    }
    public class SetSelectionPresenter : ISetSelectionPresenter
    {
        public ICardFacade CardFacade { get; set; }
        private SetSelectionList View { get; set; }

        public void AddSet()
        {
            using (var addSetForm = new AddSet())
            {
                addSetForm.FormClosed += (s, e) => this.GetAndFillData();
                addSetForm.ShowDialog(View);
            }
        }

        //HACK!
        public void SetView(SetSelectionList view)
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
                editCardCollectionForm.ShowDialog(View);
            }
        }

        public void UpdateSet()
        {
            var setID = View.GetCurrentSelectRowId();
            using (var updateSetForm = new UpdateSet(setID))
            {
                updateSetForm.ShowDialog(View);
            }
        }
    }
}
