using System;

namespace WinformsMVPTest.Domain.Dtos
{
    public class UpdateSetRequestDto
    {
        public Guid SetID { get; set; }
        public string CardToAdd { get; set; }
    }
}
