using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Services.Tanslator
{
    public static class AccessKeyModelToActivateKeyResponse
    {
        public static ActivateKeyResponse ToActivateKeyResponse(this AccessKeyModel keyModel)
        {
            return keyModel == null
                ? null
                : new ActivateKeyResponse()
            {
                ClientId = keyModel.ClientId,
                ClientName = keyModel.ClientName,
                AccessKey = keyModel.AccessKey,
                IskeyActive = keyModel.IskeyActive,
                UpdatedBy = keyModel.UpdatedBy
            };
        }
    }
}
