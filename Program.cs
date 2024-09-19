using Microsoft.EntityFrameworkCore;
using REST_API.Data;
using REST_API.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserContext>(opt =>
    opt.UseInMemoryDatabase("User"));
builder.Services.AddDbContext<BakeryContext>(opt =>
    opt.UseInMemoryDatabase("Bakery"));
builder.Services.AddDbContext<OrderContext>(opt =>
    opt.UseInMemoryDatabase("Order"));

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
