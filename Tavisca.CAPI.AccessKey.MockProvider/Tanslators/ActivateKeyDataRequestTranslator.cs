using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

namespace Tavisca.CAPI.AccessKey.MockProvider.Tanslators
{
    public static class ActivateKeyDataRequestTranslator
    {
        public static ActivateKeyDataRequest ToActivateKeyDataRequest(this AccessKeyModel accessKey)
        {
            return accessKey == null
                ? null
                : new ActivateKeyDataRequest()
                {
                    UpdatedBy = accessKey.UpdatedBy,
                };
        }
    }
}
