using MpgsSharp.Models.Health;

namespace MpgsSharp.Services.Interfaces;

/// <summary>
///     Service for performing health checks and diagnostics on the MPGS gateway.
/// </summary>
public interface IHealthCheckService
{
    /// <summary>
    ///     Checks if the MPGS gateway is operational.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The health status of the gateway including version and operational status.</returns>
    Task<HealthCheckResponse> CheckHealthAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Checks if the MPGS gateway is operational and returns true/false.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the gateway is operational, false otherwise.</returns>
    Task<bool> IsHealthyAsync(CancellationToken cancellationToken = default);
}