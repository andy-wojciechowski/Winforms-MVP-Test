using WinformsMVPTest.Interfaces.Views;

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
	}
}
