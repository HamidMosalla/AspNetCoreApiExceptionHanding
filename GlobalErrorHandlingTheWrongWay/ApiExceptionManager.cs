//namespace ApiExceptionHandling.GlobalErrorHandlingTheWrongWay
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public class ApiExceptionManager 
//    {
//        private readonly IDictionary<Type, Func<ErrorDetails>> exceptionHandlers;

//        /// <summary>
//        /// 
//        /// </summary>
//        public ApiExceptionManager()
//        {
//            exceptionHandlers = new Dictionary<Type, Func<ErrorDetails>>()
//            {
//                { typeof(ValidationException), HandleValidationException },
//                { typeof(NotFoundException), HandleNotFoundException },
//                { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
//                { typeof(ForbiddenAccessException), HandleForbiddenAccessException },
//            };
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="exception"></param>
//        /// <returns></returns>
//        public ErrorDetails HandleException(Exception exception)
//        {
//            Type type = exception.GetType();
//            if (exceptionHandlers.ContainsKey(type))
//            {
//                return exceptionHandlers[type].Invoke();
//            }
//            else
//            {
//                return HandleUnknownException();
//            }
//        }

//        private ErrorDetails HandleForbiddenAccessException()
//        {
//            var details = new ErrorDetails
//            {
//                StatusCode = StatusCodes.Status403Forbidden,
//                Message = "Forbidden",
//                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3"
//            };
//            return details;
//        }

//        private ErrorDetails HandleNotFoundException()
//        {
//            var details = new ErrorDetails()
//            {
//                StatusCode = StatusCodes.Status404NotFound,
//                Message = "The specified resource was not found.",
//                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4"
//            };
//            return details;
//        }

//        private ErrorDetails HandleUnauthorizedAccessException()
//        {
//            var details = new ErrorDetails
//            {
//                StatusCode = StatusCodes.Status401Unauthorized,
//                Message = "Unauthorized",
//                Type = "https://tools.ietf.org/html/rfc7235#section-3.1"
//            };
//            return details;
//        }

//        private ErrorDetails HandleUnknownException()
//        {
//            var details = new ErrorDetails
//            {
//                StatusCode = StatusCodes.Status500InternalServerError,
//                Message = "An error occurred while processing your request.",
//                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
//            };
//            return details;
//        }

//        private ErrorDetails HandleValidationException()
//        {
//            var details = new ErrorDetails()
//            {
//                StatusCode = StatusCodes.Status400BadRequest,
//                Message = "Validation failed",
//                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
//            };
//            return details;
//        }
//    }
//}