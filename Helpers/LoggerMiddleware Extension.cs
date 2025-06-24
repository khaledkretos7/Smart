using Microsoft.AspNetCore.Builder;

namespace SmartCity.Helpers
{
    public static class LoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerMiddleware>();
        }
    }
}
