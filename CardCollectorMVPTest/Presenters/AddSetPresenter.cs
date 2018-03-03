using CardCollectorMVPTest.Interfaces.Presenters;
using CardCollectorMVPTest.Interfaces.Views;
using CardCollectorStandard.Domain.Dtos;
using CardCollectorStandard.Domain.Interfaces.Facades;
using System;
using System.Linq;

namespace CardCollectorMVPTest.Presenters
{
    public class AddSetPresenter : IAddSetPresenter
    {        
        public ICardFacade CardFacade { get; set; }
        private IAddSetView View { get; set; }

        public void CancelCreateSet()
        {
            View.CloseForm();
        }

        public void SetView(IAddSetView View)
        {
            this.View = View;
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
