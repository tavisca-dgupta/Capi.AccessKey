using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider.Utility;
using Tavisca.CAPI.AccessKey.MockProvider.Tanslator;
using Tavisca.CAPI.AccessKey.MockProvider.Tanslators;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

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
                if (GetAllKeysDataResponseTranslator.ToAccessKeyModel(_clients[i]) != null)
                    accessKeys.Add(GetAllKeysDataResponseTranslator.ToAccessKeyModel(_clients[i]));
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
             return null;//todo write a custom exception
         }
      
         public async Task<AccessKeyModel> DeactivateKey(AccessKeyModel client)
         {
            var clients = await JsonFileReader.ReadAllJsonObject(_filename);
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].ClientId == client.ClientId)
                {
                    clients[i].IskeyActive = false;
                    break;
                }
            }
            var deactivate = await JsonFileWriter.WriteToJsonFile(clients);
            if (deactivate==true)
            {
                return await GetClientById(client.ClientId);
            }
            return null;//write custom exception
         }

        public async Task<bool> IsKeyPresent(string clientId)
        {
            List<AccessKeyModel> clients = await GetAllClients();
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].ClientId.Equals(clientId))
                    return true;
            }
            return false;
        }

        public async Task<AccessKeyModel> CreateKey(AccessKeyModel key)
        {
            var clients = await JsonFileReader.ReadAllJsonObject(_filename);
            GetAllKeysDataResponse accessKey = key.ToGetAllKeysResponseModel();
            accessKey.UpdateDate = System.DateTime.Today.ToString("dd-MM-yyyy");
            clients.Add(accessKey);
            var createStatus = await JsonFileWriter.WriteToJsonFile(clients);
            if (createStatus)
                return key;
            return null;
        }
        public async Task<AccessKeyModel> ActivateKey(AccessKeyModel client)
        {
            var clients = await JsonFileReader.ReadAllJsonObject(_filename);
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].ClientId == client.ClientId)
                {
                    clients[i].IskeyActive = true;
                    break;
                }
            }
            var activate = await JsonFileWriter.WriteToJsonFile(clients);
            if (activate == true)
            {
                return await GetClientById(client.ClientId);
            }
            return null;    //TODO: write custom exception
        }
    }
}
