using WinformsMVPTest.DependencyResolution;
using WinformsMVPTest.Interfaces.Presenters;
using WinformsMVPTest.Interfaces.Views;
using WinformsMVPTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinformsMVPTest.Forms
{
	public partial class EditCardCollection : Form, IEditCardCollectionView
    {
        public IEditCardCollectionPresenter Presenter { get; set; }
        private DataGridViewRow _lastOwnedRow { get; set; }
        private DataGridViewRow _lastNotOwnedRow { get; set; }
        private EditCardCollectionViewModel Model { get; set; }
        private Guid SetId { get; set; }
        private bool IsDataBound { get; set; }

        public EditCardCollection(Guid setID)
        {
            InitializeComponent();
            using (var container = ObjectFactory.GetContainer())
            {
                this.Presenter = container.GetInstance<IEditCardCollectionPresenter>();
            }
            Presenter.SetView(this);
            this.SetId = setID;
        }

        private void EditCardCollection_Load(object sender, EventArgs e)
        {
            Presenter.FillLists();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Presenter.AddToCollection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presenter.Cancel();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Presenter.Save();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Presenter.RemoveFromCollection();
        }

        public void CloseForm()
        {
            this.Close();
        }

        public void SetViewModel(EditCardCollectionViewModel viewModel)
        {
            this.Model = viewModel;

            IsDataBound = false;
            this.cardsNotOwnedGrid.DataSource = this.Model.NotOwnedCards;
            this.cardsOwnedGrid.DataSource = this.Model.OwnedCards;
            IsDataBound = true;

            if (this.cardsNotOwnedGrid.Rows.Count != 0) { this.cardsNotOwnedGrid.Rows[0].Selected = true; }
            if (this.cardsOwnedGrid.Rows.Count != 0) { this.cardsOwnedGrid.Rows[0].Selected = true; }

            this.HideColumnsFromDataGridView(this.cardsNotOwnedGrid, new string[] { "Name" }.ToList());
            this.HideColumnsFromDataGridView(this.cardsOwnedGrid, new string[] { "Name" }.ToList());
        }

        public void MakeCardOwned()
        {
            var row = this.cardsNotOwnedGrid.SelectedRows[0];
            var item = this.Model.NotOwnedCards.Single(x => x.Name == (string)row.Cells["Name"].Value);
            this.Model.NotOwnedCards.Remove(item);
            this.Model.OwnedCards.Add(new CardViewModel
            {
                SetID = item.SetID,
                Name = item.Name,
                IsOwned = true
            });
        }

        public void MakeCardNotOwned()
        {
            var row = this.cardsOwnedGrid.SelectedRows[0];
            var item = this.Model.OwnedCards.Single(x => x.Name == (string)row.Cells["Name"].Value);
            this.Model.OwnedCards.Remove(item);
            this.Model.NotOwnedCards.Add(new CardViewModel
            {
                SetID = item.SetID,
                Name = item.Name,
                IsOwned = false
            });
        }

        public IList<CardViewModel> GetNotOwnedCards()
        {
            return this.Model.NotOwnedCards.ToList();
        }

        public IList<CardViewModel> GetOwnedCards()
        {
            return this.Model.OwnedCards.ToList();
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

        public Guid GetSetID()
        {
            return this.SetId;
        }
    }
}
