using BookCollection.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Db
{
    public class BookCollectionDbContext : DbContext
    {
        public BookCollectionDbContext(DbContextOptions<BookCollectionDbContext> options) : base(options)
        {

        }


        public DbSet<BookDbEntity> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDbEntity>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<BookDbEntity>()
                .HasIndex(p => new { p.Title, p.Author, p.Year })
                .IsUnique()
                .HasDatabaseName("IX_TitleAuthorYear"); ;

        }
    }
}
