namespace Pquyquy.Application.Wrappers;

public class PagedResponse<T> : Response<T>
{
    [JsonProperty("pageNumber")]
    public int PageNumber { get; set; }
    
    [JsonProperty("pageSize")]
    public int PageSize { get; set; }

    public PagedResponse(T data, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Data = data;
        Succeeded = true;
        Message = string.Empty;
        Errors = new List<string>();
    }
}
