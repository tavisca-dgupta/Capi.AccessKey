using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.Errors;

namespace Tavisca.CAPI.AccessKey.Core.Components
{
    public class ActivateKeyComponent : IActivateKey
    {
        private IDatabaseAdapter _databaseAdapter;
        public ActivateKeyComponent(IDatabaseAdapter databaseAdapter)
        {
            _databaseAdapter = databaseAdapter;
        }
        public async Task<AccessKeyModel> Activate(AccessKeyModel accessKey)
        {
            var clientKey = await _databaseAdapter.GetClientById(accessKey.ClientId);
            if (clientKey.IskeyActive == false)
            {
                return await _databaseAdapter.ActivateKey(accessKey);
            }
            throw ClientSide.KeyIsAlreadyActivated();
        }
    }
}
