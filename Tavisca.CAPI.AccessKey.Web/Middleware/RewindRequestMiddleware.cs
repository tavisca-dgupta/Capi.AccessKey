using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;
using System.Threading.Tasks;

namespace Tavisca.CAPI.AccessKey.Web.Middleware
{
    public class RewindRequestMiddleware
    {
        public RewindRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private readonly RequestDelegate _next;
        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Request.EnableRewind();
            Stream originalBody = httpContext.Response.Body;

            using (var memStream = new MemoryStream())
            {
                httpContext.Response.Body = memStream;
                await _next.Invoke(httpContext);
                if (httpContext.Response.StatusCode != StatusCodes.Status204NoContent &&
                    httpContext.Response.StatusCode != StatusCodes.Status304NotModified)
                {
                    memStream.Position = 0;
                    await memStream.CopyToAsync(originalBody);
                }

            }

        }
    }
}
