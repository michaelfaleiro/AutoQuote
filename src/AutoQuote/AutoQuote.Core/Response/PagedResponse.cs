namespace AutoQuote.Core.Response;

public class PagedResponse<TData>
{
    public PagedResponse(IEnumerable<TData> data, int page, int pageSize, int total)
    {
        Data = data;
        Page = page;
        PageSize = pageSize;
        Total = total;
    }

    public IEnumerable<TData> Data { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
    
}