
using CleanArchitecture.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Abstractions.Behaviors
{
    public class LogginBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand
    {
        private readonly ILogger<TRequest> _logger;

        public LogginBehaviors(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var name = request.GetType().Name;

            try
            {
                _logger.LogInformation("Ejecutando el command request {name}",name);
                var result = await next();

                _logger.LogInformation("El comando {CommandName} fue ejecutado correctamente", name);

                return result;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "El comando {name} fallo", name);
                throw;
            }
        }
    }

}
