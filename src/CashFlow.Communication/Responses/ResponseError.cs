namespace CashFlow.Communication.Responses;

public class ResponseError
{
    public List<string> Errors { get; set; }

    public ResponseError(string errors)
    {
        Errors = [errors];
    }

    public ResponseError(List<string> errors)
    {
        Errors = errors;
    }
}