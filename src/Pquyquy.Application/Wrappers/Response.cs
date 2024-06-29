namespace Pquyquy.Application.Wrappers;

/// <summary>
/// Represents a standard response wrapper.
/// </summary>
/// <typeparam name="T">Type of the data.</typeparam>
public class Response<T>
{
    /// <summary>
    /// Indicates if the operation succeeded.
    /// </summary>
    [JsonProperty("succeeded")]
    public bool Succeeded { get; set; }

    /// <summary>
    /// Optional message associated with the response.
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; } = "";

    /// <summary>
    /// List of errors encountered during the operation.
    /// </summary>
    [JsonProperty("errors")]
    public List<string> Errors { get; set; } = [];

    /// <summary>
    /// Data returned by the operation.
    /// </summary>
    [JsonProperty("data")]
    public T Data { get; set; } = default!;

    /// <summary>
    /// Creates a success response without data.
    /// </summary>
    /// <returns>Instance of Response indicating success.</returns>
    public static Response<T> Success() => 
        new() { Succeeded = true };

    /// <summary>
    /// Creates a success response with specified data.
    /// </summary>
    /// <param name="data">Data to include in the response.</param>
    /// <returns>Instance of Response indicating success with data.</returns>
    public static Response<T> Success(T data) => 
        new() { Succeeded = true, Data = data };

    /// <summary>
    /// Creates a success response with specified data and message.
    /// </summary>
    /// <param name="data">Data to include in the response.</param>
    /// <param name="message">Message to include in the response.</param>
    /// <returns>Instance of Response indicating success with data and message.</returns>
    public static Response<T> Success(T data, string message) => 
        new() { Succeeded = true, Message = message, Data = data };

    /// <summary>
    /// Creates a failure response with specified message.
    /// </summary>
    /// <param name="message">Message indicating reason for failure.</param>
    /// <returns>Instance of Response indicating failure with message.</returns>
    public static Response<T> Failure(string message) => 
        new() { Succeeded = false, Message = message };

    /// <summary>
    /// Creates a failure response with specified message and list of errors.
    /// </summary>
    /// <param name="message">Message indicating reason for failure.</param>
    /// <param name="errors">List of errors encountered.</param>
    /// <returns>Instance of Response indicating failure with message and errors.</returns>
    public static Response<T> Failure(string message, List<string> errors) => 
        new() { Succeeded = false, Message = message, Errors = errors };
}
