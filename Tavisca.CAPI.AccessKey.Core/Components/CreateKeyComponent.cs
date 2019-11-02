using System;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.Errors;

namespace Tavisca.CAPI.AccessKey.Core.Components
{
    public class CreateKeyComponent : ICreateKey
    {
        private IDatabaseAdapter _databaseAdapter;

        public CreateKeyComponent(IDatabaseAdapter databaseAdapter)
        {
            _databaseAdapter = databaseAdapter;
        }

        private string GenerateAccessKey()
        {
            Guid accessKey = Guid.NewGuid();
            return accessKey.ToString();
        }

        public async Task<AccessKeyModel> Create(AccessKeyModel accessKey)
        {
            if(!(await _databaseAdapter.IsKeyPresent(accessKey.ClientId)))
            {
                accessKey.AccessKey = GenerateAccessKey();
                accessKey.IskeyActive = false;
                return await _databaseAdapter.CreateKey(accessKey);
            }
            throw ClientSide.KeyAlreadyExists();
        }
    }
}
