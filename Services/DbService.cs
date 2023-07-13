using BookCollection.Db;
using BookCollection.Db.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<BookDbEntity[]> GetBooksAsync()
        {
            return await _context.Books.ToArrayAsync();
        }
    }
}
