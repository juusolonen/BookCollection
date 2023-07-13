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
            var newBook = new BookDbEntity
            {
                Title = request.Title,
                Author = request.Author,
                Year = request.Year,
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
    }
}