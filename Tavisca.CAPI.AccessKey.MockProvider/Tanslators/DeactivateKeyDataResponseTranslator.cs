using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

namespace Tavisca.CAPI.AccessKey.MockProvider.Tanslators
{
    public static class DeactivateKeyDataResponseTranslator
    {
        public static AccessKeyModel ToAccessKeyModel(this DeactivateKeyDataResponse client)
        {
            if(client==null)
            {
                return null;//todo write custom exception
            }
            return new AccessKeyModel()
            {
                ClientId = client.ClientId,
                ClientName = client.ClientName,
                AccessKey = client.AccessKey,
                IskeyActive = client.IskeyActive,
                Program = client.Program,
                ProgramGroup = client.Program,
                UpdatedBy = client.UpdatedBy

            };
        }
    }
}
