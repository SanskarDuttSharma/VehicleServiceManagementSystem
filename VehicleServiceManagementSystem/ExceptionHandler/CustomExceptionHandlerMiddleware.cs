using VehicleServiceManagementSystem.SystemLogger;

namespace VehicleServiceManagementSystem.ExceptionHandler
{
    public class CustomExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ISystemLogger _logger;

        public CustomExceptionHandlerMiddleware(ISystemLogger logger)
        {
            _logger = logger;   
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
            }
        }
    }
}
