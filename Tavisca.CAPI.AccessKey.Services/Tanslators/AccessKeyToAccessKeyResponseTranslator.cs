using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class AccessKeyToAccessKeyResponseTranslator
    {
        public static AccessKeyResponse ToAccessKeyResponse(this AccessKeyModel key)
        {
            return key == null
                ? null
                : new AccessKeyResponse()
            {
                ClientId = key.ClientId,
                ClientName = key.ClientName,
                AccessKey = key.AccessKey,
                IskeyActive = key.IskeyActive,
                UpdatedBy = key.UpdatedBy,
                ProgramGroup = key.ProgramGroup,
                Program = key.Program,
                ProgramId = key.ProgramId,
                ClientClassicId = key.ClientClassicId,
                LastUpdatedOn = key.LastUpdatedOn,
                CreatedOn = key.CreatedOn
            };
        }
    }
}
