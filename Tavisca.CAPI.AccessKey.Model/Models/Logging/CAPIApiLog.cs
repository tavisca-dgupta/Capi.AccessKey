using Tavisca.Platform.Common.Logging;

namespace Tavisca.CAPI.AccessKey.Model.Models.Logging
{
    public class CAPIApiLog:ApiLog
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ProgramGroup { get; set; }
        public string Program { get; set; }
        public string UpdatedBy { get; set; }

    }
}
