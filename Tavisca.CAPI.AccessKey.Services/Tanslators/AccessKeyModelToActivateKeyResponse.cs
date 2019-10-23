using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class AccessKeyModelToActivateKeyResponse
    {
        public static ActivateKeyResponse ToActivateKeyResponse(this AccessKeyModel keyModel)
        {
            if(keyModel == null)
            {
                return null;
            }
            return new ActivateKeyResponse()
            {
                ClientName = keyModel.ClientName,
                AccessKey = keyModel.AccessKey,
                IskeyActive = keyModel.IskeyActive,
                UpdatedBy = keyModel.UpdatedBy
            };
        }
    }
}
