using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarkaShellCompany.Domain.Models;

namespace KarkaShellCompany.Domain.Features.Guilds
{
    public class AddGuildHandler : IRequestHandler<AddGuild, Guild>
    {
        private readonly KarkaShellCompanyContext _context;
        public AddGuildHandler(KarkaShellCompanyContext context)
        {
            _context = context;
        }
        public async Task<Guild> HandleAsync(AddGuild command)
        {
            var guild = new Guild
            {
                Name = command.Name,
                Gw2Id = command.Gw2Id
            };

            await _context.Guilds.AddAsync(guild);
            await _context.SaveChangesAsync();

            return guild;
        }
    }
}
