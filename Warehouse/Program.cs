using Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Entities;
using Repository;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddFastEndpoints();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDoc();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddDbContext<RepositoryContext>(opt => opt.UseSqlServer(config.GetConnectionString("MsSqlConnection")));
var app = builder.Build();

app.UseDefaultExceptionHandler();
app.UseAuthorization();
app.UseFastEndpoints(c =>
{
    c.Endpoints.Configurator = edp => edp.AllowAnonymous();
});
app.UseSwaggerGen();
app.UseHttpsRedirection();

app.Run();