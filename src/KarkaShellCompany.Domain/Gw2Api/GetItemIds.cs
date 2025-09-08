using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Gw2Api
{
    public class GetItemIds : Request
    {
        public async Task<List<int>> ExecuteAsync()
        {
            return await GetResponse<List<int>>(HttpMethod.Get, "items");
        }
    }
}
