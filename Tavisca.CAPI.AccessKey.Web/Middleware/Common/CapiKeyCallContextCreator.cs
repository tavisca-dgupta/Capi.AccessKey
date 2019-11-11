using capi_accesskey.Middlewares.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Net;
using Tavisca.CAPI.AccessKey.Model.Models.CallContexts;
using Tavisca.CAPI.AccessKey.Model.Models.Common;
using Tavisca.CAPI.AccessKey.Web.Middleware.Extensions;
using Tavisca.Platform.Common.Configurations;

namespace capi_accesskey.Middlewares
{
    class CapiKeyCallContextCreator
    {


        public static CAPIAccessKeyCallContext CreateCallContext(HttpRequest httpRequest, DateTime? startTime, out List<string> missingHeaders, out List<string> invalidHeaders)
        {
            var headerDictionary = httpRequest?.Headers;
            var queryCollections = httpRequest?.Query;

            missingHeaders = new List<string>();
            invalidHeaders = new List<string>();

            var correlationId = GetHeaderValue(headerDictionary, KeyStore.HeaderName.CorrelationId, false, ref missingHeaders);

            if (string.IsNullOrEmpty(correlationId))
                correlationId = Guid.NewGuid().ToString();


            var ipAddressString = GetHeaderValue(headerDictionary, KeyStore.HeaderName.IpAddress, false, ref missingHeaders);

            var clientTenantId = GetHeaderValue(headerDictionary, KeyStore.HeaderName.TenantId, false, ref missingHeaders);

            IPAddress ipAddress;
            if (!IPAddress.TryParse(ipAddressString, out ipAddress))
                ipAddress = null;

            var environmentToken = GetHeaderValue(headerDictionary, KeyStore.HeaderName.EnvironmentToken, false, ref missingHeaders);


            var isProfilingEnabled = HasDebugTrueQueryString(queryCollections) || IsProfilingEnabled();

            var urlMapping = RoutingExtensions.GetRouteMapping(httpRequest);

            var CAPIAccessKeyCallContext = new CAPIAccessKeyCallContext(urlMapping.api, urlMapping.verb, string.Empty, correlationId, clientTenantId, ipAddress,
                 isProfilingEnabled, KeyStore.ApplicationName, environmentToken);

            CAPIAccessKeyCallContext.IsLoggingEnabled = IsLoggingEnabled();

            return CAPIAccessKeyCallContext;
        }
        private static bool HasDebugTrueQueryString(IQueryCollection query)
        {
            if (query.TryGetValue("debug", out StringValues debugValue) && string.Equals(debugValue, "true", StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        private static string GetHeaderValue(IHeaderDictionary requestHeaders, string headerName, bool isMandatory, ref List<string> missingHeaders)
        {
            if (requestHeaders != null && requestHeaders.TryGetValue(headerName, out var values) && !string.IsNullOrWhiteSpace(values))
            {
                return values;
            }
            if (isMandatory)
                missingHeaders.Add(headerName);
            return null;
        }
        private static bool IsProfilingEnabled()
        {
            bool isProfilingEnabled = true;
            return isProfilingEnabled;
        }
        private static bool IsLoggingEnabled()
        {
            bool isLogggingEnabled = true;
            return isLogggingEnabled;
        }
    }
}