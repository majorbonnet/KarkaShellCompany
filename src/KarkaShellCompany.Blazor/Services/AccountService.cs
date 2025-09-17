using KarkaShellCompany.Domain;

namespace KarkaShellCompany.Blazor.Services
{
    public class AccountService
    {
        private readonly IDispatcher _dispatcher;

        public AccountService(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public async Task AddAccountAsync(string name, string apiKey)
        {
            var command = new Domain.Features.Accounts.AddAccount(name, apiKey);
            await _dispatcher.SendAsync(command);
        }

        public async Task GetAccountsAsync()
        {
            var query = new Domain.Features.Accounts.GetAccounts();
            var accounts = await _dispatcher.QueryAsync<Domain.Features.Accounts.GetAccounts, List<Domain.Models.Account>>(query);
        }
    }
}
