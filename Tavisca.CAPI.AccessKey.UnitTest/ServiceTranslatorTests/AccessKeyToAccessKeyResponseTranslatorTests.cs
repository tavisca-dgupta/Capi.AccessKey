using Xunit;
using FluentAssertions;
using System;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Services.Tanslator;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTranslatorTests
{
    public class AccessKeyToAccessKeyResponseTranslatorTests
    {
        [Fact]
        public void AccessKeyToAccessKeyResponseTranslator_Success()
        {
            var accessKeyModel = GetAccessKeyModel();
            var accessKeyResponse = accessKeyModel.ToAccessKeyResponse();
            ValidateTranslation(accessKeyModel,accessKeyResponse);
        }

        private void ValidateTranslation(AccessKeyModel accessKeyModel, AccessKeyResponse accessKeyResponse)
        {
            Assert.Equal(accessKeyModel.ClientName, accessKeyResponse.ClientName);
            Assert.Equal(accessKeyModel.AccessKey, accessKeyResponse.AccessKey);
            Assert.Equal(accessKeyModel.IsKeyActive, accessKeyResponse.IsKeyActive);
            Assert.Equal(accessKeyModel.UpdatedBy,accessKeyResponse.UpdatedBy);
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
