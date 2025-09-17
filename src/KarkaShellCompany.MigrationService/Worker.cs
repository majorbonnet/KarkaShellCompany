using KarkaShellCompany.Domain;
using Microsoft.EntityFrameworkCore;

namespace KarkaShellCompany.MigrationService
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public Worker(IServiceProvider serviceProvider, IHostApplicationLifetime hostApplicationLifetime)
        {
            _serviceProvider = serviceProvider;
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<KarkaShellCompanyContext>();

            await RunMigrationAsync(context, stoppingToken);

            _hostApplicationLifetime.StopApplication();
        }

        private static async Task RunMigrationAsync(KarkaShellCompanyContext context, CancellationToken cancellationToken)
        {
            var strategy = context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                // Run migration in a transaction to avoid partial migration if it fails.
                await context.Database.MigrateAsync(cancellationToken);
            });
        }
    }
}
