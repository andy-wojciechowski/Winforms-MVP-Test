using CardCollectorMVPTest.Forms;
using CardCollectorStandard.Domain.Dtos;
using CardCollectorStandard.Domain.Facades;
using System;
using System.Linq;

namespace CardCollectorMVPTest.Presenters
{
    public interface IAddSetPresenter
    {
        void CreateSet();
        void CancelCreateSet();
        void SetView(AddSet View);
    }

    public class AddSetPresenter : BasePresenter<AddSet>, IAddSetPresenter
    {        
        public ICardFacade CardFacade { get; set; }

        public void CancelCreateSet()
        {
            View.CloseForm();
        }

        public new void SetView(AddSet View)
        {
            base.SetView(View);
        }

        public void CreateSet()
        {
            var setName = View.GetCurrentName();
            var cards = View.GetCurrentCards().Split(new string[] { Environment.NewLine, "\r\n", "\n" }, StringSplitOptions.None).ToList();
            this.CardFacade.CreateSet(new CreateSetRequestDto
            {
                SetName = setName,
                CardsToAdd = cards
            });
            View.CloseForm();
        }
    }
}
