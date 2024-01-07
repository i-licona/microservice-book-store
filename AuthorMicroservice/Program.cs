#nullable disable
using System.Reflection;
using AuthorMicroservice.Aplication;
using AuthorMicroservice.Persistence;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

internal class Program
{
  private static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    string connectionString = builder.Configuration.GetConnectionString("DevConnection");
    // Add services to the container.

    builder.Services.AddControllers().AddFluentValidation(
      cfg => cfg.RegisterValidatorsFromAssemblyContaining<Create>()
    );

    builder.Services.AddAutoMapper();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<AuthorContext>(options =>
    {
      options.UseNpgsql(connectionString);
    });
    builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
    
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
  }
}