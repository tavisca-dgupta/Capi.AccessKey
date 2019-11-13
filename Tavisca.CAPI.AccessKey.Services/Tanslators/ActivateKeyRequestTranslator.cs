using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class ActivateKeyRequestTranslator
    {
        public static AccessKeyModel ToAccessKeyModel(this ActivateKeyRequest keyRequest, string accessKey)
        {
            return keyRequest == null
                ? null
                : new AccessKeyModel()
                {
                    AccessKey = accessKey,
                    UpdatedBy = keyRequest.UpdatedBy
                };
        }
    }
}
