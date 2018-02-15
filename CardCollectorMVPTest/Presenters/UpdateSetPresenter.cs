using CardCollectorMVPTest.Forms;
using CardCollectorStandard.Domain.Dtos;
using CardCollectorStandard.Domain.Facades;

namespace CardCollectorMVPTest.Presenters
{
    public interface IUpdateSetPresenter
    {
        void UpdateSet();
        void CancelUpdate();
        void SetView(UpdateSet View);
    }

    public class UpdateSetPresenter : IUpdateSetPresenter
    {
        public ICardFacade CardFacade { get; set; }
        private UpdateSet View { get; set; }

        public void SetView(UpdateSet View)
        {
            this.View = View;
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
