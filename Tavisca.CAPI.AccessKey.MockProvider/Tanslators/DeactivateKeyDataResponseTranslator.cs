using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

namespace Tavisca.CAPI.AccessKey.MockProvider.Tanslators
{
    public static class DeactivateKeyDataResponseTranslator
    {
        public static AccessKeyModel ToAccessKeyModel(this DeactivateKeyDataResponse client)
        {
            return client == null
                ? null
                : new AccessKeyModel()
                {
                    AccessKey = client.AccessKey,
                    IsKeyActive = client.IsKeyActive,
                    UpdatedBy = client.UpdatedBy,
                    LastUpdatedOn = client.LastUpdatedOn
                };
        }
    }
}
