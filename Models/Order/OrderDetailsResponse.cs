using System.Text.Json.Serialization;
using MpgsSharp.Models.Transaction;

namespace MpgsSharp.Models.Order;

/// <summary>
///     Response model containing order details.
/// </summary>
public class OrderDetailsResponse
{
    /// <summary>
    ///     The amount of the order.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    /// <summary>
    ///     Authentication information.
    /// </summary>
    [JsonPropertyName("authentication")]
    public AuthenticationInfo? Authentication { get; set; }

    /// <summary>
    ///     The authentication status.
    /// </summary>
    [JsonPropertyName("authenticationStatus")]
    public string? AuthenticationStatus { get; set; }

    /// <summary>
    ///     The authentication version used.
    /// </summary>
    [JsonPropertyName("authenticationVersion")]
    public string? AuthenticationVersion { get; set; }

    /// <summary>
    ///     Billing information.
    /// </summary>
    [JsonPropertyName("billing")]
    public BillingInfo? Billing { get; set; }

    /// <summary>
    ///     Chargeback information.
    /// </summary>
    [JsonPropertyName("chargeback")]
    public ChargebackInfo? Chargeback { get; set; }

    /// <summary>
    ///     The creation timestamp of the order.
    /// </summary>
    [JsonPropertyName("creationTime")]
    public string? CreationTime { get; set; }

    /// <summary>
    ///     The currency of the order in ISO 4217 format.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    ///     Customer information.
    /// </summary>
    [JsonPropertyName("customer")]
    public CustomerInfo? Customer { get; set; }

    /// <summary>
    ///     The order description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    ///     Device information.
    /// </summary>
    [JsonPropertyName("device")]
    public DeviceInfo? Device { get; set; }

    /// <summary>
    ///     The order identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    ///     The last update timestamp of the order.
    /// </summary>
    [JsonPropertyName("lastUpdatedTime")]
    public string? LastUpdatedTime { get; set; }

    /// <summary>
    ///     The merchant identifier.
    /// </summary>
    [JsonPropertyName("merchant")]
    public string? Merchant { get; set; }

    /// <summary>
    ///     The merchant amount.
    /// </summary>
    [JsonPropertyName("merchantAmount")]
    public decimal MerchantAmount { get; set; }

    /// <summary>
    ///     The merchant category code.
    /// </summary>
    [JsonPropertyName("merchantCategoryCode")]
    public string? MerchantCategoryCode { get; set; }

    /// <summary>
    ///     The merchant currency.
    /// </summary>
    [JsonPropertyName("merchantCurrency")]
    public string? MerchantCurrency { get; set; }

    /// <summary>
    ///     The notification URL.
    /// </summary>
    [JsonPropertyName("notificationUrl")]
    public string? NotificationUrl { get; set; }

    /// <summary>
    ///     The merchant-provided reference for the order.
    /// </summary>
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    /// <summary>
    ///     The result of the order processing.
    /// </summary>
    [JsonPropertyName("result")]
    public string? Result { get; set; }

    /// <summary>
    ///     Source of funds information.
    /// </summary>
    [JsonPropertyName("sourceOfFunds")]
    public SourceOfFundsInfo? SourceOfFunds { get; set; }

    /// <summary>
    ///     Statement descriptor information.
    /// </summary>
    [JsonPropertyName("statementDescriptor")]
    public StatementDescriptorInfo? StatementDescriptor { get; set; }

    /// <summary>
    ///     The status of the order.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    ///     The 3DS ACS ECI (Electronic Commerce Indicator).
    /// </summary>
    [JsonPropertyName("3dsAcsEci")]
    public string? ThreeDsAcsEci { get; set; }

    /// <summary>
    ///     Total authorized amount.
    /// </summary>
    [JsonPropertyName("totalAuthorizedAmount")]
    public decimal TotalAuthorizedAmount { get; set; }

    /// <summary>
    ///     Total captured amount.
    /// </summary>
    [JsonPropertyName("totalCapturedAmount")]
    public decimal TotalCapturedAmount { get; set; }

    /// <summary>
    ///     Total disbursed amount.
    /// </summary>
    [JsonPropertyName("totalDisbursedAmount")]
    public decimal TotalDisbursedAmount { get; set; }

    /// <summary>
    ///     Total refunded amount.
    /// </summary>
    [JsonPropertyName("totalRefundedAmount")]
    public decimal TotalRefundedAmount { get; set; }

    /// <summary>
    ///     The list of transactions associated with this order.
    /// </summary>
    [JsonPropertyName("transaction")]
    public List<TransactionDetailsResponse>? Transactions { get; set; }

    /// <summary>
    ///     Wallet information.
    /// </summary>
    [JsonPropertyName("wallet")]
    public WalletInfo? Wallet { get; set; }

    /// <summary>
    ///     The wallet provider.
    /// </summary>
    [JsonPropertyName("walletProvider")]
    public string? WalletProvider { get; set; }
}

