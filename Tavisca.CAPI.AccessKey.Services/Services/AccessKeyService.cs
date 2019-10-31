using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;
using Tavisca.CAPI.AccessKey.Services.Tanslator;

namespace Tavisca.CAPI.AccessKey.Services.Services
{
    public class AccessKeyService : IAccessKeyService
    {
        private IDatabaseAdapter _databaseAdapter;
        private IDeactivateKey _deactivateKey;
        private IActivateKey _activateKey;
        private ICreateKey _createKey;


        public AccessKeyService(IDatabaseAdapter databaseAdapter,IDeactivateKey deactivateKey,ICreateKey createKey,IActivateKey activateKey)
        {
            _databaseAdapter = databaseAdapter;
            _deactivateKey = deactivateKey;
            _createKey = createKey;
            _activateKey = activateKey;
        }

        public async Task<List<GetAllKeysResponse>> GetAllKeys()
        {
            List<GetAllKeysResponse> _keys = new List<GetAllKeysResponse>();
            List<AccessKeyModel> clientKeys = await _databaseAdapter.GetAllClients();
            for (int i = 0; i < clientKeys.Count; i++)
            {
                if (AccessKeytoGetAllResponseTranslator.ToAccesKeyDetail(clientKeys[i]) != null)
                    _keys.Add(AccessKeytoGetAllResponseTranslator.ToAccesKeyDetail(clientKeys[i]));
            }
            return _keys;
        }
        public async Task<ActivateKeyResponse> ActivateKey(ActivateKeyRequest key)
        {
            AccessKeyModel accessKey = key.ToAccessKeyModel();
            accessKey = await _activateKey.Activate(accessKey);
            return accessKey.ToActivateKeyResponse();
        }

        public async Task<AccessKeyResponse> CreateKey(AccessKeyRequest key)
        {
            AccessKeyModel accessKey = key.ToAccessKeyModel();
            accessKey = await _createKey.Create(accessKey);
            return accessKey.ToAccessKeyResponse();
        }

        public async Task<DeactivateKeyResponse> DeactivateKey(DeactivateKeyRequest key)
        {
            AccessKeyModel accessKey = key.ToAccessKeyModel();
            accessKey = await _deactivateKey.Deactivate(accessKey);
            return accessKey.ToDeactivateKeyResponse();

        }

        
    }
}
