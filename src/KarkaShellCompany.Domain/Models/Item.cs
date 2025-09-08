using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Models
{
    public class Item
    {
        public required int Id { get; set; }
        public required string ItemJson { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
    }
}
