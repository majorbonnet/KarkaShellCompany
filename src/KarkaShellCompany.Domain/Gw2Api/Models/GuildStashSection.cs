using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Gw2Api.Models
{
    public class GuildStashSection
    {
        [JsonPropertyName("upgrade_id")]
        public required int UpgradeId { get; set; }
        [JsonPropertyName("size")]
        public required int Size { get; set; }
        [JsonPropertyName("coins")]
        public required long Coins { get; set; }
        [JsonPropertyName("inventory")]
        public required InventoryItem?[] Inventory { get; set; }

        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
        }
    }
}
