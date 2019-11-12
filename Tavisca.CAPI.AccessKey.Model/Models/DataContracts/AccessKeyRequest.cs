﻿namespace Tavisca.CAPI.AccessKey.Model.Models.DataContracts
{
    public class AccessKeyRequest
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ProgramGroup { get; set; }
        public string Program { get; set; }
        public string UpdatedBy { get; set; }
        public string ClientTenantId { get; set; }
        public string ProgramId { get; set; }
        public string ClientClassicId { get; set; }
    }
}
