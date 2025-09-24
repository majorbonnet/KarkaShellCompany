using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain
{
    public interface IDispatcher
    {
        Task<TResponse> QueryAsync<TRequest, TResponse>(TRequest request) where TRequest : class;
        Task SendAsync<TRequest>(TRequest request) where TRequest : class;
        Task SendAsync<TRequest, TResponse>(TRequest request) where TRequest : class;
    }

    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> QueryAsync<TRequest, TResponse>(TRequest request) where TRequest : class
        {
            var handler = _serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();

            if (handler is null)
            {
                throw new InvalidOperationException($"No handler registered for request type {typeof(TRequest).Name}");
            }

            return await handler.HandleAsync(request);
        }
        public async Task SendAsync<TRequest>(TRequest request) where TRequest : class
        {
            var handler = _serviceProvider.GetRequiredService<IRequestHandler<TRequest>>();

            if (handler is null)
            {
                throw new InvalidOperationException($"No handler registered for request type {typeof(TRequest).Name}");
            }

            await handler.HandleAsync(request);
        }

        public async Task SendAsync<TRequest, TResponse>(TRequest request) where TRequest : class
        {
            var handler = _serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();

            if (handler is null)
            {
                throw new InvalidOperationException($"No handler registered for request type {typeof(TRequest).Name}");
            }

            await handler.HandleAsync(request);
        }
    }
}
