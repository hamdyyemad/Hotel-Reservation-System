using HotelBooking.API.Middleware;
using HotelBooking.Application.Services;
using HotelBooking.Domain.Models.Profiles;
using HotelBooking.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Register DbContext
builder.Services.AddDbContext<Context>();

// AutoMapper Assembly with Profiles
builder.Services.AddAutoMapper(typeof(RoomProfile).Assembly);

// Register Application Services
builder.Services.AddScoped<MapperService>();
builder.Services.AddScoped<ValidationService>();
builder.Services.AddScoped<RoomService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowAll");

// Add Exception Handling Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

