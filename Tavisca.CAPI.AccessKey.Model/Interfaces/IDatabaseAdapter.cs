using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.Model.Interfaces
{
    public interface IDatabaseAdapter
    {
        Task<List<AccessKeyModel>> GetAllClients();
        Task<AccessKeyModel> GetClientById(string clientId);
        Task<AccessKeyModel> GetClientByAccessKey(string accessKey);
        Task<AccessKeyModel> DeactivateKey(AccessKeyModel client);
        Task<AccessKeyModel> ActivateKey(AccessKeyModel accessKey);
        Task<AccessKeyModel> CreateKey(AccessKeyModel key);
        //clientId to be modified into programId
        Task<bool> IsKeyPresent(string clientId);
    }
}
