using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.Errors;

namespace Tavisca.CAPI.AccessKey.Core.Components
{
    public class DeactivateKeyComponent: IDeactivateKey
    {
        private IDatabaseAdapter _databaseAdapter;
        private IParameterStore _parameterStore;
        public DeactivateKeyComponent(IDatabaseAdapter databaseAdapter,IParameterStore parameterStore)
        {
            _databaseAdapter = databaseAdapter;
            _parameterStore = parameterStore;
        }
        public async Task<AccessKeyModel> Deactivate(AccessKeyModel keyModel)
        {
            var clientKey = await _databaseAdapter.GetClientByAccessKey(keyModel.AccessKey);
            if(clientKey.IsKeyActive)
            {
                if (await _parameterStore.DeleteAccessKey(keyModel.AccessKey))
                    return await _databaseAdapter.DeactivateKey(keyModel);
                else
                    throw ServerSide.ParameterStoreNotResponding();
            }
            throw ClientSide.KeyIsAlreadyDeactivated();
        }
    }
}
