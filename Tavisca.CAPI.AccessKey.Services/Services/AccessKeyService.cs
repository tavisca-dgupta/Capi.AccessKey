﻿using System;
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
        private IDeactivateKey _deactivateKey;
        private IActivateKey _activateKey;
        private ICreateKey _createKey;
        private IAccessKeyComponent _accessKey;
        public AccessKeyService(IDeactivateKey deactivateKey,ICreateKey createKey,IActivateKey activateKey,IAccessKeyComponent accessKey)
        {
            _accessKey = accessKey;
            _deactivateKey = deactivateKey;
            _createKey = createKey;
            _activateKey = activateKey;
        }

        public async Task<List<GetAllKeysResponse>> GetAllKeys()
        {
            List<GetAllKeysResponse> _keys = new List<GetAllKeysResponse>();
            List<AccessKeyModel> clientKeys = await _accessKey.GetAll();
            for (int i = 0; i < clientKeys.Count; i++)
            {
                if (GetAllKeysResponseTranslator.ToGetAllKeysResponse(clientKeys[i]) != null)
                    _keys.Add(GetAllKeysResponseTranslator.ToGetAllKeysResponse(clientKeys[i]));
            }
            return _keys;
        }
        public async Task<ActivateKeyResponse> ActivateKey(ActivateKeyRequest key, string accessKey)
        {
            AccessKeyModel accessKeyModel = key.ToAccessKeyModel(accessKey);
            accessKeyModel = await _activateKey.Activate(accessKeyModel);
            return accessKeyModel.ToActivateKeyResponse();
        }

        public async Task<AccessKeyResponse> CreateKey(AccessKeyRequest key)
        {
            AccessKeyModel accessKey = key.ToAccessKeyModel();
            accessKey = await _createKey.Create(accessKey);
            return accessKey.ToAccessKeyResponse();
        }

        public async Task<DeactivateKeyResponse> DeactivateKey(DeactivateKeyRequest key, string accessKey)
        {
            AccessKeyModel accessKeyModel = key.ToAccessKeyModel(accessKey);
            accessKeyModel = await _deactivateKey.Deactivate(accessKeyModel);
            return accessKeyModel.ToDeactivateKeyResponse();
        }        
    }
}
