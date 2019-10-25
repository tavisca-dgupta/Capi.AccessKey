using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Tavisca.CAPI.AccessKey.MockProvider.ParameterStoreProvider.Utility;
using Tavisca.CAPI.AccessKey.Model.Models;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;

namespace Tavisca.CAPI.AccessKey.MockProvider.ParameterStoreProvider
{
    public class MockParameterStore : IParameterStore
    {
        public async Task<bool> AddAccessKey(ParameterStoreModel parameterStore)
        {
            if (parameterStore.AccessKey != null && parameterStore.ClientId != null)
            {
                return await ParameterStore.AddKey(parameterStore);
            }
            else
            {
                Console.WriteLine("Field empty");
                return false;
            }
        }
        public async Task<bool> DeleteAccessKey(string accessKey)
        {
            if (accessKey != null)
            {
                return await ParameterStore.DeleteKey(accessKey);
            }
            else
            {
                Console.WriteLine("Access Key cannot be empty");
                return false;
            }
        }
    }
}