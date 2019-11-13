using Tavisca.CAPI.AccessKey.MockProvider.Tanslators;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;
using Xunit;

namespace Tavisca.CAPI.AccessKey.UnitTest.AdaptorTranslatorTests
{
    public class AccessKeyToGetAllKeysResponseTranslatorTests
    {
        [Fact]
        public void AccessKeyToGetAllKeysResponseTranslator_Success()
        {
            var accessKeyModel = GetAccessKeyModel();
            var getAllKeysDataResponse = accessKeyModel.ToGetAllKeysResponseModel();
            ValidateTranslation(accessKeyModel,getAllKeysDataResponse);
        }

        private void ValidateTranslation(AccessKeyModel accessKeyModel, GetAllKeysDataResponse getAllKeysDataResponse)
        {
            Assert.Equal(accessKeyModel.ClientId, getAllKeysDataResponse.ClientId);
            Assert.Equal(accessKeyModel.ClientName, getAllKeysDataResponse.ClientName);
            Assert.Equal(accessKeyModel.ProgramGroup, getAllKeysDataResponse.ProgramGroup);
            Assert.Equal(accessKeyModel.Program, getAllKeysDataResponse.Program);
            Assert.Equal(accessKeyModel.IsKeyActive, getAllKeysDataResponse.IsKeyActive);
            Assert.Equal(accessKeyModel.UpdatedBy, getAllKeysDataResponse.UpdatedBy);
            Assert.Equal(accessKeyModel.AccessKey, getAllKeysDataResponse.AccessKey);
        }

        private AccessKeyModel GetAccessKeyModel()
        {
            return new AccessKeyModel()
            {
                AccessKey = "abcdefg",
                IsKeyActive = true,
                ClientId = "1234567",
                ClientName = "Citi",
                Program = "Program1",
                ProgramGroup = "CPG1",
                UpdatedBy = "me"
            };
        }
    }
}
