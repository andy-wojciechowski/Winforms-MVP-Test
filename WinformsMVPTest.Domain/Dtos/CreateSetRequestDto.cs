using System.Collections.Generic;

namespace WinformsMVPTest.Domain.Dtos
{
    public class CreateSetRequestDto
    {
        public string SetName { get; set; }
        public IList<string> CardsToAdd { get; set; }
    }
}
