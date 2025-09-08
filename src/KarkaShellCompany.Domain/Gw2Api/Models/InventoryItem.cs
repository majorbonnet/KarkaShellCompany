using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Gw2Api.Models
{
    public class InventoryItem
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }

        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
        }
    }
}
