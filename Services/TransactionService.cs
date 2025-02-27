using Microsoft.Extensions.Logging;
using MpgsSharp.Models.Order;
using MpgsSharp.Models.Transaction;
using MpgsSharp.Services.Interfaces;

namespace MpgsSharp.Services;

/// <summary>
///     Service implementation for handling Transaction and Order operations.
/// </summary>
internal class TransactionService : ITransactionService
{
    private readonly ILogger<TransactionService> _logger;
    private readonly IMpgsClient _mpgsClient;

    /// <summary>
    ///     Initializes a new instance of the <see cref="TransactionService" /> class.
    /// </summary>
    public TransactionService(IMpgsClient mpgsClient, ILogger<TransactionService> logger)
    {
        _mpgsClient = mpgsClient;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<OrderDetailsResponse> GetOrderAsync(string orderId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(orderId))
        {
            _logger.LogWarning("Order ID cannot be empty");
            throw new ArgumentException("Order ID cannot be empty", nameof(orderId));
        }

        _logger.LogInformation("Getting order details for order {OrderId}", orderId);
        return await _mpgsClient.GetOrderAsync(orderId, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TransactionDetailsResponse> GetTransactionAsync(string orderId, string transactionId,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(orderId))
        {
            _logger.LogWarning("Order ID cannot be empty");
            throw new ArgumentException("Order ID cannot be empty", nameof(orderId));
        }

        if (string.IsNullOrEmpty(transactionId))
        {
            _logger.LogWarning("Transaction ID cannot be empty");
            throw new ArgumentException("Transaction ID cannot be empty", nameof(transactionId));
        }

        _logger.LogInformation("Getting transaction details for order {OrderId}, transaction {TransactionId}", orderId,
            transactionId);

        return await _mpgsClient.GetTransactionAsync(orderId, transactionId, cancellationToken);
    }
}