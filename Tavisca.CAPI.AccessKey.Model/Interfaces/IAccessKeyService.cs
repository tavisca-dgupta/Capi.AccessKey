using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Model.Interfaces
{
    public interface IAccessKeyService
    {
        Task<List<GetAllKeysResponse>> GetAllKeys();
        bool CreateKey();
        Task<ActivateKeyResponse> ActivateKey(ActivateKeyRequest key);
        Task<DeactivateKeyResponse> DeactivateKey(DeactivateKeyRequest key);
    }
}
