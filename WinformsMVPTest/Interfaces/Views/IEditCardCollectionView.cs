using System.Windows.Forms;
using WinformsMVPTest.Interfaces.Presenters;

namespace WinformsMVPTest.Interfaces.Views
{
	public interface IEditCardCollectionView
	{
		DataGridView CardsNotOwnedGrid { get; }
		DataGridView CardsOwnedGrid { get; }
		void CloseForm();
		void SetPresenter(IEditCardCollectionPresenter presenter);
	}
}
