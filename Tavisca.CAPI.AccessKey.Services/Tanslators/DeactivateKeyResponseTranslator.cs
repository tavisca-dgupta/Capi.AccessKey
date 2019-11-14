using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class DeactivateKeyResponseTranslator
    {
        public static DeactivateKeyResponse ToDeactivateKeyResponse(this AccessKeyModel key)
        {
            return key == null
                ? null
                : new DeactivateKeyResponse()
            {
                AccessKey = key.AccessKey,
                IsKeyActive = key.IsKeyActive,
                UpdatedBy = key.UpdatedBy,
                LastUpdatedOn = key.LastUpdatedOn
            };
        }
    }
}
