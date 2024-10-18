namespace Kian.Response;

public class ResponseHandler<TEntity>
{


    public Response<TEntity> Created()
    {
        return new Response<TEntity>()
        {
            StatusCode = System.Net.HttpStatusCode.Created,
            Succeeded = true,
            Message = "Created"

        };
    }

    public Response<TEntity> Success(TEntity entity, string? message = null, object? meta = null)
    {
        return new Response<TEntity>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = "Successfully"

        };
    }

    public Response<TEntity> EditSuccess<TEntity>(TEntity entity)
    {
        return new Response<TEntity>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = "Updated"

        };
    }

    public Response<TEntity> Deleted<TEntity>()
    {
        return new Response<TEntity>()
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = "Deleted"
        };
    }



    public Response<TEntity> BadRequest(string message = null)
    {
        return new Response<TEntity>()
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Succeeded = false,
            Message = string.IsNullOrEmpty(message) ? "BadRequest" : message
        };
    }

    public Response<TEntity> NotFound(string message = null)
    {
        return new Response<TEntity>()
        {
            StatusCode = System.Net.HttpStatusCode.NotFound,
            Succeeded = false,
            Message = string.IsNullOrEmpty(message) ? "NotFound" : message
        };
    }



}
