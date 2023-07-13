using BookCollection.Db.Entities;

namespace BookCollection.Models.Responses
{
    public class GetBooksResponse
    {
        public BookDbEntity[] Books { get; set; }
    }
}
