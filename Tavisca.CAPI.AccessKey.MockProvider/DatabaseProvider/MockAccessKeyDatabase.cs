using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider.Utility;
using Tavisca.CAPI.AccessKey.MockProvider.Tanslator;
using Tavisca.CAPI.AccessKey.MockProvider.Tanslators;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;
using Tavisca.CAPI.AccessKey.Model.Models.Errors;

namespace Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider
{
    public class MockAccessKeyDatabase: IDatabaseAdapter
    {
        private static readonly string _filename = "MockAccessKeyData.json";
        public async Task<List<AccessKeyModel>> GetAllClients()
        {
            List<GetAllKeysDataResponse> _clients = new List<GetAllKeysDataResponse>();
            _clients = await JsonFileReader.ReadAllJsonObject(_filename);
            List<AccessKeyModel> accessKeys = new List<AccessKeyModel>();
            for(int i=0;i<_clients.Count;i++)
            {
                if (_clients[i].ToAccessKeyModel() != null)
                    accessKeys.Add(_clients[i].ToAccessKeyModel());
            }
            return accessKeys;
        }

        public async Task<AccessKeyModel> GetClientById(string clientId)
         {
             List<AccessKeyModel> clients = await GetAllClients();
             for (int i = 0; i < clients.Count; i++)
             {
                 if (clients[i].ClientId.Equals(clientId))
                     return clients[i];
             }
            throw ClientSide.ClientNotFound();
         }
      
         public async Task<AccessKeyModel> DeactivateKey(AccessKeyModel client)
         {
            var clients = await JsonFileReader.ReadAllJsonObject(_filename);
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].AccessKey == client.AccessKey)
                {
                    clients[i].IsKeyActive = false;
                    clients[i].UpdatedBy = client.UpdatedBy;
                    break;
                }
            }
            var deactivate = await JsonFileWriter.WriteToJsonFile(clients);
            if (deactivate==true)
            {
                return await GetClientByAccessKey(client.AccessKey);
            }
            throw ServerSide.AccessKeyNotDeactivated();
         }

        public async Task<bool> IsKeyPresent(string accessKey)
        {
            List<AccessKeyModel> clients = await GetAllClients();
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].AccessKey.Equals(accessKey))
                    return true;
            }
            return false;
        }

        public async Task<AccessKeyModel> CreateKey(AccessKeyModel key)
        {
            var clients = await JsonFileReader.ReadAllJsonObject(_filename);
            GetAllKeysDataResponse accessKey = key.ToGetAllKeysResponseModel();
            clients.Add(accessKey);
            var createStatus = await JsonFileWriter.WriteToJsonFile(clients);
            if (createStatus)
                return key;
            throw ServerSide.AccessKeyNotGenerated();
            
        }
        public async Task<AccessKeyModel> ActivateKey(AccessKeyModel client)
        {
            var clients = await JsonFileReader.ReadAllJsonObject(_filename);
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].AccessKey == client.AccessKey)
                {
                    clients[i].IsKeyActive = true;
                    clients[i].UpdatedBy = client.UpdatedBy;
                    break;
                }
            }
            var activate = await JsonFileWriter.WriteToJsonFile(clients);
            if (activate == true)
            {
                return await GetClientByAccessKey(client.AccessKey);
            }
            throw ServerSide.AccesskeyNotActivated();
        }

        public async Task<AccessKeyModel> GetClientByAccessKey(string accessKey)
        {
            List<AccessKeyModel> clients = await GetAllClients();
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].AccessKey.Equals(accessKey))
                    return clients[i];
            }
            throw ClientSide.ClientNotFound();
        }
    }
}
