using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Gw2Api.Models
{
    public class AccountMaterialInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("category")]
        public int Category { get; set; }
        [JsonPropertyName("binding")]
        public string? Binding { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
