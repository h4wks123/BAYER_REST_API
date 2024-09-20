using Microsoft.EntityFrameworkCore;
using REST_API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// <summary> initialize db context to use in memory database </summary>
// <remarks> UseInMemoryDatabase for simulating database operations </remarks>
builder.Services.AddDbContext<UserContext>(opt =>
    opt.UseInMemoryDatabase("User"));
builder.Services.AddDbContext<BakeryContext>(opt =>
    opt.UseInMemoryDatabase("Bakery"));
builder.Services.AddDbContext<OrderContext>(opt =>
    opt.UseInMemoryDatabase("Order"));

var app = builder.Build();

// <summary> Configure the HTTP request pipeline. </summary>
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
