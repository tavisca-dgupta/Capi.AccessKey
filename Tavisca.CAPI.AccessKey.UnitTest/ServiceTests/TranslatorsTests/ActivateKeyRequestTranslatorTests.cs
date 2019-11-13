using System;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;
using Tavisca.CAPI.AccessKey.Services.Tanslator;
using Xunit;
namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTests.TranslatorsTests
{
    public class ActivateKeyRequestTranslatorTests
    {
        [Fact]
        public void ActivateKeyRequestTranslator_Success()
        {
            var activateKeyRequest = GetActivateKeyRequest();
            var accessKey = new Guid().ToString();
            var accessKeyModel = activateKeyRequest.ToAccessKeyModel(accessKey);
            ValidateTranslation(activateKeyRequest,accessKey,accessKeyModel);
        }

        private void ValidateTranslation(ActivateKeyRequest activateKeyRequest, string accessKey, AccessKeyModel accessKeyModel)
        {
            Assert.Equal(activateKeyRequest.UpdatedBy, accessKeyModel.UpdatedBy);
            Assert.Equal(accessKey, accessKeyModel.AccessKey);
        }

        private ActivateKeyRequest GetActivateKeyRequest()
        {
            return new ActivateKeyRequest()
            {
                UpdatedBy="Abcd"
            };
        }
    }
}
