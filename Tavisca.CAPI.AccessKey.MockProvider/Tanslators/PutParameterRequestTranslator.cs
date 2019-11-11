using System;
using System.Collections.Generic;
using System.Text;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Tavisca.CAPI.AccessKey.Model.Models;
namespace Tavisca.CAPI.AccessKey.MockProvider.Tanslators
{
    public static class PutParameterRequestTranslator
    {
        public static PutParameterRequest ToPutParameterRequest(this ParameterStoreModel parameterStoreModel)
        {
            if (parameterStoreModel == null)
                return null;
            return new PutParameterRequest()
            {
                Name = parameterStoreModel.Key,
                Value = parameterStoreModel.Value,
                Type = ParameterType.SecureString,
                Overwrite = false
            };
        }
    }
}
