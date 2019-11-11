﻿using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

namespace Tavisca.CAPI.AccessKey.MockProvider.Tanslators
{
    public static class ActivateKeyDataResponseTranslator
    {
        public static AccessKeyModel ToAccessKeyModel(this ActivateKeyDataResponse keyDataResponse)
        {
            return keyDataResponse == null
                ? null
                : new AccessKeyModel()
                {
                    AccessKey = keyDataResponse.AccessKey,
                    IskeyActive = keyDataResponse.IskeyActive,
                    UpdatedBy = keyDataResponse.UpdatedBy,
                    ClientTenantId = keyDataResponse.ClientTenantId,
                    LastUpdatedOn = keyDataResponse.LastUpdatedOn
                };
        }
    }
}
