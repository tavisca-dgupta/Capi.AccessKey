using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.Core.Components
{
    public class ActivateKeyComponents : IActivateKey
    {
        private IDatabaseAdapter _databaseAdapter;
        public ActivateKeyComponents(IDatabaseAdapter databaseAdapter)
        {
            _databaseAdapter = databaseAdapter;
        }
        public async Task<AccessKeyModel> ActivateKey(AccessKeyModel accessKey)
        {
            var clientKey = await _databaseAdapter.GetClientById(accessKey.ClientId);
            if (clientKey.IskeyActive == false)
            {
                return await _databaseAdapter.ActivateKey(accessKey);
            }
            return null;//what to send if key is already activated
        }
    }
}
