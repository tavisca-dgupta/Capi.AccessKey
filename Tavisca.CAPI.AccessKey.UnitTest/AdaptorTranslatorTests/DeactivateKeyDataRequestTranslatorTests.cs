using Tavisca.CAPI.AccessKey.MockProvider.Tanslators;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;
using Xunit;

namespace Tavisca.CAPI.AccessKey.UnitTest.AdaptorTranslatorTests
{
    public class DeactivateKeyDataRequestTranslatorTests
    {
        [Fact]
        public void DeactivateKeyDataRequestTranslator_Success()
        {
            var accessKeyModel = GetAccessKeyModel();
            var deactivateKeyDataRequest = accessKeyModel.ToDeactivateKeyDataRequestModel();
            ValidateTranslation(accessKeyModel,deactivateKeyDataRequest);
        }

        private void ValidateTranslation(AccessKeyModel accessKeyModel, DeactivateKeyDataRequest deactivateKeyDataRequest)
        {
            Assert.Equal(accessKeyModel.ClientName, deactivateKeyDataRequest.ClientName);
            Assert.Equal(accessKeyModel.ClientId,deactivateKeyDataRequest.ClientId);
            Assert.Equal(accessKeyModel.AccessKey,deactivateKeyDataRequest.AccessKey);
            Assert.Equal(accessKeyModel.IskeyActive,deactivateKeyDataRequest.IskeyActive);
            Assert.Equal(accessKeyModel.UpdatedBy,deactivateKeyDataRequest.UpdatedBy);
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
