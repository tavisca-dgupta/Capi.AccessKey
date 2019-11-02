using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class AccessKeytoDeactivateKeyResponseTranslator
    {
        public static DeactivateKeyResponse ToDeactivateKeyResponse(this AccessKeyModel key)
        {
            return key == null
                ? null
                : new DeactivateKeyResponse()
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
