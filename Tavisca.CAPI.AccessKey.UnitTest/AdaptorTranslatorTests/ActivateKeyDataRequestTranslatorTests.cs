using System;
using Tavisca.CAPI.AccessKey.MockProvider.Tanslators;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;
using Xunit;

namespace Tavisca.CAPI.AccessKey.UnitTest.AdaptorTranslatorTests
{
    public class ActivateKeyDataRequestTranslatorTests
    {
        [Fact]
        public void ActivateKeyDataRequestTranslator_Success()
        {
            var accessKeyModel = GetAccessKeyModel();
            var activateKeyDataRequest = accessKeyModel.ToActivateKeyDataRequest();
            ValidateTranslation(accessKeyModel,activateKeyDataRequest);
        }

        private void ValidateTranslation(AccessKeyModel accessKeyModel, ActivateKeyDataRequest activateKeyDataRequest)
        {
            Assert.Equal(accessKeyModel.AccessKey,activateKeyDataRequest.AccessKey);
            Assert.Equal(accessKeyModel.ClientName, activateKeyDataRequest.ClientName);
            Assert.Equal(accessKeyModel.IskeyActive,activateKeyDataRequest.IskeyActive);
            Assert.Equal(accessKeyModel.UpdatedBy, activateKeyDataRequest.UpdatedBy);
            Assert.Equal(System.DateTime.Today.ToString("dd-MM-yyyy"), activateKeyDataRequest.UpdateDate);
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
