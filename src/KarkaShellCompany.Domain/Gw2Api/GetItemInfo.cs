using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Gw2Api
{
    public class GetItemInfo : Request
    {
        public async Task<List<Models.ItemInfo>> ExecuteAsync(List<int> itemIds)
        {
            if (itemIds == null || !itemIds.Any())
            {
                throw new ArgumentException("Item IDs cannot be null or empty.", nameof(itemIds));
            }

            var uri = $"items?ids={string.Join(",", itemIds)}";

            return await GetResponse<List<Models.ItemInfo>>(HttpMethod.Get, uri);
        }
    }
}