/// <summary>
///     Authentication information.
/// </summary>
public class AuthenticationInfo
{
    /// <summary>
    ///     3DS information.
    /// </summary>
    [JsonPropertyName("3ds")]
    public ThreeDs? ThreeDs { get; set; }
}

/// <summary>
///     3DS information.
/// </summary>
public class ThreeDs
{
    /// <summary>
    ///     The ACS ECI (Electronic Commerce Indicator).
    /// </summary>
    [JsonPropertyName("acsEci")]
    public string? AcsEci { get; set; }

    /// <summary>
    ///     The authentication token.
    /// </summary>
    [JsonPropertyName("authenticationToken")]
    public string? AuthenticationToken { get; set; }

    /// <summary>
    ///     The transaction ID.
    /// </summary>
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }
}

/// <summary>
///     Billing information.
/// </summary>
public class BillingInfo
{
    /// <summary>
    ///     Address information.
    /// </summary>
    [JsonPropertyName("address")]
    public AddressInfo? Address { get; set; }
}

/// <summary>
///     Address information.
/// </summary>
public class AddressInfo
{
    /// <summary>
    ///     The country code.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }
}

/// <summary>
///     Chargeback information.
/// </summary>
public class ChargebackInfo
{
    /// <summary>
    ///     The chargeback amount.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    /// <summary>
    ///     The chargeback currency.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }
}

/// <summary>
///     Customer information.
/// </summary>
public class CustomerInfo
{
    /// <summary>
    ///     The customer email.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    ///     The customer first name.
    /// </summary>
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    /// <summary>
    ///     The customer last name.
    /// </summary>
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    /// <summary>
    ///     The customer mobile phone.
    /// </summary>
    [JsonPropertyName("mobilePhone")]
    public string? MobilePhone { get; set; }

    /// <summary>
    ///     The customer phone.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }
}

/// <summary>
///     Device information.
/// </summary>
public class DeviceInfo
{
    /// <summary>
    ///     The browser user agent.
    /// </summary>
    [JsonPropertyName("browser")]
    public string? Browser { get; set; }

    /// <summary>
    ///     The IP address.
    /// </summary>
    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }
}

/// <summary>
///     Source of funds information.
/// </summary>
public class SourceOfFundsInfo
{
    /// <summary>
    ///     Provided payment method information.
    /// </summary>
    [JsonPropertyName("provided")]
    public ProvidedPaymentInfo? Provided { get; set; }

    /// <summary>
    ///     The type of payment source.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

/// <summary>
///     Provided payment information.
/// </summary>
public class ProvidedPaymentInfo
{
    /// <summary>
    ///     Card details.
    /// </summary>
    [JsonPropertyName("card")]
    public FullCardDetails? Card { get; set; }
}

/// <summary>
///     Extended card details.
/// </summary>
public class FullCardDetails : CardDetails
{
    /// <summary>
    ///     The funding method of the card.
    /// </summary>
    [JsonPropertyName("fundingMethod")]
    public string? FundingMethod { get; set; }

    /// <summary>
    ///     Name on the card.
    /// </summary>
    [JsonPropertyName("nameOnCard")]
    public string? NameOnCard { get; set; }

    /// <summary>
    ///     The card scheme.
    /// </summary>
    [JsonPropertyName("scheme")]
    public string? Scheme { get; set; }

    /// <summary>
    ///     Stored on file status.
    /// </summary>
    [JsonPropertyName("storedOnFile")]
    public string? StoredOnFile { get; set; }
}

/// <summary>
///     Statement descriptor information.
/// </summary>
public class StatementDescriptorInfo
{
    /// <summary>
    ///     The name to appear on the statement.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

/// <summary>
///     Wallet information.
/// </summary>
public class WalletInfo
{
    /// <summary>
    ///     Secure Remote Commerce information.
    /// </summary>
    [JsonPropertyName("secureRemoteCommerce")]
    public SecureRemoteCommerceInfo? SecureRemoteCommerce { get; set; }
}

/// <summary>
///     Secure Remote Commerce information.
/// </summary>
public class SecureRemoteCommerceInfo
{
    /// <summary>
    ///     The SRC correlation ID.
    /// </summary>
    [JsonPropertyName("srcCorrelationId")]
    public string? SrcCorrelationId { get; set; }
}

/// <summary>
///     Summary of a transaction associated with an order.
/// </summary>
public class OrderTransactionSummary
{
    /// <summary>
    ///     The transaction identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    ///     The result of the transaction.
    /// </summary>
    [JsonPropertyName("result")]
    public string? Result { get; set; }

    /// <summary>
    ///     The timestamp when the transaction was processed.
    /// </summary>
    [JsonPropertyName("timeOfRecord")]
    public string? TimeOfRecord { get; set; }

    /// <summary>
    ///     The type of transaction.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}