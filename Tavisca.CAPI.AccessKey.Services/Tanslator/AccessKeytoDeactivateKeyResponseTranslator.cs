using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class AccessKeytoDeactivateKeyResponseTranslator
    {
        public static DeactivateKeyResponse ToDeactivateKeyResponse(this AccessKeyModel key)
        {
            if (key == null)
                return null;
            return new DeactivateKeyResponse()
            {
                AccessKey = key.AccessKey,
                ClientId = key.ClientId,
                ClientName = key.ClientName,
                IskeyActive = key.IskeyActive,
                UpdatedBy = key.UpdatedBy,
            };
        }
    }
}
