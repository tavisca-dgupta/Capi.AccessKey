using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Amazon.SimpleSystemsManagement.Model;
using Amazon.SimpleSystemsManagement;
using Amazon;
using System.Threading.Tasks;
using Tavisca.Platform.Common.ConfigurationHandler;
using Tavisca.CAPI.AccessKey.Model.Models.Errors;
namespace Tavisca.CAPI.AccessKey.MockProvider.ParameterStore.Utility
{
    public class ParameterStoreProvider : IParameterStoreProvider
    {
        private AmazonSimpleSystemsManagementClient _client;
        public async Task<PutParameterResponse> PutParameter(PutParameterRequest request)
        {
            if (_client == null)
                _client = GetClient();
            return await _client.PutParameterAsync(request);
        }

        public async Task<DeleteParameterResponse> DeleteParameter(DeleteParameterRequest request)
        {
            if (_client == null)
                _client = GetClient();
            return await _client.DeleteParameterAsync(request);
        }

        private AmazonSimpleSystemsManagementClient GetClient()
        {
            try
            {
                var region = ConfigurationManager.GetAppSetting("ParameterStore.Region");
                var regionEndpoint = string.IsNullOrWhiteSpace(region) ? RegionEndpoint.USEast1 : RegionEndpoint.GetBySystemName(region);
                return new AmazonSimpleSystemsManagementClient(regionEndpoint);
            }
            catch
            {
                throw ServerSide.ParameterStoreCommunicationError();
            }
        }
    }
}
