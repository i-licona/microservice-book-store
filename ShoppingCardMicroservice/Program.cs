using Microsoft.EntityFrameworkCore;
using ShoppingCardMicroservice.Persistencia;

var builder = WebApplication.CreateBuilder(args);
var devConnection = builder.Configuration.GetConnectionString("DevConnection");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShoppingDbContext>( options =>
{
    options.UseSqlServer( devConnection );
});

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
