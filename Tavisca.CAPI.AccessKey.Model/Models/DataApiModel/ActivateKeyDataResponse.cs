﻿namespace Tavisca.CAPI.AccessKey.Model.Models.DataApiModel
{
    public class ActivateKeyDataResponse
    {
        public string AccessKey { get; set; }
        public bool IskeyActive { get; set; }
        public string ClientTenantId { get; set; }
        public string UpdatedBy { get; set; }
        public string LastUpdatedOn { get; set; }
    }

}
