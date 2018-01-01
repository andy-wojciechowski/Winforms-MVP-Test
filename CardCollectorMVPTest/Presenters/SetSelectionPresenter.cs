using CardCollectorMVPTest.Forms;
using CardCollectorStandard.Domain.Facades;
using System.Linq;
using System;

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
    public class SetSelectionPresenter : BasePresenter<SetSelectionList>, ISetSelectionPresenter
    {
        public ICardFacade CardFacade { get; set; }

        public void AddSet()
        {
            using (var addSetForm = new AddSet())
            {
                addSetForm.FormClosed += (s, e) => this.GetAndFillData();
                addSetForm.ShowDialog(View);
            }
        }

        //HACK!
        public new void SetView(SetSelectionList view)
        {
            base.SetView(view);
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
