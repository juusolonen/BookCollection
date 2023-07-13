using BookCollection.Db;
using BookCollection.Db.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookCollection.Services
{
    public class DbService
    {
        private BookCollectionDbContext _context;
        public DbService(BookCollectionDbContext context)
        {
            _context = context;
        }

        public async Task AddBookAsync(BookDbEntity book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task<BookDbEntity[]> GetBooksAsync(string? author, int? year, string? publisher)
        {
            IQueryable<BookDbEntity> query = _context.Books;

            if (author != null)
            {
                query = query.Where(x => x.Author == author);
            }

            if (year != null)
            {
                query = query.Where(x => x.Year == year);
            }

            if (publisher != null)
            {
                query = query.Where(x => x.Publisher == publisher);
            }

            return await query.ToArrayAsync();
        }
    }
}
