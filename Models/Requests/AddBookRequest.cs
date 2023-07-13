namespace BookCollection.Models.Requests
{    public class AddBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string? Publisher { get; set; }
        public string? Description { get; set; }

        public bool IsValid()
        {
            return (!string.IsNullOrWhiteSpace(Title)
                && !string.IsNullOrWhiteSpace(Author)
                && (Year is int)
                && (Publisher != string.Empty)
                && (Description != string.Empty));
        }
    }
}
