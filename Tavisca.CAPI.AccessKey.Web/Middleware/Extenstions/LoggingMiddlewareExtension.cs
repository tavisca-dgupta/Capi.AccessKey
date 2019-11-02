using Microsoft.AspNetCore.Builder;
namespace Tavisca.CAPI.AccessKey.Web.Middleware.Extenstions
{
    public static class LoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
