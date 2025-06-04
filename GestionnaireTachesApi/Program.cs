using Microsoft.EntityFrameworkCore;
using GestionnaireTachesApi.Data;
using AutoMapper;
using GestionnaireTachesApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TachesDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
