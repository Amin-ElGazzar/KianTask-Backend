using System.Net;

namespace Kian.Response;

public class Response<TEntity>
{
    public HttpStatusCode StatusCode { get; set; }
    public bool Succeeded { get; set; } = true;
    public string Message { get; set; }
    public TEntity Data { get; set; }
}