using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

namespace Tavisca.CAPI.AccessKey.MockProvider.Tanslator
{
    public static class GetAllKeysDataResponseTranslator
    {
        public static AccessKeyModel ToAccessKeyModel(this GetAllKeysDataResponse client)
        {
            return client == null
                ? null
                : new AccessKeyModel()
            {
                ClientId = client.ClientId,
                ProgramGroup = client.ProgramGroup,
                Program = client.Program,
                UpdatedBy = client.UpdatedBy,
                AccessKey = client.AccessKey,
                ClientName = client.ClientName,
                IsKeyActive = client.IsKeyActive,
                ClientTenantId = client.ClientTenantId,
                ClientClassicId = client.ClientClassicId,
                ProgramId = client.ProgramId,
                CreatedOn = client.CreatedOn,
                LastUpdatedOn = client.LastUpdatedOn
            };
        }
    }
}
