namespace api.Dto;

public class ResponseDto
{
    public ResponseDto(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
    public object? ResponseData { get; set; }
}