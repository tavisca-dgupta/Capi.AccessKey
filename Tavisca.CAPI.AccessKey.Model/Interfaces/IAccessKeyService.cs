using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Model.Interfaces
{
    public interface IAccessKeyService
    {
        Task<List<GetAllKeysResponse>> GetAllKeys();
        Task<AccessKeyResponse> CreateKey(AccessKeyRequest key);
        Task<ActivateKeyResponse> ActivateKey(ActivateKeyRequest key);
        Task<DeactivateKeyResponse> DeactivateKey(DeactivateKeyRequest key);
    }
}
