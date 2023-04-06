using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Task.Rest.Api.Filters
{
    public class FailHandler : AuthorizationHandler<FailRequirement>
    {
        protected override System.Threading.Tasks.Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            FailRequirement requirement)
        {
            context.Fail(new AuthorizationFailureReason(this, "Woopsy"));
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
