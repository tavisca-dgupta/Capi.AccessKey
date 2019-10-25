using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.CAPI.AccessKey.Model.Models
{
    public class ParameterStoreModel
    {
        public ParameterStoreModel(string accessKey, string clientId)
        {
            AccessKey = accessKey;
            ClientId = clientId;
        }
        public string AccessKey { get; set; }
        public string ClientId { get; set; }
    }
}