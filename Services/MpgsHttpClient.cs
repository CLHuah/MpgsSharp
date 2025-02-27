using Microsoft.Extensions.Logging;
using MpgsSharp.Configuration;
using MpgsSharp.Exceptions;
using MpgsSharp.Models.Error;
using MpgsSharp.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MpgsSharp.Services;

/// <summary>
///     Implementation of the HTTP client for MPGS API communication.
/// </summary>
internal class MpgsHttpClient : IMpgsHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly ILogger<MpgsHttpClient> _logger;
    private readonly MpgsOptions _options;

    /// <summary>
    ///     Initializes a new instance of the <see cref="MpgsHttpClient" /> class.
    /// </summary>
    public MpgsHttpClient(HttpClient httpClient, MpgsOptions options, ILogger<MpgsHttpClient> logger)
    {
        _httpClient = httpClient;
        _options = options;
        _logger = logger;

        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = false
        };

        // Set default headers - authentication is now handled by NetworkCredential in the handler
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    /// <inheritdoc />
    public async Task<TResponse> GetAsync<TResponse>(string endpoint, CancellationToken cancellationToken = default)
    {
        var fullEndpoint = BuildEndpointPath(endpoint);
        _logger.LogInformation("Sending GET request to {Endpoint}", fullEndpoint);

        using var response = await _httpClient.GetAsync(fullEndpoint, cancellationToken);
        return await ProcessResponseAsync<TResponse>(response, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest payload,
        CancellationToken cancellationToken = default)
    {
        var fullEndpoint = BuildEndpointPath(endpoint);
        _logger.LogInformation("Sending POST request to {Endpoint}", fullEndpoint);

        var content = SerializeContent(payload);
        using var response = await _httpClient.PostAsync(fullEndpoint, content, cancellationToken);
        return await ProcessResponseAsync<TResponse>(response, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest payload,
        CancellationToken cancellationToken = default)
    {
        var fullEndpoint = BuildEndpointPath(endpoint);
        _logger.LogInformation("Sending PUT request to {Endpoint}", fullEndpoint);

        var content = SerializeContent(payload);
        using var response = await _httpClient.PutAsync(fullEndpoint, content, cancellationToken);
        return await ProcessResponseAsync<TResponse>(response, cancellationToken);
    }

    private string BuildEndpointPath(string endpoint)
    {
        // Replace placeholders with actual values
        return endpoint.Replace("{apiVersion}", _options.ApiVersion).Replace("{merchantId}", _options.MerchantId);
    }

    private async Task<TResponse> ProcessResponseAsync<TResponse>(HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        var content = await response.Content.ReadAsStringAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("API request failed with status code {StatusCode}. Response: {Response}",
                response.StatusCode, content);

            // Try to deserialize as an error response
            try
            {
                var errorResponse = JsonSerializer.Deserialize<MpgsErrorResponse>(content, _jsonOptions);
                if (errorResponse != null)
                    throw new MpgsApiException(
                        $"API request failed with status code {(int)response.StatusCode}",
                        (int)response.StatusCode,
                        errorResponse);
            }
            catch (JsonException ex)
            {
                _logger.LogDebug(ex, "Could not deserialize error response");
                // Fall back to generic exception if we can't parse the error
            }

            // Fallback to standard exception
            throw new HttpRequestException(
                $"API request failed with status code {response.StatusCode}. Response: {content}");
        }

        _logger.LogDebug("Received response: {Response}", content);

        try
        {
            var result = JsonSerializer.Deserialize<TResponse>(content, _jsonOptions);
            if (result == null)
                throw new InvalidOperationException("Failed to deserialize response to the expected type");
            return result;
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to deserialize response: {Response}", content);
            throw new InvalidOperationException("Failed to deserialize API response", ex);
        }
    }

    /// <summary>
    ///     Serializes a request payload to JSON format for HTTP transmission.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request payload to serialize.</typeparam>
    /// <param name="payload">The object to serialize into JSON.</param>
    /// <returns>
    ///     An <see cref="HttpContent" /> object containing the JSON serialized payload with appropriate
    ///     content type headers for the MPGS API.
    /// </returns>
    /// <remarks>
    ///     Uses the configured JSON serialization options to ensure proper casing and null handling.
    ///     The content is encoded using UTF-8 and set with application/json content type.
    /// </remarks>
    private HttpContent SerializeContent<TRequest>(TRequest payload)
    {
        // Convert the payload object to a JSON string using configured serializer options
        var json = JsonSerializer.Serialize(payload, _jsonOptions);

        // Log the serialized content at debug level for troubleshooting
        _logger.LogDebug("Request payload: {Payload}", json);

        // Create and return a StringContent with appropriate encoding and MIME type
        return new StringContent(json, Encoding.UTF8, "application/json");
    }
}