using System;
using System.Collections.Generic;
using System.Text;

namespace WinformsMVPTest.Domain.Models
{
    public class Card
    {
        public Guid SetID { get; set; }
        public string Name { get; set; }
        public bool IsOwned { get; set; }
    }
}
