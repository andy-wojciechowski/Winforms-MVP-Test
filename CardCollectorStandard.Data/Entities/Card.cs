using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardCollectorStandard.Data.Entities
{
    public class Card
    {
        public Guid ID { get; set; }
        public Guid SetID { get; set; }
        public string Name { get; set; }
        public bool IsOwned { get; set; }
    }
}
