using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Amazon.SimpleSystemsManagement.Model;
namespace Tavisca.CAPI.AccessKey.MockProvider.Tanslators
{
    public static class DeleteParameterRequestTranslator
    {
        public static DeleteParameterRequest ToDeleteParameterRequest(this ParameterStoreModel parameterStoreModel)
        {
            if (parameterStoreModel == null)
                return null;

            return new DeleteParameterRequest()
            {
                Name = parameterStoreModel.Key
            };
        }
    }
}
