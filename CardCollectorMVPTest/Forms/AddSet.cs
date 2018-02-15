using CardCollectorMVPTest.DependencyResolution;
using CardCollectorMVPTest.Presenters;
using System;
using System.Windows.Forms;

namespace CardCollectorMVPTest.Forms
{
    public interface IAddSetView
    {
        string GetCurrentName();
        string GetCurrentCards();
        void CloseForm();
    }

    public partial class AddSet : Form, IAddSetView
    {
        public IAddSetPresenter Presenter { get; set; }

        public AddSet()
        {
            InitializeComponent();
            using (var container = ObjectFactory.GetContainer())
            {
                this.Presenter = container.GetInstance<IAddSetPresenter>();
            }
            Presenter.SetView(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Presenter.CancelCreateSet();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Presenter.CreateSet();
        }

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

    }
}
