using System.Text.Json.Serialization;
using MpgsSharp.Models.Order;

namespace MpgsSharp.Models.Transaction;

/// <summary>
///     Response model containing transaction details.
/// </summary>
public class TransactionDetailsResponse
{
    /// <summary>
    ///     Authentication response data.
    /// </summary>
    [JsonPropertyName("authentication")]
    public DetailedAuthenticationResponse? Authentication { get; set; }

    /// <summary>
    ///     Authorization response information.
    /// </summary>
    [JsonPropertyName("authorizationResponse")]
    public AuthorizationResponse? AuthorizationResponse { get; set; }

    /// <summary>
    ///     Billing information.
    /// </summary>
    [JsonPropertyName("billing")]
    public BillingInfo? Billing { get; set; }

    /// <summary>
    ///     Customer information.
    /// </summary>
    [JsonPropertyName("customer")]
    public CustomerInfo? Customer { get; set; }

    /// <summary>
    ///     Device information.
    /// </summary>
    [JsonPropertyName("device")]
    public DeviceInfo? Device { get; set; }

    /// <summary>
    ///     Gateway entry point.
    /// </summary>
    [JsonPropertyName("gatewayEntryPoint")]
    public string? GatewayEntryPoint { get; set; }

    /// <summary>
    ///     The transaction identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    ///     The merchant identifier.
    /// </summary>
    [JsonPropertyName("merchant")]
    public string? Merchant { get; set; }

    /// <summary>
    ///     The order associated with this transaction.
    /// </summary>
    [JsonPropertyName("order")]
    public OrderInfo? Order { get; set; }

    /// <summary>
    ///     Gateway response data.
    /// </summary>
    [JsonPropertyName("response")]
    public DetailedResponseInfo? Response { get; set; }

    /// <summary>
    ///     The result of the transaction.
    /// </summary>
    [JsonPropertyName("result")]
    public string? Result { get; set; }

    /// <summary>
    ///     Source of funds information.
    /// </summary>
    [JsonPropertyName("sourceOfFunds")]
    public SourceOfFundsInfo? SourceOfFunds { get; set; }

    /// <summary>
    ///     The time of last update.
    /// </summary>
    [JsonPropertyName("timeOfLastUpdate")]
    public string? TimeOfLastUpdate { get; set; }

    /// <summary>
    ///     The time the transaction was processed.
    /// </summary>
    [JsonPropertyName("timeOfRecord")]
    public string? TimeOfRecord { get; set; }

    /// <summary>
    ///     Detailed transaction information.
    /// </summary>
    [JsonPropertyName("transaction")]
    public DetailedTransaction? Transaction { get; set; }

    /// <summary>
    ///     Version information.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }
}

/// <summary>
///     Detailed authentication response.
/// </summary>
public class DetailedAuthenticationResponse : AuthenticationResponse
{
    /// <summary>
    ///     Accept versions.
    /// </summary>
    [JsonPropertyName("acceptVersions")]
    public string? AcceptVersions { get; set; }

    /// <summary>
    ///     The authentication amount.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    /// <summary>
    ///     The authentication channel.
    /// </summary>
    [JsonPropertyName("channel")]
    public string? Channel { get; set; }

    /// <summary>
    ///     The authentication method.
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    /// <summary>
    ///     Payer interaction requirement.
    /// </summary>
    [JsonPropertyName("payerInteraction")]
    public string? PayerInteraction { get; set; }

    /// <summary>
    ///     Authentication purpose.
    /// </summary>
    [JsonPropertyName("purpose")]
    public string? Purpose { get; set; }

    /// <summary>
    ///     Redirect information.
    /// </summary>
    [JsonPropertyName("redirect")]
    public RedirectInfo? Redirect { get; set; }

    /// <summary>
    ///     3DS information.
    /// </summary>
    [JsonPropertyName("3ds")]
    public ThreeDs? ThreeDs { get; set; }

    /// <summary>
    ///     3DS2 information.
    /// </summary>
    [JsonPropertyName("3ds2")]
    public ThreeDs2Info? ThreeDs2 { get; set; }

    /// <summary>
    ///     Authentication time.
    /// </summary>
    [JsonPropertyName("time")]
    public string? Time { get; set; }

    /// <summary>
    ///     Transaction ID.
    /// </summary>
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    /// <summary>
    ///     Authentication version.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }
}

/// <summary>
///     3DS2 information.
/// </summary>
public class ThreeDs2Info
{
    /// <summary>
    ///     ACS Reference.
    /// </summary>
    [JsonPropertyName("acsReference")]
    public string? AcsReference { get; set; }

    /// <summary>
    ///     ACS Transaction ID.
    /// </summary>
    [JsonPropertyName("acsTransactionId")]
    public string? AcsTransactionId { get; set; }

