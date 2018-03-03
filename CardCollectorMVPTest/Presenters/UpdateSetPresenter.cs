using CardCollectorMVPTest.Interfaces.Presenters;
using CardCollectorMVPTest.Interfaces.Views;
using CardCollectorStandard.Domain.Dtos;
using CardCollectorStandard.Domain.Interfaces.Facades;

namespace CardCollectorMVPTest.Presenters
{
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
