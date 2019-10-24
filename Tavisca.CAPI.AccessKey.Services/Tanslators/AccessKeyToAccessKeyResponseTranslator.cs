using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class AccessKeyToAccessKeyResponseTranslator
    {
        public static AccessKeyResponse ToAccessKeyResponse(this AccessKeyModel key)
        {
            if (key == null)
                return null;
            return new AccessKeyResponse()
            {
                ClientName = key.ClientName,
                AccessKey = key.AccessKey,
                IskeyActive = key.IskeyActive,
                UpdatedBy = key.UpdatedBy
            };

        }
    }
}
