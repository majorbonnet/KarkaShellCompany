using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Models
{
    public class Guild
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Gw2Id { get; set; }
        public bool Included { get; set; }
    }
}
