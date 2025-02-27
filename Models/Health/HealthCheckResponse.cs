using System.Text.Json.Serialization;

namespace MpgsSharp.Models.Health;

/// <summary>
///     Response model for the MPGS gateway health/status check.
/// </summary>
public class HealthCheckResponse
{
    /// <summary>
    ///     The current version of the MPGS gateway.
    /// </summary>
    [JsonPropertyName("gatewayVersion")]
    public string? GatewayVersion { get; set; }

    /// <summary>
    ///     Indicates if the gateway is operating normally.
    /// </summary>
    public bool IsOperating => Status?.Equals("OPERATING", StringComparison.OrdinalIgnoreCase) == true;

    /// <summary>
    ///     The current operational status of the MPGS gateway.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}