using System;
using System.ComponentModel;

namespace CardCollectorMVPTest.ViewModels
{
    public class EditCardCollectionViewModel : BaseViewModel
    {
        public BindingList<CardViewModel> NotOwnedCards { get; set; }
        public BindingList<CardViewModel> OwnedCards { get; set; }
    }

    public class CardViewModel
    {
        public Guid SetID { get; set; }
        public string Name { get; set; }
        public bool IsOwned { get; set; }
    }
}
