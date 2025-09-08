using KarkaShellCompany.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Gw2Api
{
    public class GetAccount : AuthenticatedRequest
    {
        public GetAccount(Account account) : base(account)
        {
        }

        public async Task<Models.AccountInfo> ExecuteAsync()
        {
            return await GetResponse<Models.AccountInfo>(HttpMethod.Get, "account");
        }
    }
}
