using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Tavisca.CAPI.AccessKey.Model.Models;
using Amazon.SimpleSystemsManagement.Model;
using Tavisca.CAPI.AccessKey.MockProvider.Tanslators;
namespace Tavisca.CAPI.AccessKey.UnitTest.AdaptorTests.TranslatorTests
{
    public class DeleteParameterRequestTranslatorTests
    {
        [Fact]
        public void DeleteParameterRequestTranslator_Success()
        {
            var parameterStoreModel = GetParameterStoreModel();
            var deleteParameterRequest = parameterStoreModel.ToDeleteParameterRequest();
            ValidateDeleteParameterRequest(parameterStoreModel, deleteParameterRequest);
        }

        private void ValidateDeleteParameterRequest(ParameterStoreModel parameterStoreModel, DeleteParameterRequest deleteParameterRequest)
        {
            Assert.Equal(parameterStoreModel.Key, deleteParameterRequest.Name);
        }

        private ParameterStoreModel GetParameterStoreModel()
        {
            return new ParameterStoreModel()
            {
                Key = "abcd",
                Value = "1234"
            };
        }
    }
}
