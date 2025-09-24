using Microsoft.AspNetCore.Components;
using KarkaShellCompany.Blazor.Services;
using KarkaShellCompany.Domain.Models;

namespace KarkaShellCompany.Blazor.Components.Pages;

public partial class Admin
{
    private IEnumerable<Item> _items = Enumerable.Empty<Item>();

    [Inject]
    public required AdminService _adminService { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        // TODO: load total count, last updated, and paging instead of showing full list
        if (firstRender)
        {
            //_items = await _adminService.GetItemsAsync(string.Empty);
            StateHasChanged();
        }
    }

    private async Task RefreshItems()
    {
        await _adminService.RefreshItemsAsync();
    }
}
