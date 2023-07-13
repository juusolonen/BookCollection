using BookCollection.Models.Requests;
using BookCollection.Models.Responses;
using BookCollection.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BookCollection.Controllers
{
    [Route("/")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("Books")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddBookResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AddBookRequest))]
        public async Task<IActionResult> AddBookAsync([FromBody] AddBookRequest request)
        {
            var response = new AddBookResponse();

            if (request == null || !request.IsValid())
            {
                return BadRequest($"Request is not valid: {JsonSerializer.Serialize(request)}");
            }

            int? newBookId = await _bookService.AddBookAsync(request);

            if (newBookId == null)
            {
                return BadRequest($"Adding book failed with request: {JsonSerializer.Serialize(request)}");
            }

            response.Id = (int)newBookId;
            return Ok(response);
        }

        [HttpGet("Books")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBooksResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBooksAsync(string? author, int? year, string? publisher)
        {
            if (!QueryIsValid(author, year, publisher))
            {
              return  BadRequest();
            }

            var books = await _bookService.GetBooksAsync(author, year, publisher);

            return Ok(books);
        }

        private bool QueryIsValid(string? author, int? year, string? publisher)
        {
            var authorIsValid = (author == null) || author != string.Empty;
            var yearIsValid = (year == null) || year is int;
            var publisherIsValid = (publisher == null) || publisher != string.Empty;

            return authorIsValid && yearIsValid && publisherIsValid;
        }
    }
}