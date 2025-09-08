using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Gw2Api.Models
{

    public class GuildInfo
    {
        [JsonPropertyName("level")]
        public required int Level { get; set; }
        [JsonPropertyName("motd")]
        public required string Motd { get; set; }
        [JsonPropertyName("influence")]
        public required int Influence { get; set; }
        [JsonPropertyName("aetherium")]
        public required int Aetherium { get; set; }
        [JsonPropertyName("resonance")]
        public required int Resonance { get; set; }
        [JsonPropertyName("favor")]
        public required int Favor { get; set; }
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("tag")]
        public required string Tag { get; set; }
        [JsonPropertyName("emblem")]
        public required Emblem Emblem { get; set; }
    }

    public class Emblem
    {
        [JsonPropertyName("background")]
        public required Background Background { get; set; }
        [JsonPropertyName("foreground")]
        public required Foreground Foreground { get; set; }
        [JsonPropertyName("flags")]
        public required string[] Flags { get; set; }
    }

    public class Background
    {
        [JsonPropertyName("id")]
        public required int Id { get; set; }
        [JsonPropertyName("colors")]
        public required int[] Colors { get; set; }
    }

    public class Foreground
    {
        [JsonPropertyName("id")]
        public required int Id { get; set; }
        [JsonPropertyName("colors")]
        public required int[] Colors { get; set; }
    }

}
