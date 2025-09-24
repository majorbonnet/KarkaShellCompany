using KarkaShellCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KarkaShellCompany.Domain.Features.Items
{
    public class GetItemsHandler : IRequestHandler<GetItems, IEnumerable<Item>>
    {
        private readonly KarkaShellCompanyContext _context;

        public GetItemsHandler(KarkaShellCompanyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> HandleAsync(GetItems request)
        {
            return await _context.Items.ToListAsync();
        }
    }
}