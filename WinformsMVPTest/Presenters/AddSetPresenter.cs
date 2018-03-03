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
            var cards = this.View.CardsTextBox.Text.Split(new string[] { Environment.NewLine, "\r\n", "\n" }, StringSplitOptions.None).ToList();
            this.CardFacade.CreateSet(new CreateSetRequestDto
            {
                SetName = this.View.NameTextBox.Text,
                CardsToAdd = cards
            });
            View.CloseForm();
        }
    }
}
