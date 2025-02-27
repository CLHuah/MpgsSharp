using Microsoft.Extensions.Logging;
using MpgsSharp.Exceptions;
using MpgsSharp.Models.HostedCheckout;
using MpgsSharp.Services.Interfaces;
using MpgsSharp.Utilities;

namespace MpgsSharp.Services;

/// <summary>
///     Service implementation for handling Hosted Checkout operations.
/// </summary>
internal class HostedCheckoutService : IHostedCheckoutService
{
    private static readonly HashSet<string> ValidOperations = new(StringComparer.OrdinalIgnoreCase)
    {
        HostedCheckoutConstants.OperationType.Authorize,
        HostedCheckoutConstants.OperationType.None,
        HostedCheckoutConstants.OperationType.Purchase,
        HostedCheckoutConstants.OperationType.Verify
    };

    private readonly ILogger<HostedCheckoutService> _logger;
    private readonly IMpgsClient _mpgsClient;

    /// <summary>
    ///     Initializes a new instance of the <see cref="HostedCheckoutService" /> class.
    /// </summary>
    public HostedCheckoutService(ILogger<HostedCheckoutService> logger, IMpgsClient mpgsClient)
    {
        _logger = logger;
        _mpgsClient = mpgsClient;
    }

    /// <inheritdoc />
    public async Task<HostedCheckoutResponse> CreateSessionAsync(HostedCheckoutRequest request,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Creating hosted checkout session");

        // Validate request
        if (request.Order == null)
        {
            _logger.LogWarning("Validation failed: Order details are missing");
            throw new ArgumentException("Order details are required for hosted checkout", nameof(request));
        }

        // Validate Amount 
        if (request.Order.Amount <= 0)
        {
            _logger.LogWarning("Validation failed: Invalid amount {Amount}", request.Order.Amount);
            throw new ArgumentException("Order amount must be greater than zero", nameof(request));
        }

        if (string.IsNullOrEmpty(request.Order.Currency))
        {
            _logger.LogWarning("Validation failed: Currency is missing");
            throw new ArgumentException("Order currency is required", nameof(request));
        }

        // Validate Order Id
        if (string.IsNullOrEmpty(request.Order.Id))
        {
            _logger.LogWarning("Validation failed: Order ID is missing");
            throw new ArgumentException("Order ID is required", nameof(request));
        }

        if (request.Order.Id.Length > 40)
        {
            _logger.LogWarning("Validation failed: Order ID too long ({Length} chars)", request.Order.Id.Length);
            throw new ArgumentException("Order ID cannot be longer than 40 characters", nameof(request));
        }

        // Validate NotificationUrl if provided
        if (!string.IsNullOrEmpty(request.Order.NotificationUrl) &&
            !UrlValidator.IsValidHttpsUrl(request.Order.NotificationUrl))
        {
            _logger.LogWarning("Validation failed: Invalid notification URL {Url}", request.Order.NotificationUrl);
            throw new ArgumentException("Notification URL must be a valid HTTPS URL", nameof(request));
        }

        // Validate StatementDescriptor if provided
        if (request.Order.StatementDescriptor != null &&
            !string.IsNullOrEmpty(request.Order.StatementDescriptor.Name) &&
            request.Order.StatementDescriptor.Name.Length > 100)
        {
            _logger.LogWarning("Validation failed: Statement descriptor name too long ({Length} chars)",
                request.Order.StatementDescriptor.Name.Length);
            throw new ArgumentException("Statement descriptor name cannot be longer than 100 characters",
                nameof(request));
        }

        // Validate URLs if provided
        if (request.Interaction != null)
        {
            // Validate ReturnUrl if provided
            if (!string.IsNullOrEmpty(request.Interaction.ReturnUrl) &&
                !UrlValidator.IsValidHttpsUrl(request.Interaction.ReturnUrl))
            {
                _logger.LogWarning("Validation failed: Invalid return URL {Url}", request.Interaction.ReturnUrl);
                throw new ArgumentException("Return URL must be a valid HTTPS URL", nameof(request));
            }

            // Validate CancelUrl if provided
            if (!string.IsNullOrEmpty(request.Interaction.CancelUrl) &&
                !UrlValidator.IsValidHttpsUrl(request.Interaction.CancelUrl))
            {
                _logger.LogWarning("Validation failed: Invalid cancel URL {Url}", request.Interaction.CancelUrl);
                throw new ArgumentException("Cancel URL must be a valid HTTPS URL", nameof(request));
            }

            // Validate operation if provided
            if (!string.IsNullOrEmpty(request.Interaction.Operation) &&
                !ValidOperations.Contains(request.Interaction.Operation))
            {
                _logger.LogWarning("Validation failed: Invalid operation value {Operation}",
                    request.Interaction.Operation);
                throw new ArgumentException(
                    $"Invalid operation value. Valid values are: {HostedCheckoutConstants.OperationType.Authorize}, " +
                    $"{HostedCheckoutConstants.OperationType.None}, {HostedCheckoutConstants.OperationType.Purchase}, " +
                    $"{HostedCheckoutConstants.OperationType.Verify}", nameof(request));
            }

            // Validate merchant URLs if provided
            if (request.Interaction.Merchant != null)
            {
                if (!string.IsNullOrEmpty(request.Interaction.Merchant.Logo) &&
                    !UrlValidator.IsValidHttpsUrl(request.Interaction.Merchant.Logo))
                {
                    _logger.LogWarning("Validation failed: Invalid logo URL {Url}", request.Interaction.Merchant.Logo);
                    throw new ArgumentException("Merchant logo must be a valid HTTPS URL", nameof(request));
                }

                if (!string.IsNullOrEmpty(request.Interaction.Merchant.Url) &&
                    !UrlValidator.IsValidHttpsUrl(request.Interaction.Merchant.Url))
                {
                    _logger.LogWarning("Validation failed: Invalid merchant URL {Url}",
                        request.Interaction.Merchant.Url);
                    throw new ArgumentException("Merchant URL must be a valid HTTPS URL", nameof(request));
                }
            }
        }

        // Ensure apiOperation is set correctly for hosted checkout
        if (request.ApiOperation != "INITIATE_CHECKOUT")
        {
            _logger.LogDebug("Setting apiOperation to INITIATE_CHECKOUT (was: {OriginalValue})", request.ApiOperation);
            request.ApiOperation = "INITIATE_CHECKOUT";
        }

        _logger.LogDebug("Validation successful, creating hosted checkout with order ID {OrderId}", request.Order.Id);

        try
        {
            var response = await _mpgsClient.CreateHostedCheckoutSessionAsync(request, cancellationToken);
            _logger.LogInformation("Successfully created hosted checkout session with ID {SessionId}",
                response.Session?.Id);
            return response;
        }
        catch (MpgsApiException ex)
        {
            _logger.LogError(ex, "MPGS API error when creating checkout session: {ErrorDetails}",
                ex.ErrorResponse?.Error?.Explanation ?? "Unknown error");

            // Re-throw or handle specific error cases
            if (ex.ErrorResponse?.Error?.Field != null)
            {
                _logger.LogWarning("Field validation error: {Field} - {Explanation}", ex.ErrorResponse.Error.Field,
                    ex.ErrorResponse.Error.Explanation);

                throw new ArgumentException(
                    $"Invalid field: {ex.ErrorResponse.Error.Field}. {ex.ErrorResponse.Error.Explanation}",
                    ex.ErrorResponse.Error.Field, ex);
            }

            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error creating hosted checkout session");
            throw;
        }
    }
}