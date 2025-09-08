using KarkaShellCompany.Domain;
using KarkaShellCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Features.Guilds
{
    public class GetGuildsHandler : IRequestHandler<GetGuilds, List<Guild>>
    {
        private readonly KarkaShellCompanyContext _context;
        public GetGuildsHandler(KarkaShellCompanyContext context)
        {
            _context = context;
        }
        public async Task<List<Guild>> HandleAsync(GetGuilds request)
        {
            return await _context.Guilds.ToListAsync();
        }
    }
}
