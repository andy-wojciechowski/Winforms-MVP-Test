using System;
using WinformsMVPTest.Interfaces.Presenters;
using WinformsMVPTest.Interfaces.Views;
using WinformsMVPTest.Domain.Dtos;
using WinformsMVPTest.Domain.Interfaces.Facades;

namespace WinformsMVPTest.Presenters
{
	public class UpdateSetPresenter : IUpdateSetPresenter
	{
		public ICardFacade CardFacade { get; set; }
		private IUpdateSetView View { get; set; }
		private Guid SetID { get; set; }

		public void SetView(IUpdateSetView View)
		{
			this.View = View;
		}

		public void UpdateSet()
		{
			var cardToAdd = this.View.NameTextBox.Text;

			this.CardFacade.UpdateSet(new UpdateSetRequestDto
			{
				SetID = this.SetID,
				CardToAdd = cardToAdd
			});
			View.CloseForm();
		}

		public void CancelUpdate()
		{
			View.CloseForm();
		}

		public void SetSetID(Guid setID)
		{
			this.SetID = setID;
		}
	}
}
