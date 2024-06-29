namespace Pquyquy.Application.Wrappers;

/// <summary>
/// Represents a paged response wrapper extending Response<T>.
/// </summary>
/// <typeparam name="T">Type of the data.</typeparam>
public class PagedResponse<T> : Response<T>
{
    /// <summary>
    /// Page number of the current page.
    /// </summary>
    [JsonProperty("pageNumber")]
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// Size of each page.
    /// </summary>
    [JsonProperty("pageSize")]
    public int PageSize { get; set; } = 10;

    /// <inheritdoc/>
    [Obsolete("PageNumber and PageSize are required for a successful paged response.")]
    public static new Response<T> Success() =>
        throw new InvalidOperationException("PageNumber and PageSize are required for a successful paged response.");

    /// <inheritdoc/>
    [Obsolete("PageNumber and PageSize are required for a successful paged response.")]
    public static new Response<T> Success(T data) =>
        throw new InvalidOperationException("PageNumber and PageSize are required for a successful paged response.");

    /// <inheritdoc/>
    [Obsolete("PageNumber and PageSize are required for a successful paged response.")]
    public static new Response<T> Success(T data, string message = "") =>
        throw new InvalidOperationException("PageNumber and PageSize are required for a successful paged response.");

    /// <summary>
    /// Creates a successful paged response without data.
    /// </summary>
    /// <param name="pageNumber">Current page number.</param>
    /// <param name="pageSize">Size of each page.</param>
    /// <returns>Instance of PagedResponse indicating success.</returns>
    public static PagedResponse<T> Success(int pageNumber, int pageSize) =>
        new() { PageNumber = pageNumber, PageSize = pageSize, Succeeded = true };

    /// <summary>
    /// Creates a successful paged response with data.
    /// </summary>
    /// <param name="data">Data to include in the response.</param>
    /// <param name="pageNumber">Current page number.</param>
    /// <param name="pageSize">Size of each page.</param>
    /// <returns>Instance of PagedResponse indicating success with data.</returns>
    public static PagedResponse<T> Success(T data, int pageNumber, int pageSize) =>
        new() { PageNumber = pageNumber, PageSize = pageSize, Succeeded = true, Data = data };

    /// <inheritdoc/>
    [Obsolete("PageNumber and PageSize are required for a successful paged response.")]
    public static new Response<T> Failure(string message) =>
        throw new InvalidOperationException("PageNumber and PageSize are required for a successful paged response.");

    /// <inheritdoc/>
    [Obsolete("PageNumber and PageSize are required for a successful paged response.")]
    public static new Response<T> Failure(string message, List<string> errors) =>
        throw new InvalidOperationException("PageNumber and PageSize are required for a successful paged response.");

    /// <summary>
    /// Creates a failed paged response without message or errors.
    /// </summary>
    /// <param name="pageNumber">Current page number.</param>
    /// <param name="pageSize">Size of each page.</param>
    /// <returns>Instance of PagedResponse indicating failure.</returns>
    public static PagedResponse<T> Failure(int pageNumber, int pageSize) =>
        new() { PageNumber = pageNumber, PageSize = pageSize, Succeeded = false };

    /// <summary>
    /// Creates a failed paged response with specified message.
    /// </summary>
    /// <param name="message">Message indicating reason for failure.</param>
    /// <param name="pageNumber">Current page number.</param>
    /// <param name="pageSize">Size of each page.</param>
    /// <returns>Instance of PagedResponse indicating failure with message.</returns>
    public static PagedResponse<T> Failure(string message, int pageNumber, int pageSize) =>
        new() { PageNumber = pageNumber, PageSize = pageSize, Succeeded = false, Message = message };

    /// <summary>
    /// Creates a failed paged response with specified message and errors.
    /// </summary>
    /// <param name="message">Message indicating reason for failure.</param>
    /// <param name="errors">List of errors encountered.</param>
    /// <param name="pageNumber">Current page number.</param>
    /// <param name="pageSize">Size of each page.</param>
    /// <returns>Instance of PagedResponse indicating failure with message and errors.</returns>
    public static PagedResponse<T> Failure(string message, List<string> errors, int pageNumber, int pageSize) =>
        new() { PageNumber = pageNumber, PageSize = pageSize, Succeeded = false, Message = message, Errors = errors };
}
