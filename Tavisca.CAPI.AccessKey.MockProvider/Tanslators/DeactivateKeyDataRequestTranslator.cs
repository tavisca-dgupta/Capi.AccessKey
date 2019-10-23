using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

namespace Tavisca.CAPI.AccessKey.MockProvider.Tanslators
{
    public static class DeactivateKeyDataRequestTranslator
    {
        public static DeactivateKeyDataRequest ToDeactivateKeyDataRequestModel(this AccessKeyModel accessKey)
        {
            if(accessKey == null)
            {
                return null;//todo replace this with custom exception
            }
            return new DeactivateKeyDataRequest()
            {
                ClientName = accessKey.ClientName,
                ClientId = accessKey.ClientId,
                AccessKey = accessKey.AccessKey,
                IskeyActive = accessKey.IskeyActive,
                UpdatedBy = accessKey.UpdatedBy,
            };
        }
    }
}
