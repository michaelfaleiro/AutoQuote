namespace AutoQuote.Communication.Response;

public class ResponseJson<TData>
{
    public ResponseJson(TData data)
    {
        Data = data;
    }
    
    public TData Data { get; set; }
    
}