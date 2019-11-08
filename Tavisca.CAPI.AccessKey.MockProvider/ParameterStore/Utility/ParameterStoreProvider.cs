using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Amazon.SimpleSystemsManagement.Model;
using Amazon.SimpleSystemsManagement;
using Amazon;
using System.Threading.Tasks;
namespace Tavisca.CAPI.AccessKey.MockProvider.ParameterStore.Utility
{
    public class ParameterStoreProvider : IParameterStoreProvider
    {
        private AmazonSimpleSystemsManagementClient _client;
        public ParameterStoreProvider()
        {
            //system name will be accodring to region of deployment
            var systemName = "us-east-1";
            var regionEndpoint = RegionEndpoint.GetBySystemName(systemName);
            _client = new AmazonSimpleSystemsManagementClient(regionEndpoint);
        }
        public async Task<PutParameterResponse> PutParameter(PutParameterRequest request)
        {
            return await _client.PutParameterAsync(request);
        }
        public async Task<DeleteParameterResponse> DeleteParameter(DeleteParameterRequest request)
        {
            return await _client.DeleteParameterAsync(request);
        }
    }
}
