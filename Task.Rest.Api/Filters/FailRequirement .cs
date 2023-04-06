using Microsoft.AspNetCore.Authorization;

namespace Task.Rest.Api.Filters
{
    public class FailRequirement : IAuthorizationRequirement
    {
        // add extra metadata if needed
        // like flags, business info, etc.
    }
}
