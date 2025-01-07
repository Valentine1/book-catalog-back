using Books.API;
using Books.Application.Extensions;
using Books.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
app.Run();