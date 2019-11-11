﻿namespace Tavisca.CAPI.AccessKey.Model.Models.DataApiModel
{
    public class AccessKeyDataRequest
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ProgramGroup { get; set; }
        public string Program { get; set; }
        public string AccessKey { get; set; }
        public bool IskeyActive { get; set; }
        public string UpdatedBy { get; set; }
        public string ClientTenantId { get; set; }
        public string ProgramId { get; set; }
        public string ClientClassicId { get; set; }
    }

}
