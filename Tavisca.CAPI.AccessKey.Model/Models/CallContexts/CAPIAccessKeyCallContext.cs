using System;
using System.Net;
using Tavisca.Platform.Common.Context;
namespace Tavisca.CAPI.AccessKey.Model.Models.CallContexts
{
    public class CAPIAccessKeyCallContext : CallContext
    {
        public CAPIAccessKeyCallContext(string api, string verb, string sessionId, string correlationId, string tenantId,
          IPAddress ipAddress, bool isProfilingEnabled, string applicationName,
          string environmentToken = null)
        {
            Api = api;
            Verb = verb;
            SessionId = sessionId;
            EnvironmentToken = environmentToken;
            CorrelationId = correlationId;
            TenantId = tenantId;
            IpAddress = ipAddress;
            IsProfilingEnabled = isProfilingEnabled;
            ApplicationName = applicationName;

        }
        public bool IsLoggingEnabled { get; set; }
        public new static CAPIAccessKeyCallContext Current => (CAPIAccessKeyCallContext)AmbientContextBase.Current;
        public string Api { get; set; }
        public string Verb { get; set; }
        public string SessionId { get; set; }
        public string EnvironmentToken { get; set; }
    }
}
