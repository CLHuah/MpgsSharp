using MpgsSharp.Models.HostedCheckout;

namespace MpgsSharp.Services.Interfaces;

/// <summary>
///     Service for handling Hosted Checkout operations.
/// </summary>
public interface IHostedCheckoutService
{
    /// <summary>
    ///     Creates a hosted checkout session.
    /// </summary>
    /// <param name="request">The hosted checkout request details.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The hosted checkout response with session ID and redirect URL.</returns>
    Task<HostedCheckoutResponse> CreateSessionAsync(HostedCheckoutRequest request,
        CancellationToken cancellationToken = default);
}