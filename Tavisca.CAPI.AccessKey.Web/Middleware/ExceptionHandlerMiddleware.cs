using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tavisca.Platform.Common.Logging;
using Tavisca.Platform.Common.WebApi.Middlewares;

namespace Tavisca.CAPI.AccessKey.Web.Middleware
{
    public class ExceptionHandlerMiddleware: ErrorHandlerMiddlewareBase
    {
        public ExceptionHandlerMiddleware(RequestDelegate next) : base(next) { }
        public override Task<ILog> GetExceptionLogAsync(Exception exception, HttpContext context, CancellationToken token)
        {
            var exceptionLog = new ExceptionLog(exception);
            return Task.FromResult<ILog>(exceptionLog);
        }
    }
}
