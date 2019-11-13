using Xunit;
using FluentAssertions;
using System;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Services.Tanslator;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTranslatorTests
{
    public class AccessKeytoGetAllResponseTranslatorTests
    {
        [Fact]
        public void AccessKeytoGetAllResponseTranslator_Success()
        {
            var accessKeyModel = GetAccessKeyModel();
            var getAllKeysResponse = accessKeyModel.ToAccesKeyDetail();
            ValidateTranslation(accessKeyModel,getAllKeysResponse);
        }

        private void ValidateTranslation(AccessKeyModel accessKeyModel, GetAllKeysResponse getAllKeysResponse)
        {
            Assert.Equal(accessKeyModel.AccessKey, getAllKeysResponse.AccessKey);
            Assert.Equal(accessKeyModel.ClientName, getAllKeysResponse.ClientName);
            Assert.Equal(accessKeyModel.IsKeyActive, getAllKeysResponse.IsKeyActive);
            Assert.Equal(accessKeyModel.UpdatedBy, getAllKeysResponse.UpdatedBy);
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
