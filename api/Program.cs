using API.Data;
using Microsoft.EntityFrameworkCore;

// ===== CONFIGURATION =====

// WebApplicationBuilder instance for configuring app
var builder = WebApplication.CreateBuilder(args);

// Add MVC service to the app
builder.Services.AddControllers();

// Add DataContext as a database context to the dependency injection container
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add Cross-Origin Resource Sharing service
builder.Services.AddCors();

// ===== BUILDING =====

// Build configured app
var app = builder.Build();

// Set up CORS middleware in the app pipeline
app.UseCors(
    builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")
);

// Map the controllers to the app pipeline
app.MapControllers();

// Start the app and listen for requests
app.Run();
