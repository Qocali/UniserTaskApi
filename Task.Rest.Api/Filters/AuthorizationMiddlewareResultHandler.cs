using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization;

namespace Task.Rest.Api.Filters
{
    public class AuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {
        private readonly ILogger<AuthorizationMiddlewareResultHandler> _logger;
        private readonly Microsoft.AspNetCore.Authorization.Policy.AuthorizationMiddlewareResultHandler _defaultHandler = new();

        public AuthorizationMiddlewareResultHandler(ILogger<AuthorizationMiddlewareResultHandler> logger)
        {
            _logger = logger;
        }

        public async System.Threading.Tasks.Task HandleAsync(
            RequestDelegate next,
            HttpContext context,
            AuthorizationPolicy policy,
            PolicyAuthorizationResult authorizeResult)
        {
            var authorizationFailureReason = authorizeResult.AuthorizationFailure?.FailureReasons.FirstOrDefault();
            var message = authorizationFailureReason?.Message;
            _logger.LogInformation("Authorization Result says {Message}",
                message
            );

            if (authorizationFailureReason?.Handler is FailHandler)
            {
                var html = $"<html><h1>{message}</h1></html>";
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await Results.Content(html, "text/html").ExecuteAsync(context);
            }
            else
            {
                // Fall back to the default implementation.
                await _defaultHandler.HandleAsync(next, context, policy, authorizeResult);
            }
        }
    }
}
