using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace capi_accesskey.Middlewares.Extensions
{
    public static class ContextInjectorMiddlewareExtension
    {
        public static IApplicationBuilder UseContextInjector(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContextInjectorMiddleware>();
        }
    }
}
