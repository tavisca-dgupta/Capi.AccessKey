using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Tavisca.Platform.Common.WebApi.Middlewares;
using Tavisca.Platform.Common.Logging;
using Tavisca.Platform.Common.Profiling;
using Tavisca.CAPI.AccessKey.Model.Models.CallContexts;
using Tavisca.Platform.Common.Plugins.Json;

namespace Tavisca.CAPI.AccessKey.Web.Middleware
{
    public class ProfilingMiddleware : ProfilingMiddlewareBase
    {
        public ProfilingMiddleware(RequestDelegate next) : base(next) { }

        public override Task<ApiLog> GetProfileLog(ProfileTreeNode profileData)
        {
            if (profileData == null) return Task.FromResult<ApiLog>(null);

            var apiLog = new ApiLog()
            {
                ApplicationName = CAPIAccessKeyCallContext.Current.ApplicationName,
                CorrelationId = CAPIAccessKeyCallContext.Current.CorrelationId,
                StackId = CAPIAccessKeyCallContext.Current.StackId,
                Api = CAPIAccessKeyCallContext.Current.Api,
                Verb = CAPIAccessKeyCallContext.Current.Verb,
                IsSuccessful = true,
                Response = new Payload(ByteHelper.ToByteArrayUsingJsonSerialization(profileData)),
                TimeTakenInMs = profileData.PerformanceLog.TotalExecutionTime?.TotalMilliseconds ?? 0
            };

            return Task.FromResult<ApiLog>(apiLog);
        }

        public override bool IsProfilingEnabled()
        {
            return CAPIAccessKeyCallContext.Current.IsProfilingEnabled;
        }
    }
}
