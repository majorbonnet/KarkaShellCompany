using KarkaShellCompany.Domain;
using KarkaShellCompany.MigrationService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

var connectionString = builder.Configuration.GetConnectionString("karkashellco");
builder.Services.AddDbContextFactory<KarkaShellCompanyContext>(options =>
{
    options.UseNpgsql(connectionString)
        .UseSnakeCaseNamingConvention()
        .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
});

builder.EnrichNpgsqlDbContext<KarkaShellCompanyContext>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
