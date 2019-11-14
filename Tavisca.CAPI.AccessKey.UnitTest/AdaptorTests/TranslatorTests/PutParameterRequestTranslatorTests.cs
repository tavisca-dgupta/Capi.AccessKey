using System;
using System.Collections.Generic;
using System.Text;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.MockProvider.Tanslators;
using Xunit;
namespace Tavisca.CAPI.AccessKey.UnitTest.AdaptorTests.TranslatorTests
{
    public class PutParameterRequestTranslatorTests
    {
        [Fact]
        public void PutParameterRequestTranslator_Success()
        {
            var parameterStoreModel = GetParameterStoreModel();
            var putParameterRequest = parameterStoreModel.ToPutParameterRequest();
            ValidatePutParameterRequest(parameterStoreModel, putParameterRequest);
        }
        private void ValidatePutParameterRequest(ParameterStoreModel parameterStoreModel, PutParameterRequest putParameterRequest)
        {
            Assert.Equal(parameterStoreModel.Key, putParameterRequest.Name);
            Assert.Equal(parameterStoreModel.Value, putParameterRequest.Value);
            Assert.Equal(ParameterType.SecureString, putParameterRequest.Type);
            Assert.False(putParameterRequest.Overwrite);
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
