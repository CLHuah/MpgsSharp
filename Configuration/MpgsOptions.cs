using System.Text.RegularExpressions;

namespace MpgsSharp.Configuration;

/// <summary>
///     Configuration options for the MPGS Payment Gateway.
/// </summary>
public class MpgsOptions
{
    /// <summary>
    ///     The MPGS API base URL.
    /// </summary>
    public string ApiBaseUrl { get; set; } = string.Empty;

    /// <summary>
    ///     The API password or key used for authenticating with MPGS.
    /// </summary>
    public string ApiPassword { get; set; } = string.Empty;

    /// <summary>
    ///     The API version to use when calling MPGS endpoints.
    /// </summary>
    public string ApiVersion { get; set; } = "100";

    /// <summary>
    ///     The merchant ID used for authenticating with MPGS.
    /// </summary>
    public string MerchantId { get; set; } = string.Empty;

    /// <summary>
    ///     Timeout for HTTP requests in seconds. Default is 30 seconds.
    /// </summary>
    public int TimeoutSeconds { get; set; } = 30;

    /// <summary>
    ///     Validates the <see cref="MpgsOptions"/> configuration.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when required fields are missing or invalid.</exception>
    public void Validate()
    {
        // Ensure the API base URL is provided
        if (string.IsNullOrWhiteSpace(ApiBaseUrl))
            throw new ArgumentException("MPGS API Base URL cannot be empty", nameof(ApiBaseUrl));

        // Validate that ApiBaseUrl is a valid URL format with proper protocol
        if (!Uri.TryCreate(ApiBaseUrl, UriKind.Absolute, out var uri) ||
            (uri.Scheme != "http" && uri.Scheme != "https"))
            throw new ArgumentException("MPGS API Base URL must be a valid HTTP/HTTPS URL", nameof(ApiBaseUrl));

        // Ensure the Merchant ID is provided
        if (string.IsNullOrWhiteSpace(MerchantId))
            throw new ArgumentException("MPGS Merchant ID cannot be empty", nameof(MerchantId));

        // Ensure the Merchant ID only contains allowable characters and is proper length
        if (!Regex.IsMatch(MerchantId, @"^[0-9a-zA-Z\-_]{1,40}$"))
            throw new ArgumentException(
                "MPGS Merchant ID can only contain 0-9, a-z, A-Z, '-', '_' and must be 1-40 characters",
                nameof(MerchantId));

        // Ensure the API password is provided for authentication
        if (string.IsNullOrWhiteSpace(ApiPassword))
            throw new ArgumentException("MPGS API Password cannot be empty", nameof(ApiPassword));
    }

    /// <summary>
    ///     Sets the API base URL for MPGS.
    /// </summary>
    /// <param name="apiBaseUrl">The API base URL.</param>
    /// <returns>The options instance for chaining.</returns>
    public MpgsOptions WithApiBaseUrl(string apiBaseUrl)
    {
        ApiBaseUrl = apiBaseUrl;
        return this;
    }

    /// <summary>
    ///     Sets the API password for MPGS authentication.
    /// </summary>
    /// <param name="apiPassword">The API password.</param>
    /// <returns>The options instance for chaining.</returns>
    public MpgsOptions WithApiPassword(string apiPassword)
    {
        ApiPassword = apiPassword;
        return this;
    }

    /// <summary>
    ///     Sets the API version for MPGS.
    /// </summary>
    /// <param name="apiVersion">The API version.</param>
    /// <returns>The options instance for chaining.</returns>
    public MpgsOptions WithApiVersion(string apiVersion)
    {
        ApiVersion = apiVersion;
        return this;
    }

    /// <summary>
    ///     Sets the merchant ID for MPGS authentication.
    /// </summary>
    /// <param name="merchantId">The merchant ID.</param>
    /// <returns>The options instance for chaining.</returns>
    public MpgsOptions WithMerchantId(string merchantId)
    {
        MerchantId = merchantId;
        return this;
    }

    /// <summary>
    ///     Sets the timeout in seconds for HTTP requests.
    /// </summary>
    /// <param name="timeoutSeconds">The timeout in seconds.</param>
    /// <returns>The options instance for chaining.</returns>
    public MpgsOptions WithTimeoutSeconds(int timeoutSeconds)
    {
        TimeoutSeconds = timeoutSeconds;
        return this;
    }
}