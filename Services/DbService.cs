using BookCollection.Db;
using BookCollection.Db.Entities;
using Microsoft.EntityFrameworkCore;


#nullable enable

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
                query = query.Where(x => x.Author.ToLower() == author.ToLower());
            }

            if (year != null)
            {
                query = query.Where(x => x.Year == year);
            }

            if (publisher != null)
            {
                query = query.Where(x => x.Publisher != null && x.Publisher.ToLower() == publisher.ToLower());
            }

            return await query.ToArrayAsync();
        }

        public async Task<BookDbEntity> FindBookAsync(int bookId)
        {
            return await _context.Books.FindAsync(bookId);
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            var bookToDelete = await FindBookAsync(bookId);

            if (bookToDelete == null) 
            {
                return false;
            }

             _context.Remove(bookToDelete);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
