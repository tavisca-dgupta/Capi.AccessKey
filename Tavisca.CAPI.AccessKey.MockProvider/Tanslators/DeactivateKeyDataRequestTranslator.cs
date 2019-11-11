using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

namespace Tavisca.CAPI.AccessKey.MockProvider.Tanslators
{
    public static class DeactivateKeyDataRequestTranslator
    {
        public static DeactivateKeyDataRequest ToDeactivateKeyDataRequestModel(this AccessKeyModel accessKey)
        {
            return accessKey == null
                ? null
                : new DeactivateKeyDataRequest()
                {
                    UpdatedBy = accessKey.UpdatedBy
                };
        }
    }
}
