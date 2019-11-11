using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.Errors;

namespace Tavisca.CAPI.AccessKey.Core.Components
{
    public class ActivateKeyComponent : IActivateKey
    {
        private IDatabaseAdapter _databaseAdapter;
        private IParameterStore _parameterStore;
        public ActivateKeyComponent(IDatabaseAdapter databaseAdapter,IParameterStore parameterStore)
        {
            _databaseAdapter = databaseAdapter;
            _parameterStore = parameterStore;
        }
        public async Task<AccessKeyModel> Activate(AccessKeyModel keyModel)
        {
            var clientKey = await _databaseAdapter.GetClientByAccessKey(keyModel.AccessKey);
            if (clientKey.IskeyActive == false)
            {
                if (await _parameterStore.AddAccessKey(clientKey.AccessKey, clientKey.ClientTenantId))
                    return await _databaseAdapter.ActivateKey(keyModel);
                else
                    throw ServerSide.ParameterStoreNotResponding();
            }
            throw ClientSide.KeyIsAlreadyActivated();
        }
    }
}
