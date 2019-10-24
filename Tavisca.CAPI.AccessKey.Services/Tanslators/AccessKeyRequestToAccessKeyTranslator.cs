using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class AccessKeyRequestToAccessKeyTranslator
    {
        public static AccessKeyModel ToAccessKeyModel(this AccessKeyRequest key)
        {
            if (key == null)
                return null;
            return new AccessKeyModel()
            {
                ClientId = key.ClientId,
                ClientName = key.ClientName,
                UpdatedBy = key.UpdatedBy,
            };

        }
    }
}
