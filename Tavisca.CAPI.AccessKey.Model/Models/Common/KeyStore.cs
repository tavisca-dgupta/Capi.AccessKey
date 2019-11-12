using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.CAPI.AccessKey.Model.Models.Common
{
    public class KeyStore
    {
        public static readonly string ApplicationName = "capi";
        public static class LogKeys
        {
            public const string Api = "api";
            public const string Verb = "verb";
            public const string Count = "count";
            public const string TimeTakenInMs = "time_taken_ms";
            public const string HttpStatusCode = "http_status_code";
            public const string ErrorCode = "error_code";
            public const string ProgramId = "program_id";
        }
        public static class Api
        {
            public static readonly string HealthCheck = "health_check";
            public static readonly string profiling = "profiling";
            public static readonly string HierarchyProgram = "hierarchy-program";
            public static readonly string CAPIAccessKey = "access_key";
        }

        public static class HeaderName
        {
            public static readonly string TenantId = "cnx-tenantId";
            public static readonly string ProgramId = "programId";
            public static readonly string ClientProgramGroupId = "clientProgramGroupId";
            public static readonly string ApiKey = "apiKey";
            public static readonly string SessionId = "sessionid";
            public static readonly string CorrelationId = "cnx-correlationId";
            public static readonly string IpAddress = "cnx-userip";
            public static readonly string EnvironmentToken = "cnx-environment-token";
            public const string HttpStatusCode = "httpStatusCode";
        }
        public static class Consul
        {
            public static class ApplicationSettings
            {
                public static readonly string IsProfilingEnabled = "isprofilingenabled";
                public static readonly string IsLoggingEnabled = "isloggingenabled";

            }

        }
    }
}
