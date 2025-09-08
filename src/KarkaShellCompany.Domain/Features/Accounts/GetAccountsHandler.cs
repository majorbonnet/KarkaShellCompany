using KarkaShellCompany.Domain;
using KarkaShellCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Features.Accounts
{
    internal class GetAccountsHandler : IRequestHandler<GetAccounts, List<Account>>
    {
        private readonly KarkaShellCompanyContext _context; 

        public GetAccountsHandler(KarkaShellCompanyContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> HandleAsync(GetAccounts command)
        {
            return await _context.Accounts.ToListAsync();
        }
    }
}
