using System;
using System.Windows.Forms;

namespace WinformsMVPTest.Interfaces.Views
{
	public interface IEditCardCollectionView
	{
		DataGridView CardsNotOwnedGrid { get; }
		DataGridView CardsOwnedGrid { get; }
		void CloseForm();
		Guid GetSetID();
	}
}
