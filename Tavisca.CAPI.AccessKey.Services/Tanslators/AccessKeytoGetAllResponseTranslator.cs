using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class AccessKeytoGetAllResponseTranslator
    {
        public static GetAllKeysResponse ToAccesKeyDetail(this AccessKeyModel key)
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
                IskeyActive = key.IskeyActive,
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
