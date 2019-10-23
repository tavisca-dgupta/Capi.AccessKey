using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class DeactivateKeyRequestTranslator
    {
        public static AccessKeyModel ToAccessKeyModel(this DeactivateKeyRequest key)
        {
            if (key == null)
                return null;
            return new AccessKeyModel()
            {
                ClientId = key.ClientId,
                AccessKey = key.AccessKey,
                ClientName = key.ClientName,
                IskeyActive = key.IskeyActive,
                UpdatedBy = key.UpdatedBy,
            };
        }
    }
}
