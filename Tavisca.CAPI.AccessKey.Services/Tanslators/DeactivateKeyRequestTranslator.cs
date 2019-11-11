using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class DeactivateKeyRequestTranslator
    {
        public static AccessKeyModel ToAccessKeyModel(this DeactivateKeyRequest key, string accessKey)
        {
            return key == null
                ? null
                : new AccessKeyModel()
                {
                    AccessKey = accessKey,
                    UpdatedBy = key.UpdatedBy
                };
        }
    }
}
