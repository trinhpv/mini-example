using Microsoft.EntityFrameworkCore;
using MiniExample.Data.Repositories.Interfaces;
using MiniExample.Data.Repositories.Repositories;
using MiniExample.Service.Interfaces;
using MiniExample.Service.Services;
using MiniExample.Data.Datacontext;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("MiniContext");
builder.Services.AddDbContext<MiniContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IMakerRepository, MakerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IMakerService, MakerService>();
builder.Services.AddScoped<IProductService, ProductService>();





builder.Services.AddControllers().AddJsonOptions(options =>
             options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
