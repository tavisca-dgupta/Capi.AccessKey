using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.Model.Interfaces
{
    public interface IParameterStore
    {
        Task<bool> AddAccessKey(ParameterStoreModel parameterStore);
        Task<bool> DeleteAccessKey(string accessKey);
    }
}
