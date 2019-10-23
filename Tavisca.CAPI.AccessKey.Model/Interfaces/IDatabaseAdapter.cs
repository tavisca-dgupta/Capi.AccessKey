using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.Model.Interfaces
{
    public interface IDatabaseAdapter
    {
        Task<List<AccessKeyModel>> GetAllClients();
        Task<AccessKeyModel> GetClientById(string clientId);
        Task<AccessKeyModel> DeactivateKey(AccessKeyModel client);
        //bool AddClient(CAPIClientData client);
        //bool ActivateKey(CAPIClientData client);
    }
}