    /// <summary>
    ///     Authentication scheme.
    /// </summary>
    [JsonPropertyName("authenticationScheme")]
    public string? AuthenticationScheme { get; set; }

    /// <summary>
    ///     Directory Server ID.
    /// </summary>
    [JsonPropertyName("directoryServerId")]
    public string? DirectoryServerId { get; set; }

    /// <summary>
    ///     DS Reference.
    /// </summary>
    [JsonPropertyName("dsReference")]
    public string? DsReference { get; set; }

    /// <summary>
    ///     DS Transaction ID.
    /// </summary>
    [JsonPropertyName("dsTransactionId")]
    public string? DsTransactionId { get; set; }

    /// <summary>
    ///     Method supported status.
    /// </summary>
    [JsonPropertyName("methodSupported")]
    public string? MethodSupported { get; set; }

    /// <summary>
    ///     Protocol version.
    /// </summary>
    [JsonPropertyName("protocolVersion")]
    public string? ProtocolVersion { get; set; }

    /// <summary>
    ///     Requestor ID.
    /// </summary>
    [JsonPropertyName("requestorId")]
    public string? RequestorId { get; set; }

    /// <summary>
    ///     Requestor name.
    /// </summary>
    [JsonPropertyName("requestorName")]
    public string? RequestorName { get; set; }

    /// <summary>
    ///     3DS Server Transaction ID.
    /// </summary>
    [JsonPropertyName("3dsServerTransactionId")]
    public string? ThreeDsServerTransactionId { get; set; }

    /// <summary>
    ///     Transaction status.
    /// </summary>
    [JsonPropertyName("transactionStatus")]
    public string? TransactionStatus { get; set; }
}

/// <summary>
///     Redirect information.
/// </summary>
public class RedirectInfo
{
    /// <summary>
    ///     Domain name for redirection.
    /// </summary>
    [JsonPropertyName("domainName")]
    public string? DomainName { get; set; }
}

/// <summary>
///     Authorization response.
/// </summary>
public class AuthorizationResponse
{
    /// <summary>
    ///     Card level indicator.
    /// </summary>
    [JsonPropertyName("cardLevelIndicator")]
    public string? CardLevelIndicator { get; set; }

    /// <summary>
    ///     Commercial card information.
    /// </summary>
    [JsonPropertyName("commercialCard")]
    public string? CommercialCard { get; set; }

    /// <summary>
    ///     Commercial card indicator.
    /// </summary>
    [JsonPropertyName("commercialCardIndicator")]
    public string? CommercialCardIndicator { get; set; }

    /// <summary>
    ///     Response date.
    /// </summary>
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    /// <summary>
    ///     POS data.
    /// </summary>
    [JsonPropertyName("posData")]
    public string? PosData { get; set; }

    /// <summary>
    ///     POS entry mode.
    /// </summary>
    [JsonPropertyName("posEntryMode")]
    public string? PosEntryMode { get; set; }

    /// <summary>
    ///     Processing code.
    /// </summary>
    [JsonPropertyName("processingCode")]
    public string? ProcessingCode { get; set; }

    /// <summary>
    ///     Response code.
    /// </summary>
    [JsonPropertyName("responseCode")]
    public string? ResponseCode { get; set; }

    /// <summary>
    ///     Return ACI.
    /// </summary>
    [JsonPropertyName("returnAci")]
    public string? ReturnAci { get; set; }

    /// <summary>
    ///     Source reason code.
    /// </summary>
    [JsonPropertyName("sourceReasonCode")]
    public string? SourceReasonCode { get; set; }

    /// <summary>
    ///     STAN (System Trace Audit Number).
    /// </summary>
    [JsonPropertyName("stan")]
    public string? Stan { get; set; }

    /// <summary>
    ///     Response time.
    /// </summary>
    [JsonPropertyName("time")]
    public string? Time { get; set; }

    /// <summary>
    ///     Transaction identifier.
    /// </summary>
    [JsonPropertyName("transactionIdentifier")]
    public string? TransactionIdentifier { get; set; }

    /// <summary>
    ///     Validation code.
    /// </summary>
    [JsonPropertyName("validationCode")]
    public string? ValidationCode { get; set; }

    /// <summary>
    ///     VPAS response.
    /// </summary>
    [JsonPropertyName("vpasResponse")]
    public string? VpasResponse { get; set; }
}

/// <summary>
///     Order information in a transaction.
/// </summary>
public class OrderInfo
{
    /// <summary>
    ///     The order amount.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    /// <summary>
    ///     The authentication status.
    /// </summary>
    [JsonPropertyName("authenticationStatus")]
    public string? AuthenticationStatus { get; set; }

    /// <summary>
    ///     Chargeback information.
    /// </summary>
    [JsonPropertyName("chargeback")]
    public ChargebackInfo? Chargeback { get; set; }

    /// <summary>
    ///     The creation timestamp.
    /// </summary>
    [JsonPropertyName("creationTime")]
    public string? CreationTime { get; set; }

