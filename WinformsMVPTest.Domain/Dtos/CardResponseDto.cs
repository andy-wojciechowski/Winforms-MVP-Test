using System;

namespace WinformsMVPTest.Domain.Dtos
{
	public class CardResponseDto
	{
		public Guid SetID { get; set; }
		public string Name { get; set; }
		public bool IsOwned { get; set; }
	}
}
