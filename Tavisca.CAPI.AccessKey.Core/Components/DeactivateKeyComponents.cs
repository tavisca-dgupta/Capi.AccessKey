using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.Core.Components
{
    public class DeactivateKeyComponents: IDeactivateKey
    {
        private IDatabaseAdapter _databaseAdapter;
        public DeactivateKeyComponents(IDatabaseAdapter databaseAdapter)
        {
            _databaseAdapter = databaseAdapter;
        }
        public async Task<AccessKeyModel> DeactivateKey(AccessKeyModel accessKey)
        {
            var clientKey = await _databaseAdapter.GetClientById(accessKey.ClientId);
            if(clientKey.IskeyActive)
            {
                return await _databaseAdapter.DeactivateKey(accessKey);
            }
            return null;//what to send if key is already activated
        }
    }
}
