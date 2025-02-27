using System.Text.Json.Serialization;

namespace MpgsSharp.Models.HostedCheckout;

/// <summary>
///     Request model for creating a hosted checkout session.
/// </summary>
public class HostedCheckoutRequest
{
    /// <summary>
    ///     Gets or sets the API operation. Fixed value "INITIATE_CHECKOUT" for hosted checkout.
    /// </summary>
    [JsonPropertyName("apiOperation")]
    public string ApiOperation { get; set; } = "INITIATE_CHECKOUT";

    /// <summary>
    ///     Customer information for the checkout.
    /// </summary>
    [JsonPropertyName("customer")]
    public CustomerRequest? Customer { get; set; }

    /// <summary>
    ///     The interaction details that control the hosted session behavior.
    /// </summary>
    [JsonPropertyName("interaction")]
    public InteractionRequest? Interaction { get; set; }

    /// <summary>
    ///     The order details.
    /// </summary>
    [JsonPropertyName("order")]
    public OrderRequest? Order { get; set; }
}

/// <summary>
///     Customer information for hosted checkout.
/// </summary>
public class CustomerRequest
{
    /// <summary>
    ///     The customer's email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }
}

/// <summary>
///     Order information for hosted checkout.
/// </summary>
public class OrderRequest
{
    /// <summary>
    ///     The amount to be authorized.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    /// <summary>
    ///     The currency code in ISO 4217 format.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    ///     Description of the order.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    ///     A unique identifier for the order. Must be between 1 and 40 characters.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    ///     URL to which payment notifications will be sent. Must be a valid HTTPS URL.
    /// </summary>
    /// <remarks>
    ///     This is used for server-to-server notifications about the order status.
    /// </remarks>
    [JsonPropertyName("notificationUrl")]
    public string? NotificationUrl { get; set; }

    /// <summary>
    ///     Information that appears on the payer's statement.
    /// </summary>
    [JsonPropertyName("statementDescriptor")]
    public StatementDescriptorRequest? StatementDescriptor { get; set; }
}

/// <summary>
///     Statement descriptor information for the payment.
/// </summary>
public class StatementDescriptorRequest
{
    /// <summary>
    ///     Descriptor that appears on the payer's statement. Maximum length is 100 characters.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

/// <summary>
///     Interaction configuration for hosted checkout.
/// </summary>
public class InteractionRequest
{
    /// <summary>
    ///     The URL to which the payer's browser is redirected if they cancel the payment.
    /// </summary>
    [JsonPropertyName("cancelUrl")]
    public string? CancelUrl { get; set; }

    /// <summary>
    ///     The merchant name that appears in the payment page.
    /// </summary>
    [JsonPropertyName("merchant")]
    public MerchantInteractionRequest? Merchant { get; set; }

    /// <summary>
    ///     The type of operation to perform.
    /// </summary>
    /// <remarks>
    ///     Valid values:
    ///     - AUTHORIZE: Creates an Authorization transaction for the payment.
    ///     - NONE: Collects and stores payment details without performing any operation.
    ///     - PURCHASE: Creates a Purchase transaction for the payment.
    ///     - VERIFY: Verifies the payer's account using the acquirer's verification method.
    /// </remarks>
    [JsonPropertyName("operation")]
    public string? Operation { get; set; } = HostedCheckoutConstants.OperationType.Purchase;

    /// <summary>
    ///     The URL to which the payer is redirected after completing the payment attempt.
    /// </summary>
    [JsonPropertyName("returnUrl")]
    public string? ReturnUrl { get; set; }
}

/// <summary>
///     Merchant display information for the checkout page.
/// </summary>
public class MerchantInteractionRequest
{
    /// <summary>
    ///     The name to display for the merchant.
    /// </summary>
    [JsonPropertyName("name")]
    public string? DisplayName { get; set; }

    /// <summary>
    ///     The URL to the merchant's logo image. Must be an absolute HTTPS URL.
    /// </summary>
    /// <remarks>
    ///     Must be an absolute URI conforming to RFC 2396 and must use HTTPS protocol.
    /// </remarks>
    [JsonPropertyName("logo")]
    public string? Logo { get; set; }

    /// <summary>
    ///     The URL to the merchant's website. Must be an absolute HTTPS URL.
    /// </summary>
    /// <remarks>
    ///     Must be an absolute URI conforming to RFC 2396 and must use HTTPS protocol.
    /// </remarks>
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}