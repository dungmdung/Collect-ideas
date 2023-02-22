using Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var configuration = builder.Configuration;
builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

JsonSerializerOptions options = new()
{
    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault
};

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
