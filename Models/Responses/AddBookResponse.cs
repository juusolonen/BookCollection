namespace BookCollection.Models.Responses
{
    public class AddBookResponse
    {
        public AddBookResponse() { }
        public AddBookResponse(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
