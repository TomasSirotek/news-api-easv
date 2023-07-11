using api.Dto;

namespace api.Helpers;

public class ResponseHelper
{
    public ResponseDto CreateResponse(HttpContext http, StatusCodeType statusCodeType, string messageToClient, object? responseData = null)
    {
        http.Response.StatusCode = (int)statusCodeType;
        return new ResponseDto(messageToClient)
        {
            ResponseData = responseData
        };
    }
}