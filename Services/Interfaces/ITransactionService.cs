using MpgsSharp.Models.Order;
using MpgsSharp.Models.Transaction;

namespace MpgsSharp.Services.Interfaces;

/// <summary>
///     Service for handling Transaction and Order operations.
/// </summary>
public interface ITransactionService
{
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
}