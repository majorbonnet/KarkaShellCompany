using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Gw2Api.Models
{

    public class ItemInfo
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("type")]
        public required string Type { get; set; }
        [JsonPropertyName("level")]
        public required int Level { get; set; }
        [JsonPropertyName("rarity")]
        public required string Rarity { get; set; }
        [JsonPropertyName("vendor_value")]
        public required int VendorValue { get; set; }
        [JsonPropertyName("default_skin")]
        public int? DefaultSkin { get; set; }
        [JsonPropertyName("game_types")]
        public required string[] GameTypes { get; set; }
        [JsonPropertyName("flags")]
        public required string[] Flags { get; set; }
        [JsonPropertyName("restrictions")]
        public required string[] Restrictions { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("chat_link")]
        public required string ChatLink { get; set; }
        [JsonPropertyName("icon")]
        public string? Icon { get; set; }
        [JsonPropertyName("details")]
        public object? Details { get; set; }
    }
}
