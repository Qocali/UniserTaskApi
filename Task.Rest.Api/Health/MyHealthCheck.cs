using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Task.Rest.Api.Controllers;

namespace Task.Rest.Api.Health
{
    public class MyHealthCheck : IHealthCheck
    {
        private readonly IServiceProvider _serviceProvider;

        public MyHealthCheck(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var controller = scope.ServiceProvider.GetService<TaskController>();
                var result = await controller.GetTask(1);

                if (result != null)
                {
                    return HealthCheckResult.Healthy();
                }
                else
                {
                    return HealthCheckResult.Unhealthy();
                }
            }
        }
    }
}
