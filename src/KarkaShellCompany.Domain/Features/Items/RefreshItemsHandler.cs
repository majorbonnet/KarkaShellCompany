using KarkaShellCompany.Domain.Gw2Api;
using KarkaShellCompany.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Features.Items
{
    public class RefreshItemsHandler : IRequestHandler<RefreshItems>
    {
        private readonly KarkaShellCompanyContext _context;

        public RefreshItemsHandler(KarkaShellCompanyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task HandleAsync(RefreshItems command)
        {
            var knownItems = _context.Items
                .Select(i => i.Id)
                .ToList();

            var gw2ItemIdsRequest = new GetItemIds();
            var gw2ItemIds = await gw2ItemIdsRequest.ExecuteAsync();

            var newItemIds = gw2ItemIds.Except(knownItems).ToList();

            if (newItemIds.Count > 0)
            {                 
                var gw2ItemInfoRequest = new GetItemInfo();

                while (newItemIds.Count > 0)
                {
                    // Limit the number of items to fetch in one request to avoid hitting API limits
                    var batchSize = Math.Min(200, newItemIds.Count);
                    var batch = newItemIds.Take(batchSize).ToList();
                    newItemIds = newItemIds.Skip(batchSize).ToList();
                    var newItems = await gw2ItemInfoRequest.ExecuteAsync(batch);
                    foreach (var item in newItems)
                    {
                        _context.Items.Add(new Item { Id = item.Id, ItemJson = System.Text.Json.JsonSerializer.Serialize(item), Name = item.Name, Type = item.Type });
                    }

                    await _context.SaveChangesAsync();
                }            
            }
        }
    }
}
