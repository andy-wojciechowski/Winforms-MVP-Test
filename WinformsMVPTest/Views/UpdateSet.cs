﻿using WinformsMVPTest.DependencyResolution;
using WinformsMVPTest.Interfaces.Presenters;
using WinformsMVPTest.Interfaces.Views;
using System;
using System.Windows.Forms;

namespace WinformsMVPTest.Views
{
	public partial class UpdateSet : Form, IUpdateSetView
    {
        public IUpdateSetPresenter Presenter { get; set; }
        private Guid SetID { get; set; }

		public TextBox NameTextBox => this.txtCardName;

		public UpdateSet(Guid setID)
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

        public void CloseForm()
        {
            this.Close();
        }

        public Guid GetSetID()
        {
            return this.SetID;
        }
    }
}
