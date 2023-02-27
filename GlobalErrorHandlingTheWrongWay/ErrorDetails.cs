using System.Text.Json;

namespace ApiExceptionHandling.GlobalErrorHandlingTheWrongWay
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}