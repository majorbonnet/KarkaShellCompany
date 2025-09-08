using KarkaShellCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Features.Guilds
{
    public class RefreshGuildsHandler : IRequestHandler<RefreshGuilds, List<Guild>>
    {
        private readonly KarkaShellCompanyContext _context;
        public RefreshGuildsHandler(KarkaShellCompanyContext context)
        {
            _context = context;
        }
        public async Task<List<Guild>> HandleAsync(RefreshGuilds command)
        {
            List<string> visitedGuildIds = new List<string>();

            foreach (var account in _context.Accounts)
            {
                var apiCommand = new Gw2Api.GetAccount(account);
                var accountInfo = await apiCommand.ExecuteAsync();

                if (accountInfo is null || accountInfo.Guilds.Length == 0)
                {
                    continue; // Skip if no guilds found for this account
                }

                foreach (var guildId in accountInfo.Guilds)
                {
                    visitedGuildIds.Add(guildId);

                    var existingGuild = await _context.Guilds.FirstOrDefaultAsync(g => g.Gw2Id == guildId);

                    // possible TODO: check if guild name has changed
                    if (existingGuild is null)
                    {
                        var guildInfoequest = new Gw2Api.GetGuild(account);
                        var guildInfo = await guildInfoequest.ExecuteAsync(guildId);

                        await _context.Guilds.AddAsync(new Guild { Name = guildInfo.Name, Gw2Id = guildInfo.Id });
                    }
                }

                var unvisitedGuilds = _context.Guilds.Where(g => !visitedGuildIds.Contains(g.Gw2Id)).ToList();

                foreach (var guild in unvisitedGuilds)
                {
                    _context.Guilds.Remove(guild);
                }

                await _context.SaveChangesAsync();
            }

            return await _context.Guilds.ToListAsync();
        }
    }
}
