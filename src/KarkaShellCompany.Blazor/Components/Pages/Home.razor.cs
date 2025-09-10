namespace KarkaShellCompany.Blazor.Components.Pages;

using Microsoft.AspNetCore.Components;

public partial class Home
{
    [Inject]
    public required AdminService _adminService { get; set; }

    private bool _isLoading;

    IEnumerable<Domain.Models.Item> _items = Array.Empty<Domain.Models.Item>();

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
        try
        {
            _items = await _adminService.GetItemsAsync(string.Empty);
        }
        finally
        {
            _isLoading = false;
        }
    }
}