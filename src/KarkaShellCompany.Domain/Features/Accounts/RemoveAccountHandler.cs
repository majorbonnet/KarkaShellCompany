using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarkaShellCompany.Domain;

namespace KarkaShellCompany.Domain.Features.Accounts
{
    public class RemoveAccountHandler : IRequestHandler<RemoveAccount>
    {
        private readonly KarkaShellCompanyContext _context;
        public RemoveAccountHandler(KarkaShellCompanyContext context)
        {
            _context = context;
        }
        public async Task HandleAsync(RemoveAccount command)
        {
            var account = await _context.Accounts.FindAsync(command.Account.AccountId);

            if (account is null)
            {
                throw new InvalidOperationException("Account not found.");
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }
    }
}
