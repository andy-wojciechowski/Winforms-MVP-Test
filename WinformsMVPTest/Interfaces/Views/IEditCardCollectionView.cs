using WinformsMVPTest.ViewModels;
using System;
using System.Collections.Generic;

namespace WinformsMVPTest.Interfaces.Views
{
	public interface IEditCardCollectionView
	{
		void CloseForm();
		void SetViewModel(EditCardCollectionViewModel viewModel);
		void MakeCardOwned();
		void MakeCardNotOwned();
		IList<CardViewModel> GetNotOwnedCards();
		IList<CardViewModel> GetOwnedCards();
		Guid GetSetID();
	}
}
