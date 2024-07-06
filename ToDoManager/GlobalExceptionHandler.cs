using Domain;
using Domain.ErrorModel;
using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

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
                case AuthenticationUserException:
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    _logger.LogError(Messages.regError);
                    break;
                case NotFoundException:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
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
