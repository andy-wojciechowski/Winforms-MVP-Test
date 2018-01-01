using CardCollectorMVPTest.Forms;
using CardCollectorStandard.Domain.Dtos;
using CardCollectorStandard.Domain.Facades;
using System;

namespace CardCollectorMVPTest.Presenters
{
    public interface IUpdateSetPresenter
    {
        void UpdateSet();
        void CancelUpdate();
        void SetView(UpdateSet View);
    }

    public class UpdateSetPresenter : BasePresenter<UpdateSet>, IUpdateSetPresenter
    {
        public ICardFacade CardFacade { get; set; }

        public new void SetView(UpdateSet View)
        {
            base.SetView(View);
        }

        public void UpdateSet()
        {
            var cardToAdd = View.GetCardToAdd();

            this.CardFacade.UpdateSet(new UpdateSetRequestDto
            {
                SetID = View.GetSetID(),
                CardToAdd = cardToAdd
            });
            View.CloseForm();
        }

        public void CancelUpdate()
        {
            View.CloseForm();
        }
    }
}
