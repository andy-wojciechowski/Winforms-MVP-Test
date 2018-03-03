using WinformsMVPTest.Interfaces.Presenters;
using WinformsMVPTest.Interfaces.Views;
using WinformsMVPTest.Domain.Dtos;
using WinformsMVPTest.Domain.Interfaces.Facades;
using System;
using System.Linq;

namespace WinformsMVPTest.Presenters
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
