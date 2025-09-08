using KarkaShellCompany.Domain;
using KarkaShellCompany.Domain.Models;

namespace KarkaShellCompany.Domain.Features.Accounts
{
    public class AddAccountHandler : IRequestHandler<AddAccount, Account>
    {
        private readonly KarkaShellCompanyContext _context;
        public AddAccountHandler(KarkaShellCompanyContext context)
        {
            _context = context;
        }

        public async Task<Account> HandleAsync(AddAccount command)
        {
            var account = new Account
            {
                Name = command.Name,
                ApiKey = command.ApiKey
            };

            var apiCommand = new Gw2Api.GetAccount(account);
            var accountInfo = await apiCommand.ExecuteAsync();

            if (accountInfo is null)
            {
                throw new InvalidOperationException("Failed to retrieve account information from the API.");
            }

            account.Gw2Name = accountInfo.Name;

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();

            return account;
        }
    }
}
