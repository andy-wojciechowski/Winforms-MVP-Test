using CardCollectorMVPTest.DependencyResolution;
using CardCollectorMVPTest.Presenters;
using System;
using System.Windows.Forms;

namespace CardCollectorMVPTest.Forms
{
    public partial class UpdateSet : Form
    {
        public IUpdateSetPresenter Presenter { get; set; }
        private Guid SetID { get; set; }

        public UpdateSet(Guid setID) : base()
        {
            InitializeComponent();
            using (var container = ObjectFactory.GetContainer())
            {
                this.Presenter = container.GetInstance<IUpdateSetPresenter>();
            }
            Presenter.SetView(this);
            this.SetID = setID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Presenter.CancelUpdate();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Presenter.UpdateSet();
        }

        #region Interaction

        public string GetCardToAdd()
        {
            return txtCardName.Text;
        }

        public void CloseForm()
        {
            this.Close();
        }

        public Guid GetSetID()
        {
            return this.SetID;
        }

        #endregion

    }
}
