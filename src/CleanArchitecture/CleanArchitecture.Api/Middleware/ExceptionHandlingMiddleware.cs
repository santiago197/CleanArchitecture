using CleanArchitecture.Application.Exeptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace CleanArchitecture.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var exeptionsDetails = GetExceptionsDetails(ex);
                var problemDetails = new ProblemDetails
                {
                    Status = exeptionsDetails.Status,
                    Type = exeptionsDetails.Type,
                    Title = exeptionsDetails.Title,
                    Detail = exeptionsDetails.Detail,

                };
                if(exeptionsDetails.Errors != null)
                {
                    problemDetails.Extensions["errors"] = exeptionsDetails.Errors;
                }
                context.Response.StatusCode = exeptionsDetails.Status;

                await context.Response.WriteAsJsonAsync(problemDetails);
            }

        }
        private static ExeptionDetails GetExceptionsDetails(Exception exception)
        {
            return exception switch
            {
                ValidationException validationException => new ExeptionDetails(
                    StatusCodes.Status400BadRequest,
                    "ValidationFailure",
                    "Validación de error",
                    "Se produjeron uno o más errores de validación",
                    validationException.Errors
                    ), 
                    _ => new ExeptionDetails(
                        StatusCodes.Status500InternalServerError,
                        "ServerError",
                        "Error interno del servidor",
                        "Ocurrio un error interno del servidor, por favor intente nuevamente mas tarde",
                        null
                        )
            };
        }
        internal record ExeptionDetails(
            int Status,
            string Type,
            string Title,
            string Detail,
            IEnumerable<object>? Errors
            );
    }
}
