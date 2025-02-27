using Microsoft.Extensions.Logging;
using MpgsSharp.Models.Health;
using MpgsSharp.Services.Interfaces;

namespace MpgsSharp.Services;

/// <summary>
///     Service implementation for performing health checks on the MPGS gateway.
/// </summary>
internal class HealthCheckService : IHealthCheckService
{
    private readonly ILogger<HealthCheckService> _logger;
    private readonly IMpgsClient _mpgsClient;

    /// <summary>
    ///     Initializes a new instance of the <see cref="HealthCheckService" /> class.
    /// </summary>
    public HealthCheckService(IMpgsClient mpgsClient, ILogger<HealthCheckService> logger)
    {
        _mpgsClient = mpgsClient;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<HealthCheckResponse> CheckHealthAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Checking MPGS gateway health");
        return await _mpgsClient.HealthCheckAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> IsHealthyAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _mpgsClient.HealthCheckAsync(cancellationToken);
            return result.IsOperating;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Health check failed due to exception");
            return false;
        }
    }
}