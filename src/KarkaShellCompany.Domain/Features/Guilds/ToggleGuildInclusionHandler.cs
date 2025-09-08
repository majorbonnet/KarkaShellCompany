using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Features.Guilds
{
    public class ToggleGuildInclusionHandler : IRequestHandler<ToggleGuildInclusion>
    {
        private readonly KarkaShellCompanyContext _context;

        public ToggleGuildInclusionHandler(KarkaShellCompanyContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(ToggleGuildInclusion command)
        {
            var guild = await _context.Guilds.FindAsync(command.Guild.Id);

            if (guild is null)
            {
                throw new ArgumentException("Invalid guild", nameof(command));
            }

            //guild.Included = !guild.Included;

            await _context.SaveChangesAsync();
        }
    }
}
