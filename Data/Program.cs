using Data;
using Data.Abstractions;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

var strConn = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(strConn));

builder.Services.AddScoped<AppDbContext>();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICompromissoRepository, CompromissoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var host = builder.Build();
host.Run();
