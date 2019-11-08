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

namespace Tavisca.CAPI.AccessKey.MockProvider.ParameterStore
{
    public class ParameterStore : IParameterStore
    {
        IParameterStoreProvider _parameterStoreProvider;
        public ParameterStore(IParameterStoreProvider parameterStoreProvider)
        {
            _parameterStoreProvider = parameterStoreProvider;
        }



        public Task<bool> AddKey(ParameterStoreModel keyValueModel)
        {
            var putParameterRequest = keyValueModel.ToPutParameterRequest();
            try
            {
                var putParameterResponse = _parameterStoreProvider.PutParameter(putParameterRequest);
                if (CheckPutParameterResponse(putParameterResponse))
                    return Task.FromResult(true);
            }
            catch
            {
            }
            return Task.FromResult(false);
        }
        //Todo
        private bool CheckPutParameterResponse(Task<PutParameterResponse> putParameterResponse)
        {
            throw new NotImplementedException();
        }



        public Task<bool> DeleteKey(ParameterStoreModel keyValueModel)
        {
            var deleteParameterRequest = keyValueModel.ToDeleteParameterRequest();
            try
            {
                var deleteParameterResponse = _parameterStoreProvider.DeleteParameter(deleteParameterRequest);
                if (CheckDeleteParameterResponse(deleteParameterResponse))
                    return Task.FromResult(true);
            }
            catch
            {
            }
            return Task.FromResult(false);
        }
        //Todo
        private bool CheckDeleteParameterResponse(Task<DeleteParameterResponse> deleteParameterResponse)
        {
            throw new NotImplementedException();
        }
    }
}