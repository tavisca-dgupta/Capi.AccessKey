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

        public AccessKeyService(IDatabaseAdapter databaseAdapter,IDeactivateKey deactivateKey)
        {
            _databaseAdapter = databaseAdapter;
            _deactivateKey = deactivateKey;
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
            accessKey = await _activateKey.ActivateKey(accessKey);
            return accessKey.ToActivateKeyResponse();
        }

        public bool CreateKey()
        {
            throw new NotImplementedException();
        }

        public async Task<DeactivateKeyResponse> DeactivateKey(DeactivateKeyRequest key)
        {
            AccessKeyModel accessKey = key.ToAccessKeyModel();
            accessKey = await _deactivateKey.DeactivateKey(accessKey);
            return accessKey.ToDeactivateKeyResponse();

        }

        
    }
}
