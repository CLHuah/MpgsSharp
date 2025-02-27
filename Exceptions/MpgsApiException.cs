using MpgsSharp.Models.Error;

namespace MpgsSharp.Exceptions;

/// <summary>
/// Exception thrown when an MPGS API request fails with an error response.
/// </summary>
public class MpgsApiException : Exception
{
    /// <summary>
    /// Gets the detailed error response from the MPGS API.
    /// </summary>
    public MpgsErrorResponse ErrorResponse { get; }
    
    /// <summary>
    /// Gets the HTTP status code of the response.
    /// </summary>
    public int StatusCode { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MpgsApiException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="errorResponse">The detailed error response.</param>
    public MpgsApiException(string message, int statusCode, MpgsErrorResponse errorResponse) 
        : base(FormatMessage(message, errorResponse))
    {
        StatusCode = statusCode;
        ErrorResponse = errorResponse;
    }
    
    private static string FormatMessage(string baseMessage, MpgsErrorResponse errorResponse)
    {
        if (errorResponse?.Error == null)
            return baseMessage;
            
        return $"{baseMessage}. Cause: {errorResponse.Error.Cause}, " +
               $"Explanation: {errorResponse.Error.Explanation}, " +
               $"Field: {errorResponse.Error.Field}, " +
               $"Support Code: {errorResponse.Error.SupportCode}";
    }
}
