using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.Model.Interfaces
{
    public interface IParameterStore
    {
        Task<bool> AddKey(ParameterStoreModel parameterStoreModel);
        Task<bool> DeleteKey(ParameterStoreModel parameterStoreModel);
    }
}
