using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Platform.Common.Context;
using Tavisca.Platform.Common.Models;
using Tavisca.Platform.Common.WebApi;
using Tavisca.CAPI.AccessKey.Model.Models.CallContexts;
using Tavisca.CAPI.AccessKey.Model.Models.Common;

namespace capi_accesskey.Middlewares
{
    public class ContextInjectorMiddleware
    {
        private readonly RequestDelegate _next;

        public ContextInjectorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            List<string> missingHeaders = null;
            List<string> invalidHeaders = null;

            CAPIAccessKeyCallContext callContext = httpContext.Request.Path.ToUriComponent().IndexOf("health", StringComparison.CurrentCultureIgnoreCase) != -1
                                                 ? new CAPIAccessKeyCallContext(KeyStore.Api.HealthCheck, "is_healthy", "", Guid.NewGuid().ToString(), "demo", null, false, KeyStore.ApplicationName, "")
                                                 : CapiKeyCallContextCreator.CreateCallContext(httpContext?.Request, DateTime.UtcNow, out missingHeaders, out invalidHeaders);

            httpContext.Response.Headers.Append(KeyStore.HeaderName.CorrelationId, callContext.CorrelationId);


            if ((missingHeaders != null && missingHeaders.Count > 0) || (invalidHeaders != null && invalidHeaders.Count > 0))
            {
                var errorInfo = new ErrorInfo(FaultCodes.ValidationFailure, ErrorMessages.ValidationFailure(), System.Net.HttpStatusCode.BadRequest);
                if (missingHeaders != null && missingHeaders.Count > 0)
                    errorInfo.Info.Add(new Info(FaultCodes.MissingRequestHeaders, ErrorMessages.MissingRequestHeaders(missingHeaders)));
                if (invalidHeaders != null && invalidHeaders.Count > 0)
                    errorInfo.Info.Add(new Info(FaultCodes.InvalidRequestHeaders, ErrorMessages.InvalidRequestHeaders(invalidHeaders)));

                httpContext.Response.StatusCode = (int)errorInfo.HttpStatusCode;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorInfo, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), Converters = new List<JsonConverter> { new ErrorInfoTranslator(), new InfoTranslator() } }));
            }
            else
            {
                using (new AmbientContextScope(callContext))
                {
                    await _next.Invoke(httpContext);
                }
            }
        }


    }
}
