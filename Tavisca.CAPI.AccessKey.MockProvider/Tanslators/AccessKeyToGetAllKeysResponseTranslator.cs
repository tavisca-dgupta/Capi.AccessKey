using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

namespace Tavisca.CAPI.AccessKey.MockProvider.Tanslators
{
    public static class AccessKeyToGetAllKeysResponseTranslator
    {
        public static GetAllKeysDataResponse ToGetAllKeysResponseModel(this AccessKeyModel key)
        {
            if (key == null)
                return null;
            return new GetAllKeysDataResponse()
            {
                ClientId = key.ClientId,
                ClientName = key.ClientName,
                ProgramGroup = key.ProgramGroup,
                Program = key.Program,
                AccessKey = key.AccessKey,
                IskeyActive = key.IskeyActive,
                UpdatedBy = key.UpdatedBy
            };
        }
    }
}

