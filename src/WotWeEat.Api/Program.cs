using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WotWeEat.DataAccess.EFCore;
using AutoMapper;
using WotWeEat.DataAccess.EFCore.Model;
using WotWeEat.DataAccess.Interfaces;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Meal)); // Register AutoMapper
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<WotWeEatDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});
// Register your repository with a scoped lifetime
builder.Services.AddScoped<IWotWeEatRepository, WotWeEatRepository>();

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
