using CardCollectorMVPTest.Presenters;
using System;
using System.Windows.Forms;

namespace CardCollectorMVPTest.Forms
{
    public partial class AddSet : View
    {
        public IAddSetPresenter Presenter { get; set; }

        public AddSet() : base()
        {
            InitializeComponent();
            Presenter.SetView(this);
        }

        #region Events

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Presenter.CancelCreateSet();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Presenter.CreateSet();
        }

        #endregion

        #region Interaction

        public void CloseForm()
        {
            this.Close();
        }

        public string GetCurrentName()
        {
            return txtName.Text;
        }

        public string GetCurrentCards()
        {
            return txtCards.Text;
        }

        #endregion

    }
}
