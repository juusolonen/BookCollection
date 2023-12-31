using BookCollection.Db;
using BookCollection.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (args.Length > 0 && args[0] == "ClearDb")
{
    //Delete dbFile for a fresh start every time
    try
    {
        string path = Directory.GetCurrentDirectory();
        string dbFile = Directory.GetFiles(path, "*.db").First();
        File.Delete(dbFile);
    }
    catch
    {
        //No file found, no need to do anything
    }
}



builder.Services.AddDbContext<BookCollectionDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DbService>();
builder.Services.AddScoped<BookService>();

builder.Services.AddControllers();

var app = builder.Build();

// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<BookCollectionDbContext>();

    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();