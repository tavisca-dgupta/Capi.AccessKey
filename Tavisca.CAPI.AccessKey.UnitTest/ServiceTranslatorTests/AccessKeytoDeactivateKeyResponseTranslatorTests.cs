using Xunit;
using FluentAssertions;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Services.Tanslator;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTranslatorTests
{
    public class AccessKeytoDeactivateKeyResponseTranslatorTests
    {
        [Fact]
        public void AccessKeytoDeactivateKeyResponseTranslator_Success()
        {
            var accessKeyModel = GetAccessKeyModel();
            var deactivateKeyResponse = accessKeyModel.ToDeactivateKeyResponse();
            ValidateTranslation(accessKeyModel,deactivateKeyResponse);
        }

        private void ValidateTranslation(AccessKeyModel accessKeyModel, DeactivateKeyResponse deactivateKeyResponse)
        {
            Assert.Equal(accessKeyModel.AccessKey, deactivateKeyResponse.AccessKey);
            Assert.Equal(accessKeyModel.ClientId, deactivateKeyResponse.ClientId);
            Assert.Equal(accessKeyModel.ClientName, deactivateKeyResponse.ClientName);
            Assert.Equal(accessKeyModel.IskeyActive, deactivateKeyResponse.IskeyActive);
            Assert.Equal(accessKeyModel.UpdatedBy, deactivateKeyResponse.UpdatedBy);
        }

        private AccessKeyModel GetAccessKeyModel()
        {
            return new AccessKeyModel()
            {
                AccessKey = "abcdefg",
                IskeyActive = true,
                ClientId = "1234567",
                ClientName = "Citi",
                Program = "Program1",
                ProgramGroup = "CPG1",
                UpdatedBy = "me"
            };
        }
    }
}
