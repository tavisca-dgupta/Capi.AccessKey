using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.Core.Components
{
    public class AccessKeyComponent:IAccessKeyComponent
    {
        private IDatabaseAdapter _databaseAdapter;

        public AccessKeyComponent(IDatabaseAdapter databaseAdapter)
        {
            _databaseAdapter = databaseAdapter;
        }

        public async Task<List<AccessKeyModel>> GetAll()
        {
            return await _databaseAdapter.GetAllClients();
        }
    }
}
