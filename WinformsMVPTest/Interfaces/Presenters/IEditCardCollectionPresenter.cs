using WinformsMVPTest.Interfaces.Views;
using System;
using System.Windows.Forms;

namespace WinformsMVPTest.Interfaces.Presenters
{
	public interface IEditCardCollectionPresenter
    {
		void FillLists();
		void AddToCollection();
		void RemoveFromCollection();
		void Save();
		void Cancel();
		void SetView(IEditCardCollectionView View);
		void SetSetID(Guid setID);
		void SelectEntireRow(DataGridView grid);
	}
}
