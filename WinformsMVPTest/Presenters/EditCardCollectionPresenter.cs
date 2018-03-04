using AutoMapper;
using WinformsMVPTest.Interfaces.Presenters;
using WinformsMVPTest.Interfaces.Views;
using WinformsMVPTest.ViewModels;
using WinformsMVPTest.Domain.Interfaces.Facades;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsMVPTest.Presenters
{
	public class EditCardCollectionPresenter : IEditCardCollectionPresenter
	{
		public ICardFacade CardFacade { get; set; }
		private IEditCardCollectionView View { get; set; }
		private BindingList<CardViewModel> NotOwnedCards { get; set; }
		private BindingList<CardViewModel> OwnedCards { get; set; }
		private Guid SetID { get; set; }

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
            var cards = this.CardFacade.GetCardsFromSet(this.SetID);
			this.NotOwnedCards = new BindingList<CardViewModel>(cards.Where(x => x.IsOwned == false).Select(x => Mapper.Map<CardViewModel>(x)).ToList());
			this.OwnedCards = new BindingList<CardViewModel>(cards.Where(x => x.IsOwned == true).Select(x => Mapper.Map<CardViewModel>(x)).ToList());

			this.View.CardsNotOwnedGrid.DataSource = this.NotOwnedCards;
			this.View.CardsOwnedGrid.DataSource = this.OwnedCards;

			if (this.View.CardsNotOwnedGrid.Rows.Count != 0) { this.View.CardsNotOwnedGrid.Rows[0].Selected = true; }
			if (this.View.CardsOwnedGrid.Rows.Count != 0) { this.View.CardsOwnedGrid.Rows[0].Selected = true; }

			this.HideColumnsFromDataGridView(this.View.CardsNotOwnedGrid, new string[] { "Name" }.ToList());
			this.HideColumnsFromDataGridView(this.View.CardsOwnedGrid, new string[] { "Name" }.ToList());
        }

        public void Save()
        {
            foreach(var card in this.OwnedCards)
            {
                this.CardFacade.AddCardToCollection(card.Name);
            }

            foreach(var card in this.NotOwnedCards)
            {
                this.CardFacade.RemoveCardFromCollection(card.Name);
            }

            View.CloseForm();
        }

        public void AddToCollection()
        {
			if(this.View.CardsNotOwnedGrid.SelectedRows.Cast<DataGridViewRow>().Any())
			{
				var row = this.View.CardsNotOwnedGrid.SelectedRows[0];
				var item = this.NotOwnedCards.Single(x => x.Name == (string)row.Cells["Name"].Value);
				this.NotOwnedCards.Remove(item);
				this.OwnedCards.Add(new CardViewModel
				{
					SetID = item.SetID,
					Name = item.Name,
					IsOwned = true
				});
			}
		}

        public void RemoveFromCollection()
        {
			if(this.View.CardsOwnedGrid.SelectedRows.Cast<DataGridViewRow>().Any())
			{
				var row = this.View.CardsOwnedGrid.SelectedRows[0];
				var item = this.OwnedCards.Single(x => x.Name == (string)row.Cells["Name"].Value);
				this.OwnedCards.Remove(item);
				this.NotOwnedCards.Add(new CardViewModel
				{
					SetID = item.SetID,
					Name = item.Name,
					IsOwned = false
				});
			}
		}

		private void HideColumnsFromDataGridView(DataGridView grid, IList<string> columnsToShow)
		{
			foreach (DataGridViewColumn column in grid.Columns)
			{
				if (!columnsToShow.Contains(column.Name))
				{
					column.Visible = false;
				}
			}
		}

		public void SetSetID(Guid setID)
		{
			this.SetID = setID;
		}

		public void SelectEntireRow(DataGridView grid)
		{
			if(grid.SelectedCells.Cast<DataGridViewCell>().Any())
			{
				var cell = grid.SelectedCells[0];
				cell.OwningRow.Selected = true;
			}
		}
	}
}
