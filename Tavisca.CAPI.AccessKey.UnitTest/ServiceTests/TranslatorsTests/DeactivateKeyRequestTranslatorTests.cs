using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;
using Tavisca.CAPI.AccessKey.Services.Tanslator;
using Xunit;
namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTests.TranslatorsTests
{
    public class DeactivateKeyRequestTranslatorTests
    {
        [Fact]
        public void DeactivateKeyRequestTranslator_Success()
        {
            var deactivateKeyRequest = GetDeactivateKeyRequest();
            var accessKey = new Guid().ToString();
            var accessKeyModel = deactivateKeyRequest.ToAccessKeyModel(accessKey);
            ValidateTranslation(deactivateKeyRequest, accessKey, accessKeyModel);
        }

        private void ValidateTranslation(DeactivateKeyRequest deactivateKeyRequest, string accessKey, AccessKeyModel accessKeyModel)
        {
            Assert.Equal(accessKey, accessKeyModel.AccessKey);
            Assert.Equal(deactivateKeyRequest.UpdatedBy, accessKeyModel.UpdatedBy);
        }

        private DeactivateKeyRequest GetDeactivateKeyRequest()
        {
            return new DeactivateKeyRequest()
            {
                UpdatedBy = "ABcd"
            };
        }
    }
}
