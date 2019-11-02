using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.Model.Interfaces
{
    public interface IAccessKeyComponent
    {
        Task<List<AccessKeyModel>> GetAll();
    }
}
