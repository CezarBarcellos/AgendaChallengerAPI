using Data;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var strConn = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(strConn));

builder.Services.AddScoped<AppDbContext>();

var host = builder.Build();
host.Run();
