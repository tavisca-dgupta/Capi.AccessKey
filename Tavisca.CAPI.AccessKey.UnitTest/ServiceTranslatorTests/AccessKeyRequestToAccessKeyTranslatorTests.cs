using Xunit;
using FluentAssertions;
using System;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;
using Tavisca.CAPI.AccessKey.Services.Tanslator;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTranslatorTests
{
    public class AccessKeyRequestToAccessKeyTranslatorTests
    {
        [Fact]
        public void AccessKeyRequestToAccessKeyTranslator_Success()
        {
            var accessKeyRequest = GetAccessKeyRequest();
            var accessKeyModel = accessKeyRequest.ToAccessKeyModel();
            ValidateTranslation(accessKeyRequest,accessKeyModel);
        }

        private void ValidateTranslation(AccessKeyRequest accessKeyRequest, AccessKeyModel accessKeyModel)
        {
            Assert.Equal(accessKeyRequest.ClientId, accessKeyModel.ClientId);
            Assert.Equal(accessKeyRequest.ClientName, accessKeyModel.ClientName);
            Assert.Equal(accessKeyRequest.UpdatedBy, accessKeyModel.UpdatedBy);
        }

        private AccessKeyRequest GetAccessKeyRequest()
        {
            return new AccessKeyRequest()
            {
                ClientId="1234abcd",
                ClientName="Axis",
                Program="Green Card",
                ProgramGroup="CPG3",
                UpdatedBy="Me"
            };
        }
    }
}
