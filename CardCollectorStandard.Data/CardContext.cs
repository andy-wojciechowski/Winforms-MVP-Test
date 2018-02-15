using CardCollectorStandard.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardCollectorStandard.Data
{
    public class CardContext : DbContext
    {
        public CardContext(DbContextOptions<CardContext> options) : base(options) { }

        public DbSet<CardSet> CardSets { get; set; }
        public DbSet<Card> Cards { get; set; }
        /// <remarks>Note this database is not located on a server and was created as a local SQL server DB. This DB will need to be recreated in order for the program to function.</remarks>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CardDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardSet>().ToTable("CardSet");
            modelBuilder.Entity<Card>().ToTable("Card");
            modelBuilder.Entity<CardSet>().HasKey(s => s.ID);
            modelBuilder.Entity<Card>().HasKey(c => c.ID);
        }
    }
}
