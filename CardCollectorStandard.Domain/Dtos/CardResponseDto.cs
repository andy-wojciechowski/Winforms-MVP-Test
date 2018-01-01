﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CardCollectorStandard.Domain.Dtos
{
    public class CardResponseDto
    {
        public Guid SetID { get; set; }
        public string Name { get; set; }
        public bool IsOwned { get; set; }
    }
}
