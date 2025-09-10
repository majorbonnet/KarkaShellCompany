using System.Runtime.CompilerServices;
using KarkaShellCompany.Domain;
using KarkaShellCompany.Domain.Features.Items;
using KarkaShellCompany.Domain.Models;

namespace KarkaShellCompany.Blazor;

public class AdminService
{
    private readonly IDispatcher _dispatcher;

    public AdminService(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public async Task<IEnumerable<Item>> GetItemsAsync(string query, CancellationToken cancellationToken = default)
    {
        var items = await _dispatcher.QueryAsync<GetItems, IEnumerable<Item>>(new GetItems() { Query = query });

        return items;
    }


    public async Task RefreshItemsAsync(CancellationToken cancellationToken = default)
    {
        await _dispatcher.SendAsync(new RefreshItems());
    }
}