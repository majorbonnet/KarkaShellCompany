using KarkaShellCompany.Domain.Gw2Api.Models;
using KarkaShellCompany.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Gw2Api
{
    internal class GetGuild : AuthenticatedRequest
    {
        public GetGuild(Account account) : base(account)
        {
        }

        public async Task<GuildInfo> ExecuteAsync(string guildId)
        {
            if (string.IsNullOrWhiteSpace(guildId))
            {
                throw new ArgumentException("Guild ID cannot be null or empty.", nameof(guildId));
            }

            return await GetResponse<GuildInfo>(HttpMethod.Get, $"guild/{guildId}");
        }
    }
}
