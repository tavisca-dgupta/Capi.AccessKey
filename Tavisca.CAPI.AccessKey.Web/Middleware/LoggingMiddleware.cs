using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models.Logging;
using Tavisca.Platform.Common.Logging;
using Tavisca.Platform.Common.WebApi.Middlewares;

namespace Tavisca.CAPI.AccessKey.Web.Middleware
{
    public class LoggingMiddleware: ServiceRootLogMiddlewareBase
    {
        public LoggingMiddleware(RequestDelegate next) : base(next) { }

        protected async override Task<ApiLog> GetLog(HttpContext httpContext)
        {
            var capiApiLog = new CAPIApiLog
            {
                Request = new Payload(GetRequest(httpContext.Request)),
                Response = new Payload(GetReponse(httpContext.Response))
            };
            return capiApiLog;
        }

        protected override bool ShouldLog(HttpRequest request, HttpResponse response)
        {
            return true;
        }

        private Byte[] GetRequest(HttpRequest httpRequest)
        {
            if (httpRequest.ContentLength == null || httpRequest.ContentLength.Value == 0)
            {
                return null;
            }

            byte[] requestBytes = new byte[Convert.ToInt32(httpRequest.ContentLength)];
            httpRequest.Body.Read(requestBytes, 0, requestBytes.Length);
            httpRequest.Body.Seek(0, SeekOrigin.Begin);
            return requestBytes;
        }
        private Byte[] GetReponse(HttpResponse httpResponse)
        {
            byte[] responseBytes = new byte[Convert.ToInt32(httpResponse.ContentLength)];
            httpResponse.Body.Read(responseBytes, 0, responseBytes.Length);
            httpResponse.Body.Seek(0, SeekOrigin.Begin);
            return responseBytes;
        }
    }
}
