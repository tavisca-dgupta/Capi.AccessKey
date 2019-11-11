using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

namespace Tavisca.CAPI.AccessKey.MockProvider.Tanslators
{
    public static class AccessKeyToGetAllKeysResponseTranslator
    {
        public static GetAllKeysDataResponse ToGetAllKeysResponseModel(this AccessKeyModel key)
        {
            return key == null
                ? null
                : new GetAllKeysDataResponse()
                {
                    ClientId = key.ClientId,
                    ClientName = key.ClientName,
                    Program = key.Program,
                    ProgramGroup = key.ProgramGroup,
                    AccessKey = key.AccessKey,
                    IskeyActive = key.IskeyActive,
                    UpdatedBy = key.UpdatedBy,
                    ClientTenantId = key.ClientTenantId,
                    ClientClassicId = key.ClientClassicId,
                    ProgramId = key.ProgramId,
                    CreatedOn = key.CreatedOn,
                    LastUpdatedOn = key.LastUpdatedOn
                };
        }
    }
}

