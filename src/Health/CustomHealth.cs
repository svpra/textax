using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace Tectex.Health;

public class CustomHealth : IHealthCheck
{

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = new CancellationToken())
    {

        return Task.FromResult(HealthCheckResult.Healthy("Моя проверка работает"));

        // return Task.FromResult(HealthCheckResult.Unhealthy("Моя проверка не работает"));
    }
