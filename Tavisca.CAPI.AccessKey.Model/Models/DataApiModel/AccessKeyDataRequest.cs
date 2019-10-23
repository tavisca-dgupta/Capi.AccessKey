using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.CAPI.AccessKey.Model.Models.DataApiModel
{
    public class AccessKeyDataRequest
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ProgramGroup { get; set; }
        public string Program { get; set; }
        public string AccessKey { get; set; }
        public bool IskeyActive { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }

}
