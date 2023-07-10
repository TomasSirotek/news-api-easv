using api.Dto;

namespace api.Helpers;

public class ResponseHelper
{
    public ResponseDto Success(HttpContext http, int statusCode, string messageToClient, object? responseData = null)
    {
        http.Response.StatusCode = statusCode;
        return new ResponseDto(messageToClient)
        {
            ResponseData = responseData
        };
    }
    public ResponseDto Error(HttpContext http, int statusCode, string messageToClient, object? responseData = null)
    {
        http.Response.StatusCode = statusCode;
        return new ResponseDto(messageToClient)
        {
            ResponseData = responseData
        };
    }
    public ResponseDto NotFound(HttpContext http, int statusCode, string messageToClient, object? responseData = null)
    {
        http.Response.StatusCode = statusCode;
        return new ResponseDto(messageToClient)
        {
            ResponseData = responseData
        };
    }
}