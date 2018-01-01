using CardCollectorMVPTest.Forms;
using CardCollectorMVPTest.ViewModels;
using CardCollectorStandard.Domain.Facades;
using System;
using System.Linq;
using AutoMapper;
using System.ComponentModel;

namespace CardCollectorMVPTest.Presenters
{
    public interface IEditCardCollectionPresenter
    {
        void FillLists();
        void AddToCollection();
        void RemoveFromCollection();
        void Save();
        void Cancel();
        void SetView(EditCardCollection View);
    }

    public class EditCardCollectionPresenter : BasePresenter<EditCardCollection>, IEditCardCollectionPresenter
    {
        public ICardFacade CardFacade { get; set; }

        public void Cancel()
        {
            View.CloseForm();
        }

        public new void SetView(EditCardCollection View)
        {
            base.SetView(View);
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
