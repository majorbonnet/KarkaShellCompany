using KarkaShellCompany.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Gw2Api
{
    public abstract class AuthenticatedRequest : Request
    {
        private readonly Account _account;

        public AuthenticatedRequest(Account account)
        {
            _account = account ?? throw new ArgumentNullException(nameof(account));

            this.ModifyRequest = message =>
            {
                message.Headers.Add("Authorization", $"Bearer {_account.ApiKey}");
                return message;
            };
        }
    }
}
