using System.Text.Json.Serialization;

namespace MpgsSharp.Models.Error;

/// <summary>
///     Represents an error response from the MPGS API.
/// </summary>
public class MpgsErrorResponse
{
    /// <summary>
    ///     Detailed error information.
    /// </summary>
    [JsonPropertyName("error")]
    public ErrorDetails? Error { get; set; }

    /// <summary>
    ///     The result of the operation, typically "ERROR" for error responses.
    /// </summary>
    [JsonPropertyName("result")]
    public string? Result { get; set; }
}

/// <summary>
///     Detailed error information provided by the MPGS API.
/// </summary>
public class ErrorDetails
{
    /// <summary>
    ///     The cause of the error.
    /// </summary>
    [JsonPropertyName("cause")]
    public string? Cause { get; set; }

    /// <summary>
    ///     Detailed explanation of the error.
    /// </summary>
    [JsonPropertyName("explanation")]
    public string? Explanation { get; set; }

    /// <summary>
    ///     The field related to the error, if applicable.
    /// </summary>
    [JsonPropertyName("field")]
    public string? Field { get; set; }

    /// <summary>
    ///     A support code that can be referenced when contacting MPGS support.
    /// </summary>
    [JsonPropertyName("supportCode")]
    public string? SupportCode { get; set; }

    /// <summary>
    ///     The type of validation that failed, if applicable.
    /// </summary>
    [JsonPropertyName("validationType")]
    public string? ValidationType { get; set; }
}