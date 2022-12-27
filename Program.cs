using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using OmniaWebService.Services;
using OmniaWebService.Services.Infrastructure;
using OmniaWebService.Services.GestioneSpese;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OmniaDbContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddTransient<IDatabaseAccessor, SqliteDatabaseAccessor>();
builder.Services.AddTransient<ISpeseService, SpeseService>();

var app = builder.Build();
app.UseCors(options =>
    options
        .WithOrigins("http://localhost:4200")
        .WithMethods("POST", "PUT", "DELETE", "GET")
        .AllowAnyHeader()
);
app.MapControllers();
app.Run();