    /// <summary>
    ///     The currency code.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    ///     The order description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    ///     The order identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    ///     The last update timestamp.
    /// </summary>
    [JsonPropertyName("lastUpdatedTime")]
    public string? LastUpdatedTime { get; set; }

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
///     Detailed response information.
/// </summary>
public class DetailedResponseInfo : TransactionResponseDetails
{
    /// <summary>
    ///     The acquirer code.
    /// </summary>
    [JsonPropertyName("acquirerCode")]
    public string? AcquirerCode { get; set; }

    /// <summary>
    ///     The acquirer message.
    /// </summary>
    [JsonPropertyName("acquirerMessage")]
    public string? AcquirerMessage { get; set; }

    /// <summary>
    ///     Gateway recommendation.
    /// </summary>
    [JsonPropertyName("gatewayRecommendation")]
    public string? GatewayRecommendation { get; set; }
}

/// <summary>
///     Detailed transaction information.
/// </summary>
public class DetailedTransaction
{
    /// <summary>
    ///     Acquirer information.
    /// </summary>
    [JsonPropertyName("acquirer")]
    public AcquirerInfo? Acquirer { get; set; }

    /// <summary>
    ///     Transaction amount.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    /// <summary>
    ///     Authentication status.
    /// </summary>
    [JsonPropertyName("authenticationStatus")]
    public string? AuthenticationStatus { get; set; }

    /// <summary>
    ///     Authorization code.
    /// </summary>
    [JsonPropertyName("authorizationCode")]
    public string? AuthorizationCode { get; set; }

    /// <summary>
    ///     Transaction currency.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    ///     Transaction ID.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    ///     Receipt information.
    /// </summary>
    [JsonPropertyName("receipt")]
    public string? Receipt { get; set; }

    /// <summary>
    ///     Transaction source.
    /// </summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }

    /// <summary>
    ///     Transaction status.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    ///     Transaction type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

/// <summary>
///     Acquirer information.
/// </summary>
public class AcquirerInfo
{
    /// <summary>
    ///     Acquirer code.
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    ///     Acquirer message.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

/// <summary>
///     Chargeback information.
/// </summary>
public class ChargebackInfo
{
    /// <summary>
    ///     Chargeback amount.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    /// <summary>
    ///     Chargeback currency.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    ///     Chargeback reason.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    ///     Chargeback status.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}

/// <summary>
///     Statement descriptor information.
/// </summary>
public class StatementDescriptorInfo
{
    /// <summary>
    ///     Statement descriptor city.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    ///     Statement descriptor name.
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
    ///     Wallet token.
    /// </summary>
    [JsonPropertyName("token")]
    public string? Token { get; set; }

    /// <summary>
    ///     Wallet type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

/// <summary>
///     Source of funds information.
/// </summary>
public class SourceOfFundsInfo
{
    /// <summary>
    ///     Provided card information (masked for security).
    /// </summary>
    [JsonPropertyName("card")]
    public CardDetails? Card { get; set; }

    /// <summary>
    ///     The source of the transaction (e.g., INTERNET, MOTO).
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

/// <summary>
///     Card details from a transaction.
/// </summary>
public class CardDetails
{
    /// <summary>
    ///     The card brand.
    /// </summary>
    [JsonPropertyName("brand")]
    public string? Brand { get; set; }

    /// <summary>
    ///     The expiry month.
    /// </summary>
    [JsonPropertyName("expiry")]
    public CardExpiry? Expiry { get; set; }

    /// <summary>
    ///     The masked card number with only the last 4 digits visible.
    /// </summary>
    [JsonPropertyName("number")]
    public string? Number { get; set; }
}

/// <summary>
///     Card expiry information.
/// </summary>
public class CardExpiry
{
    /// <summary>
    ///     The expiry month.
    /// </summary>
    [JsonPropertyName("month")]
    public string? Month { get; set; }

    /// <summary>
    ///     The expiry year.
    /// </summary>
    [JsonPropertyName("year")]
    public string? Year { get; set; }
}

/// <summary>
///     Order reference information.
/// </summary>
public class OrderReference
{
    /// <summary>
    ///     The order identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    ///     The merchant-provided reference for the order.
    /// </summary>
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }
}

/// <summary>
///     Authentication response details.
/// </summary>
public class AuthenticationResponse
{
    /// <summary>
    ///     The 3DS authentication status.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}

/// <summary>
///     Transaction response details from the gateway.
/// </summary>
public class TransactionResponseDetails
{
    /// <summary>
    ///     Additional information about the response.
    /// </summary>
    [JsonPropertyName("additionalInfo")]
    public string? AdditionalInfo { get; set; }

    /// <summary>
    ///     The gateway response code.
    /// </summary>
    [JsonPropertyName("gatewayCode")]
    public string? GatewayCode { get; set; }
}