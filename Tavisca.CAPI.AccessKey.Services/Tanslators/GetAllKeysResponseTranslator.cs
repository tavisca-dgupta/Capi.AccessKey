using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class GetAllKeysResponseTranslator
    {
        public static GetAllKeysResponse ToGetAllKeysResponse(this AccessKeyModel key)
        {
            return key == null
                ? null
                : new GetAllKeysResponse()
            {
                ClientId = key.ClientId,
                ProgramGroup = key.ProgramGroup,
                Program = key.Program,
                AccessKey = key.AccessKey,
                ClientName = key.ClientName,
                IsKeyActive = key.IsKeyActive,
                UpdatedBy = key.UpdatedBy,
                ClientClassicId = key.ClientClassicId,
                ClientTenantId = key.ClientTenantId,
                ProgramId = key.ProgramId,
                CreatedOn = key.CreatedOn,
                LastUpdatedOn = key.LastUpdatedOn
            };
        }
    }
}
