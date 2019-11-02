using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class AccessKeyRequestToAccessKeyTranslator
    {
        public static AccessKeyModel ToAccessKeyModel(this AccessKeyRequest key)
        {
            return key == null
                ? null
                : new AccessKeyModel()
            {
                ClientId = key.ClientId,
                ClientName = key.ClientName,
                Program = key.Program,
                ProgramGroup = key.ProgramGroup,
                UpdatedBy = key.UpdatedBy,
            };
        }
    }
}
