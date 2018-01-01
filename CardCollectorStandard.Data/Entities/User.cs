using System;

namespace CardCollectorStandard.Data.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
    }
}
