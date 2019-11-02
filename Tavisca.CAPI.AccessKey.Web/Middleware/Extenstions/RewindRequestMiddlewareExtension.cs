using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tavisca.CAPI.AccessKey.Web.Middleware.Extenstions
{
    public static class RewindRequestMiddlewareExtension
    {
        public static IApplicationBuilder UseRewindContextStreamMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RewindRequestMiddleware>();
        }
    }
}
