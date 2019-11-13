using System;
using System.Collections.Generic;
using System.Text;
using Amazon.SimpleSystemsManagement.Model;
using System.Threading.Tasks;

namespace Tavisca.CAPI.AccessKey.Model.Interfaces
{
    public interface IParameterStoreProvider
    {
        Task<PutParameterResponse> PutParameter(PutParameterRequest request);
        Task<DeleteParameterResponse> DeleteParameter(DeleteParameterRequest request);
    }
}
