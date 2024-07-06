using Domain;
using Domain.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Security.Authentication;

namespace ToDoManager;

public class GlobalExceptionHandler : IExceptionHandler
{  
    private readonly ILogger<GlobalExceptionHandler> _logger;
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) => _logger = logger;
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = "application/json";

        var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature is not null)
        {
            switch (contextFeature.Error)
            {
                case AuthenticationException:
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    _logger.LogError(Messages.regError);
                    break;

            }

            await httpContext.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = contextFeature.Error.Message,
            }.ToString());
        }

        return true;
    }
}
