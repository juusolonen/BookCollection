# BookCollection

A simple RESTful backend for managing a book collection

### To compile and run

1. Download and install .NET SDK version 7.0.306 https://dotnet.microsoft.com/en-us/download/dotnet/7.0
2. Navigate to project root `BookCollection/` and run `dotnet run`
3. Send HTTP requests to `http://localhost:9000`


### Available endpoint

- POST /books
    ```
    {
        "title": <required_string>,
        "author": <required_string>,
        "year": <required_int>,
        "publisher": <optional_string>,
        "description": <optional_string>
    }
    ```
- GET /books
	- optional query parameters:
		- author: string
		- year: int
		- publisher: string
		
- GET /books/\<id>
- Delete /books/\<id>
