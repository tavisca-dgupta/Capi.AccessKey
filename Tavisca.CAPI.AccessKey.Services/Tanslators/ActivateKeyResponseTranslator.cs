using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class ActivateKeyResponseTranslator
    {
        public static ActivateKeyResponse ToActivateKeyResponse(this AccessKeyModel keyModel)
        {
            return keyModel == null
                ? null
                : new Model.Models.DataContracts.ActivateKeyResponse()
            {
                AccessKey = keyModel.AccessKey,
                IsKeyActive = keyModel.IsKeyActive,
                UpdatedBy = keyModel.UpdatedBy,
                ClientTenantId = keyModel.ClientTenantId,
                LastUpdatedOn = keyModel.LastUpdatedOn
            };
        }
    }
}
