using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

namespace Tavisca.CAPI.AccessKey.MockProvider.Tanslators
{
    public static class ActivateKeyDataRequestTranslator
    {
        public static ActivateKeyDataRequest ToActivateKeyDataRequest(this AccessKeyModel accessKey)
        {
            if (accessKey == null)
                return null;    //TODO: Write custom exception
            return new ActivateKeyDataRequest()
            {
                ClientName = accessKey.ClientName,
                AccessKey = accessKey.AccessKey,
                IskeyActive = accessKey.IskeyActive,
                UpdatedBy = accessKey.UpdatedBy,
                UpdateDate = System.DateTime.Today.ToString("dd-MM-yyyy")
        };
        }
    }
}
