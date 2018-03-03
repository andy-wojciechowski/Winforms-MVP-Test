using AutoMapper;
using CardCollectorMVPTest.Interfaces.Presenters;
using CardCollectorMVPTest.Interfaces.Views;
using CardCollectorMVPTest.ViewModels;
using CardCollectorStandard.Domain.Interfaces.Facades;
using System.ComponentModel;
using System.Linq;

namespace CardCollectorMVPTest.Presenters
{
	public class EditCardCollectionPresenter : IEditCardCollectionPresenter
    {
        public ICardFacade CardFacade { get; set; }
        private IEditCardCollectionView View { get; set; }

        public void Cancel()
        {
            View.CloseForm();
        }

        public void SetView(IEditCardCollectionView View)
        {
            this.View = View;
        }

        public void FillLists()
        {
            var viewModel = new EditCardCollectionViewModel();
            var cards = this.CardFacade.GetCardsFromSet(View.GetSetID());
        
            viewModel.NotOwnedCards = new BindingList<CardViewModel>(cards.Where(x => x.IsOwned == false).Select(x => Mapper.Map<CardViewModel>(x)).ToList());
            viewModel.OwnedCards = new BindingList<CardViewModel>(cards.Where(x => x.IsOwned == true).Select(x => Mapper.Map<CardViewModel>(x)).ToList());
            View.SetViewModel(viewModel);
        }

        public void Save()
        {
            var ownedCards = View.GetOwnedCards();
            var notOwnedCards = View.GetNotOwnedCards();

            foreach(var card in ownedCards)
            {
                this.CardFacade.AddCardToCollection(card.Name);
            }

            foreach(var card in notOwnedCards)
            {
                this.CardFacade.RemoveCardFromCollection(card.Name);
            }

            View.CloseForm();
        }

        public void AddToCollection()
        {
            View.MakeCardOwned();
        }

        public void RemoveFromCollection()
        {
            View.MakeCardNotOwned();        
        }
    }
}
