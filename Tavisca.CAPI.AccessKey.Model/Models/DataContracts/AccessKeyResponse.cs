﻿namespace Tavisca.CAPI.AccessKey.Model.Models.DataContracts
{
    public class AccessKeyResponse
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string AccessKey { get; set; }
        public bool IskeyActive { get; set; }
        public string UpdatedBy { get; set; }
        public string ProgramId { get; set; }
        public string ClientClassicId { get; set; }
        public string LastUpdatedOn { get; set; }
        public string CreatedOn { get; set; }
        
    }
}
