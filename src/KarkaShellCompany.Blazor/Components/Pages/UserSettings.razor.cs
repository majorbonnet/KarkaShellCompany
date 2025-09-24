using KarkaShellCompany.Blazor.Services;
using KarkaShellCompany.Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace KarkaShellCompany.Blazor.Components.Pages;


public partial class UserSettings
{
    private List<Account> _accounts;
    private string _newAccountName = string.Empty;
    private string _newAccountApiKey = string.Empty;

    [Inject]
    public required AccountService AccountService { get; set; }

    public required AuthenticationState AuthenticationState { get; set; }

    public UserSettings()
    {
        _accounts = new List<Account>();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        var principal = AuthenticationState?.User;

        if (firstRender)
        {
            _accounts = await AccountService.GetAccountsAsync();
            StateHasChanged();
        }
    }

    private async Task AddAccount()
    {
        if (!string.IsNullOrWhiteSpace(_newAccountName) && !string.IsNullOrWhiteSpace(_newAccountApiKey))
        {
            await AccountService.AddAccountAsync(_newAccountName, _newAccountApiKey);
            _accounts = await AccountService.GetAccountsAsync();
            _newAccountName = string.Empty;
            _newAccountApiKey = string.Empty;
        }
    }
}
