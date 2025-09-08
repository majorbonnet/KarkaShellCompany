using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public required string Name { get; set; }
        public required string ApiKey { get; set; }
        public string? Gw2Name { get; set; }
    }
}
