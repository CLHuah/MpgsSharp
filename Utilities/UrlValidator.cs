namespace MpgsSharp.Utilities;

/// <summary>
///     Provides URL validation utilities.
/// </summary>
public static class UrlValidator
{
    /// <summary>
    ///     Validates if the provided URL is a valid HTTPS URL.
    /// </summary>
    /// <param name="url">The URL to validate.</param>
    /// <returns>True if the URL is a valid HTTPS URL; otherwise, false.</returns>
    public static bool IsValidHttpsUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var uriResult) && uriResult.Scheme == Uri.UriSchemeHttps;
    }
}