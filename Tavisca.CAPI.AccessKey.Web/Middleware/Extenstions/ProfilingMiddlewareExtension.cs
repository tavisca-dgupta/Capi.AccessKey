using Microsoft.AspNetCore.Builder;
namespace Tavisca.CAPI.AccessKey.Web.Middleware.Extensions
{
    public static class ProfilingMiddlewareExtension
    {
        public static IApplicationBuilder UseProfiling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ProfilingMiddleware>();
        }
    }
}
