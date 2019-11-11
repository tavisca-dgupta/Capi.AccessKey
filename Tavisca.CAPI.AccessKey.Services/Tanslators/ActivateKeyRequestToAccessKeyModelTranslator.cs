using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class ActivateKeyRequestToAccessKeyModelTranslator
    {
        public static AccessKeyModel ToAccessKeyModel(this ActivateKeyRequest keyRequest)
        {
            return keyRequest == null
                ? null
                : new AccessKeyModel()
            {
                UpdatedBy = keyRequest.UpdatedBy
            };
        }
    }
}
