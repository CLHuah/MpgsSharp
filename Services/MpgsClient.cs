using Microsoft.Extensions.Logging;
using MpgsSharp.Configuration;
using MpgsSharp.Models.Health;
using MpgsSharp.Models.HostedCheckout;
using MpgsSharp.Models.Order;
using MpgsSharp.Models.Transaction;
using MpgsSharp.Services.Interfaces;

namespace MpgsSharp.Services;

/// <summary>
///     Main implementation for interacting with the MasterCard Payment Gateway Services.
/// </summary>
internal class MpgsClient : IMpgsClient
{
    private readonly IMpgsHttpClient _httpClient;
    private readonly ILogger<MpgsClient> _logger;
    private readonly MpgsOptions _options;

    /// <summary>
    ///     Initializes a new instance of the <see cref="MpgsClient" /> class.
    /// </summary>
    /// <param name="httpClient">HTTP client for MPGS API communication</param>
    /// <param name="options">Configuration options for the MPGS gateway</param>
    /// <param name="logger">Logger instance</param>
    public MpgsClient(IMpgsHttpClient httpClient, ILogger<MpgsClient> logger, MpgsOptions options)
    {
        _httpClient = httpClient;
        _logger = logger;
        _options = options;
    }

    /// <inheritdoc />
    public async Task<HostedCheckoutResponse> CreateHostedCheckoutSessionAsync(HostedCheckoutRequest request,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Creating hosted checkout session");

        // Build endpoint with merchant ID and API version from options
        var endpoint = BuildEndpoint("session");

        return await _httpClient.PostAsync<HostedCheckoutRequest, HostedCheckoutResponse>(endpoint, request,
            cancellationToken);
    }

    /// <inheritdoc />
    public async Task<OrderDetailsResponse> GetOrderAsync(string orderId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Getting order details for order {OrderId}", orderId);

        // Build endpoint with order ID
        var endpoint = BuildEndpoint($"order/{orderId}");

        return await _httpClient.GetAsync<OrderDetailsResponse>(endpoint, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TransactionDetailsResponse> GetTransactionAsync(string orderId, string transactionId,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Getting transaction details for order {OrderId}, transaction {TransactionId}", orderId,
            transactionId);

        // Build endpoint with order and transaction ID
        var endpoint = BuildEndpoint($"order/{orderId}/transaction/{transactionId}");

        return await _httpClient.GetAsync<TransactionDetailsResponse>(endpoint, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<HealthCheckResponse> HealthCheckAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Performing MPGS gateway health check");

        // Build information endpoint
        var endpoint = $"/api/rest/version/{_options.ApiVersion}/information";

        return await _httpClient.GetAsync<HealthCheckResponse>(endpoint, cancellationToken);
    }

    /// <summary>
    ///     Helper method to build API endpoints with consistent structure
    /// </summary>
    /// <param name="resource">The resource path to append to the base endpoint</param>
    /// <returns>The complete API endpoint</returns>
    private string BuildEndpoint(string resource)
    {
        return $"/api/rest/version/{_options.ApiVersion}/merchant/{_options.MerchantId}/{resource}";
    }
}