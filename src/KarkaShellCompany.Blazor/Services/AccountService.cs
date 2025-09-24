using KarkaShellCompany.Domain;
using KarkaShellCompany.Domain.Features.Accounts;
using KarkaShellCompany.Domain.Models;

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
            var command = new AddAccount(name, apiKey);
            await _dispatcher.SendAsync<AddAccount, Account>(command);
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            var query = new GetAccounts();
            var accounts = await _dispatcher.QueryAsync<GetAccounts, List<Account>>(query);

            return accounts;
        }
    }
}
