using CardCollectorMVPTest.Forms;
using CardCollectorStandard.Domain.Dtos;
using CardCollectorStandard.Domain.Facades;

namespace CardCollectorMVPTest.Presenters
{
    public interface IUpdateSetPresenter
    {
        void UpdateSet();
        void CancelUpdate();
        void SetView(IUpdateSetView View);
    }

    public class UpdateSetPresenter : IUpdateSetPresenter
    {
        public ICardFacade CardFacade { get; set; }
        private IUpdateSetView View { get; set; }

        public void SetView(IUpdateSetView View)
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
