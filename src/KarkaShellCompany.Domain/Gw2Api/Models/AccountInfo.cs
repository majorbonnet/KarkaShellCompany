using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Gw2Api.Models
{

    public class AccountInfo
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("age")]
        public int Age { get; set; }
        [JsonPropertyName("world")]
        public int World { get; set; }
        [JsonPropertyName("guilds")]
        public required string[] Guilds { get; set; }
        [JsonPropertyName("guild_leader")]
        public required string[] GuildLeader { get; set; }
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
        [JsonPropertyName("access")]
        public required string[] Access { get; set; }
        public bool Commander { get; set; }
        [JsonPropertyName("fractal_level")]
        public int FractalLevel { get; set; }
        [JsonPropertyName("daily_ap")]
        public int DailyAp { get; set; }
        [JsonPropertyName("monthly_ap")]
        public int MonthlyAp { get; set; }
        [JsonPropertyName("wvw_rank")]
        public int WvwRank { get; set; }

        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
        }
    }

}
