using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Tavisca.CAPI.AccessKey.MockProvider.ParameterStore.Utility;
using Tavisca.CAPI.AccessKey.Model.Models;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Amazon.SimpleSystemsManagement.Model;
using Tavisca.CAPI.AccessKey.MockProvider.Tanslators;
using Tavisca.CAPI.AccessKey.Model.Models.Errors;

namespace Tavisca.CAPI.AccessKey.MockProvider.ParameterStore
{
    public class ParameterStore : IParameterStore
    {
        IParameterStoreProvider _parameterStoreProvider;
        public ParameterStore(IParameterStoreProvider parameterStoreProvider)
        {
            _parameterStoreProvider = parameterStoreProvider;
        }

        public async Task<bool> AddKey(ParameterStoreModel keyValueModel)
        {
            var putParameterRequest = keyValueModel.ToPutParameterRequest();
            try
            {
                var putParameterResponse = await _parameterStoreProvider.PutParameter(putParameterRequest);
                    return true;
            }
            catch
            {
                throw ServerSide.ParameterStoreAdditionFailed();
            }
        }

        public async Task<bool> DeleteKey(ParameterStoreModel keyValueModel)
        {
            var deleteParameterRequest = keyValueModel.ToDeleteParameterRequest();
            try
            {
                var deleteParameterResponse = await _parameterStoreProvider.DeleteParameter(deleteParameterRequest);
                    return true;
            }
            catch
            {
                throw ServerSide.ParameterStoreDeletionFailed();
            }
        }
    }
}