using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tavisca.Platform.Common.Configurations;

namespace capi_accesskey.Middlewares
{
    public class HealthCheckMiddleware : IHealthCheck
    {
        private readonly IConfigurationProvider _configurationProvider;
        public HealthCheckMiddleware(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            var status = new HealthCheckResult();
            try
            {
                var value = await _configurationProvider.HealthCheckAsync();
                if (value == ConfigurationProviderConnectionStatus.Connected)
                {
                    status = new HealthCheckResult(HealthStatus.Healthy, "ConsulStatus : Success ", null, null);
                }
                else
                {
                    status = new HealthCheckResult(HealthStatus.Unhealthy, "ConsulStatus : Failed | Message : Could not connect to consul", null, null);
                }
            }
            catch (Exception ex)
            {
                status = new HealthCheckResult(HealthStatus.Degraded, $"ConsulStatus : Failed | Message : {ex.Message}", ex, null);
            }

            return status;
        }
    }
}
