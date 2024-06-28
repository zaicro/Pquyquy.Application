namespace Pquyquy.Application.Wrappers;

public class Response<T>
{
    [JsonProperty("succeeded")]
    public bool Succeeded { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; } = "";

    [JsonProperty("errors")]
    public List<string> Errors { get; set; } = [];

    [JsonProperty("data")]
    public T Data { get; set; } = default!;

    #region Non Async Success Methods 

    public static Response<T> Success()
    {
        return new Response<T>
        {
            Succeeded = true
        };
    }

    public static Response<T> Success(string message)
    {
        return new Response<T>
        {
            Succeeded = true,
            Message = message
        };
    }

    public static Response<T> Success(T data)
    {
        return new Response<T>
        {
            Succeeded = true,
            Data = data
        };
    }

    public static Response<T> Success(T data, string message)
    {
        return new Response<T>
        {
            Succeeded = true,
            Message = message,
            Data = data
        };
    }
    #endregion

    #region Non Async Failure Methods 

    public static Response<T> Failure()
    {
        return new Response<T>
        {
            Succeeded = false
        };
    }

    public static Response<T> Failure(string message)
    {
        return new Response<T>
        {
            Succeeded = false,
            Message = message
        };
    }

    public static Response<T> Failure(T data)
    {
        return new Response<T>
        {
            Succeeded = false,
            Data = data
        };
    }

    public static Response<T> Failure(T data, string message)
    {
        return new Response<T>
        {
            Succeeded = false,
            Message = message,
            Data = data
        };
    }

    public static Response<T> Failure(string message, List<string> errors)
    {
        return new Response<T>
        {
            Succeeded = false,
            Message = message,
            Errors = errors
        };
    }
    #endregion

    #region Async Success Methods 

    public static Task<Response<T>> SuccessAsync()
    {
        return Task.FromResult(Success());
    }

    public static Task<Response<T>> SuccessAsync(string message)
    {
        return Task.FromResult(Success(message));
    }

    public static Task<Response<T>> SuccessAsync(T data)
    {
        return Task.FromResult(Success(data));
    }

    public static Task<Response<T>> SuccessAsync(T data, string message)
    {
        return Task.FromResult(Success(data, message));
    }
    #endregion

    #region Non Async Failure Methods 

    public static Task<Response<T>> FailureAsync()
    {
        return Task.FromResult(Failure());
    }

    public static Task<Response<T>> FailureAsync(string message)
    {
        return Task.FromResult(Failure(message));
    }

    public static Task<Response<T>> FailureAsync(T data)
    {
        return Task.FromResult(Failure(data));
    }

    public static Task<Response<T>> FailureAsync(T data, string message)
    {
        return Task.FromResult(Failure(data, message));
    }

    public static Task<Response<T>> FailureAsync(string message, List<string> errors)
    {
        return Task.FromResult(Failure(message, errors));
    }
    #endregion
}
