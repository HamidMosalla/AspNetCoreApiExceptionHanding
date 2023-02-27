using System.Text.Json;

namespace ApiExceptionHandling.GlobalErrorHandlingTheWrongWay
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorDetailsDebug : ErrorDetails
    {
        public ErrorDetailsDebug(ErrorDetails details)
        {
            StatusCode = details.StatusCode;
            Message = details.Message;
            Type= details.Type;
        }

        public string? ExceptionStackTrace { get; set; }
        public string? InnerExceptionStackTrace { get; set; }
        public string? InnerExceptionMessage { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionPath { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}