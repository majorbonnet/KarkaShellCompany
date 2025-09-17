using KarkaShellCompany.Domain;
using KarkaShellCompany.Domain.Features.Items;
using KarkaShellCompany.Domain.Gw2Api;
using KarkaShellCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.AddServiceDefaults();

var connectionString = builder.Configuration.GetConnectionString("karkashellco");
builder.Services.AddDbContextFactory<KarkaShellCompanyContext>(options =>
{
    options.UseNpgsql(connectionString)
        .UseSnakeCaseNamingConvention()
        .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
});

builder.EnrichNpgsqlDbContext<KarkaShellCompanyContext>();

builder.Services.AddScoped<IDispatcher, Dispatcher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/items", async (string query, IDispatcher dispatcher) =>
{
    var items = await dispatcher.QueryAsync<GetItems, IEnumerable<Item>>(new GetItems() { Query = query });
    return Results.Ok(items);
});

app.MapPatch("/items", async (IDispatcher dispatcher) =>
{
    await dispatcher.SendAsync(new RefreshItems());
});

app.Run();
