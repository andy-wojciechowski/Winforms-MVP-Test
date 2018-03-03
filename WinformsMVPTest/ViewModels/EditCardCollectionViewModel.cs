using System;
using System.ComponentModel;

namespace WinformsMVPTest.ViewModels
{
    public class EditCardCollectionViewModel
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
