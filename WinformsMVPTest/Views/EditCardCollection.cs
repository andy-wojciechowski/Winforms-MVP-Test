using System;
using System.Windows.Forms;
using WinformsMVPTest.DependencyResolution;
using WinformsMVPTest.Interfaces.Presenters;
using WinformsMVPTest.Interfaces.Views;
using WinformsMVPTest.ViewModels;

namespace WinformsMVPTest.Views
{
	public partial class EditCardCollection : Form, IEditCardCollectionView
    {
        public IEditCardCollectionPresenter Presenter { get; set; }
        private EditCardCollectionViewModel Model { get; set; }
        private Guid SetId { get; set; }

		public DataGridView CardsNotOwnedGrid => this.cardsNotOwnedGrid;

		public DataGridView CardsOwnedGrid => this.cardsOwnedGrid;

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

        public Guid GetSetID()
        {
            return this.SetId;
        }
    }
}
