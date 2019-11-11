using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models.Common;

namespace Tavisca.CAPI.AccessKey.Web.Middleware.Extensions
{
    public class RoutingExtensions
    {
        internal static readonly List<string> RouteToSkipLogging = new List<string>
        {
            "health"
        };

        internal static (string api, string verb) GetRouteMapping(HttpRequest request)
        {
            var route = request.Path.Value;

            foreach (var callType in RouteMap)
                if (route.Contains(callType.Key))
                    return callType.Value;

            return (api: route, verb: route);
        }

        static readonly Dictionary<string, (string api, string verb)> RouteMap = new Dictionary<string, (string api, string verb)>
        {

            {"accesskey/getall", (KeyStore.Api.CAPIAccessKey, "getall")},
            {"accesskey/generatenew", (KeyStore.Api.CAPIAccessKey, "generatenew")},
            {"accesskey/activate", (KeyStore.Api.CAPIAccessKey, "activate")},
            {"accesskey/deactivate", (KeyStore.Api.CAPIAccessKey, "deactivate")},


        };
    }
}
