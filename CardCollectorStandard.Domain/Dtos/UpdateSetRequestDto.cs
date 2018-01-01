using System;

namespace CardCollectorStandard.Domain.Dtos
{
    public class UpdateSetRequestDto
    {
        public Guid SetID { get; set; }
        public string CardToAdd { get; set; }
    }
}
