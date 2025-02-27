using System.Text.Json.Serialization;

namespace MpgsSharp.Models.HostedCheckout;

/// <summary>
///     Response model from creating a hosted checkout session.
/// </summary>
public class HostedCheckoutResponse
{
    /// <summary>
    ///     The checkout mode used for the session.
    /// </summary>
    [JsonPropertyName("checkoutMode")]
    public string? CheckoutMode { get; set; }

    /// <summary>
    ///     The merchant information.
    /// </summary>
    [JsonPropertyName("merchant")]
    public string? Merchant { get; set; }

    /// <summary>
    ///     The result of the checkout operation.
    /// </summary>
    [JsonPropertyName("result")]
    public string? Result { get; set; }

    /// <summary>
    ///     Session information.
    /// </summary>
    [JsonPropertyName("session")]
    public SessionResponse? Session { get; set; }

    /// <summary>
    ///     An indicator that can be used to check if the operation was successful.
    /// </summary>
    [JsonPropertyName("successIndicator")]
    public string? SuccessIndicator { get; set; }
}

/// <summary>
///     Session information within the hosted checkout response.
/// </summary>
public class SessionResponse
{
    /// <summary>
    ///     The unique identifier for the session.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    ///     The update status of the session.
    /// </summary>
    [JsonPropertyName("updateStatus")]
    public string? UpdateStatus { get; set; }

    /// <summary>
    ///     The version of the session.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }
}