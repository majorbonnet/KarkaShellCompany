using KarkaShellCompany.Domain.Models;

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
            return await Task.FromResult(_context.Items.AsEnumerable());
        }
    }
}