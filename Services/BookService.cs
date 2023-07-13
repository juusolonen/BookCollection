using BookCollection.Db.Entities;
using BookCollection.Models.Requests;

namespace BookCollection.Services
{
    public class BookService
    {
        private DbService dbService;
        public BookService(DbService dbService)
        {
            this.dbService = dbService;
        }

        public async Task<int?> AddBookAsync(AddBookRequest request)
        {
            var isValid = (!string.IsNullOrWhiteSpace(request.Title)
                && !string.IsNullOrWhiteSpace(request.Author)
                && (request.Year.HasValue && request.Year is int)
                && (request.Publisher != string.Empty)
                && (request.Description != string.Empty));

            if(!isValid )
            {
                return null;
            }

            var newBook = new BookDbEntity
            {
                Title = request.Title,
                Author = request.Author,
                Year = request.Year!.Value,
                Publisher = request.Publisher,
                Description = request.Description,
            };

            try
            {
                await dbService.AddBookAsync(newBook);
            }
            catch
            {
                return null;
            }

            return newBook.Id;
        }


        public async Task<BookDbEntity[]> GetBooksAsync(string? author, int? year, string? publisher)
        {
            return await dbService.GetBooksAsync(author, year, publisher);
        }

        public async Task<BookDbEntity> FindBookAsync(int bookId)
        {
            return await dbService.FindBookAsync(bookId);
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            return await dbService.DeleteBookAsync(bookId);
        }
    }
}