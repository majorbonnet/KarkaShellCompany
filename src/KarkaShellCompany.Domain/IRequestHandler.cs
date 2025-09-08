using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain
{
    public interface IRequestHandler<TRequest, TResponse> where TRequest : class
    {
        Task<TResponse> HandleAsync(TRequest command);
    }

    public interface IRequestHandler<TRequest> where TRequest : class
    {
        Task HandleAsync(TRequest command);
    }
}