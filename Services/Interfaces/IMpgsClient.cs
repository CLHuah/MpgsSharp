using MpgsSharp.Models.Health;
using MpgsSharp.Models.HostedCheckout;
using MpgsSharp.Models.Order;
using MpgsSharp.Models.Transaction;

namespace MpgsSharp.Services.Interfaces;

/// <summary>
///     Main interface for interacting with the MasterCard Payment Gateway Services.
/// </summary>
public interface IMpgsClient
{
    /// <summary>
    ///     Creates a hosted checkout session.
    /// </summary>
    /// <param name="request">The hosted checkout request details.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The hosted checkout response with session ID and redirect URL.</returns>
    Task<HostedCheckoutResponse> CreateHostedCheckoutSessionAsync(HostedCheckoutRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves order details by order ID.
    /// </summary>
    /// <param name="orderId">The ID of the order to retrieve.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The order details.</returns>
    Task<OrderDetailsResponse> GetOrderAsync(string orderId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves transaction details by transaction ID.
    /// </summary>
    /// <param name="orderId">The ID of the order associated with the transaction.</param>
    /// <param name="transactionId">The ID of the transaction to retrieve.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The transaction details.</returns>
    Task<TransactionDetailsResponse> GetTransactionAsync(string orderId, string transactionId,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Performs a health check to verify the MPGS gateway status.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The health check response with gateway status information.</returns>
    Task<HealthCheckResponse> HealthCheckAsync(CancellationToken cancellationToken = default);
}