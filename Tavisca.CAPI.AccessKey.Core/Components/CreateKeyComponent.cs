using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.Core.Components
{
    public class CreateKeyComponent : ICreateKey
    {
        private IDatabaseAdapter _databaseAdapter;

        public CreateKeyComponent(IDatabaseAdapter databaseAdapter)
        {
            _databaseAdapter = databaseAdapter;
        }

        public string GenerateAccessKey()
        {
            Guid accessKey = new Guid();
            return accessKey.ToString();
        }

        public async Task<AccessKeyModel> Create(AccessKeyModel accessKey)
        {
            if(await _databaseAdapter.IsKeyPresent(accessKey.ClientId))
            {
                accessKey.AccessKey = GenerateAccessKey();
                accessKey.IskeyActive = false;
               return await _databaseAdapter.CreateKey(accessKey);
            }
            return null;
        }
    }
}
