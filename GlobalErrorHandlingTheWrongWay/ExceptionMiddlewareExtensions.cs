//using Microsoft.AspNetCore.Diagnostics;

//namespace ApiExceptionHandling.GlobalErrorHandlingTheWrongWay
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public static class ExceptionMiddlewareExtensions
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="app"></param>
//        /// <param name="logger"></param>
//        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger, bool debug = false)
//        {
//            app.UseExceptionHandler(appError =>
//            {
//                appError.Run(async context =>
//                {
//                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
//                    if (contextFeature != null)
//                    {
//                        logger.LogError(contextFeature.Error,
//                            $@"An error has occurred, please check the logs for more information.
//                                    {Environment.NewLine} ErrorMessage: {contextFeature.Error.Message}
//                                    {Environment.NewLine} Path: {contextFeature.Path}
//                                    {Environment.NewLine} Endpoint: {contextFeature.Endpoint}
//                                    {Environment.NewLine} RouteValues: {string.Join(',', contextFeature.RouteValues ?? new RouteValueDictionary())}");


//                        var exceptionManager = new ApiExceptionManager();
//                        var details = exceptionManager.HandleException(contextFeature.Error);

//                        string bodyResponse;
//                        if (debug)
//                        {
//                            bodyResponse = new ErrorDetailsDebug(details)
//                            {
//                                ExceptionMessage = contextFeature.Error.Message,
//                                ExceptionStackTrace = contextFeature.Error.StackTrace,
//                                InnerExceptionStackTrace = contextFeature.Error.InnerException?.StackTrace,
//                                InnerExceptionMessage = contextFeature.Error.InnerException?.Message,
//                                ExceptionPath = contextFeature.Path
//                            }.ToString();
//                        }
//                        else
//                        {
//                            bodyResponse = details.ToString();
//                        }

//                        context.Response.StatusCode = details.StatusCode;
//                        context.Response.ContentType = "application/json";
//                        await context.Response.WriteAsync(bodyResponse);
//                    }
//                });
//            });
//        }
//    }
//}