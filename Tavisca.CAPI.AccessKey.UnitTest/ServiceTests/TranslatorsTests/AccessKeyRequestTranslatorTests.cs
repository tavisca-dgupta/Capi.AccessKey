using Xunit;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;
using System;
using Tavisca.CAPI.AccessKey.Services.Tanslator;
namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTests.TranslatorsTests
{
    public class AccessKeyRequestTranslatorTests
    {
        [Fact]
        public void AccessKeyRequestTranslator_Success()
        {
            var accessKeyRequest = GetAccessKeyRequest();
            var accessKeyModel = accessKeyRequest.ToAccessKeyModel();
            ValidateTranslation(accessKeyRequest, accessKeyModel);
        }

        private void ValidateTranslation(AccessKeyRequest accessKeyRequest, AccessKeyModel accessKeyModel)
        {
            Assert.Equal(accessKeyRequest.ClientClassicId, accessKeyModel.ClientClassicId);
            Assert.Equal(accessKeyRequest.ClientId, accessKeyModel.ClientId);
            Assert.Equal(accessKeyRequest.ClientName, accessKeyModel.ClientName);
            Assert.Equal(accessKeyRequest.ClientTenantId, accessKeyModel.ClientTenantId);
            Assert.Equal(accessKeyRequest.Program, accessKeyModel.Program);
            Assert.Equal(accessKeyRequest.ProgramGroup, accessKeyModel.ProgramGroup);
            Assert.Equal(accessKeyRequest.ProgramId, accessKeyModel.ProgramId);
            Assert.Equal(accessKeyRequest.UpdatedBy, accessKeyModel.UpdatedBy);
        }

        private AccessKeyRequest GetAccessKeyRequest()
        {
            return new AccessKeyRequest()
            {
                ClientClassicId="",
                ClientId="",
                ClientName="",
                ClientTenantId="",
                Program="",
                ProgramGroup="",
                ProgramId="",
                UpdatedBy=""
            };
        }
    }
}
