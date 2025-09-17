using KarkaShellCompany.Domain.Features.Accounts;
using KarkaShellCompany.Domain.Features.Guilds;
using KarkaShellCompany.Domain.Features.Items;
using KarkaShellCompany.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace KarkaShellCompany.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        // Register domain services here
        services.AddScoped<IDispatcher, Dispatcher>();

        services.AddScoped<IRequestHandler<AddAccount, Account>, AddAccountHandler>();
        services.AddScoped<IRequestHandler<GetAccounts, List<Account>>, GetAccountsHandler>();
        services.AddScoped<IRequestHandler<RemoveAccount>, RemoveAccountHandler>();

        services.AddScoped<IRequestHandler<AddGuild, Guild>, AddGuildHandler>();
        services.AddScoped<IRequestHandler<GetGuilds, List<Guild>>, GetGuildsHandler>();
        services.AddScoped<IRequestHandler<RefreshGuilds, List<Guild>>, RefreshGuildsHandler>();
        services.AddScoped<IRequestHandler<ToggleGuildInclusion>, ToggleGuildInclusionHandler>();

        services.AddScoped<IRequestHandler<GetItems, IEnumerable<Item>>, GetItemsHandler>();
        services.AddScoped<IRequestHandler<RefreshItems>, RefreshItemsHandler>();

        return services;
    }
}

