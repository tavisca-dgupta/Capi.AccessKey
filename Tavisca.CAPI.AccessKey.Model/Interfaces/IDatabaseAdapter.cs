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
        Task<AccessKeyModel> ActivateKey(AccessKeyModel accessKey);
        Task<AccessKeyModel> CreateKey(AccessKeyModel key);
        Task<bool> IsKeyPresent(string clientId);
    }
}
