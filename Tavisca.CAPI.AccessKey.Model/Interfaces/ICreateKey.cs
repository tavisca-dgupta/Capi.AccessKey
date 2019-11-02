using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.Model.Interfaces
{
    public interface ICreateKey
    {
        Task<AccessKeyModel> Create(AccessKeyModel accessKey);
    }
}
