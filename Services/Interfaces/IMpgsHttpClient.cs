namespace MpgsSharp.Services.Interfaces;

/// <summary>
///     Interface for HTTP communication with the MPGS API.
/// </summary>
public interface IMpgsHttpClient
{
    /// <summary>
    ///     Sends a GET request to the specified MPGS API endpoint.
    /// </summary>
    /// <typeparam name="TResponse">The type of response expected.</typeparam>
    /// <param name="endpoint">The API endpoint path.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The deserialized response.</returns>
    Task<TResponse> GetAsync<TResponse>(string endpoint, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Sends a POST request with a payload to the specified MPGS API endpoint.
    /// </summary>
    /// <typeparam name="TRequest">The type of request data.</typeparam>
    /// <typeparam name="TResponse">The type of response expected.</typeparam>
    /// <param name="endpoint">The API endpoint path.</param>
    /// <param name="payload">The request payload.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The deserialized response.</returns>
    Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest payload,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Sends a PUT request with a payload to the specified MPGS API endpoint.
    /// </summary>
    /// <typeparam name="TRequest">The type of request data.</typeparam>
    /// <typeparam name="TResponse">The type of response expected.</typeparam>
    /// <param name="endpoint">The API endpoint path.</param>
    /// <param name="payload">The request payload.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The deserialized response.</returns>
    Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest payload,
        CancellationToken cancellationToken = default);
}