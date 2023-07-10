namespace api.Dto;

public class ResponseDto
{
    public ResponseDto(string message)
    {
        MessageToClient = message;
    }
    public string MessageToClient { get; set; }
    public object? ResponseData { get; set; }
}