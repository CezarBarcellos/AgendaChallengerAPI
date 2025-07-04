using GoogleCalendar.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.Configure<GoogleCalendarConfig>(builder.Configuration.GetSection("GoogleCalendar"));

builder.Services.AddSingleton(sp => sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<GoogleCalendarConfig>>().Value);

var host = builder.Build();