using Xunit;
using FluentAssertions;
using System;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Services.Tanslator;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTranslatorTests
{
    public class AccessKeyModelToActivateKeyResponseTests
    {
        [Fact]
        public void AccessKeyModelToActivateKeyResponse_Success()
        {
            var accessKeyModel = GetAccessKeyModel();
            var activateKeyResponse = accessKeyModel.ToActivateKeyResponse();
            ValidateTranslation(activateKeyResponse, accessKeyModel);
        }

        private void ValidateTranslation(ActivateKeyResponse activateKeyResponse, AccessKeyModel accessKeyModel)
        {
            Assert.Equal(accessKeyModel.ClientName,activateKeyResponse.ClientName);
            Assert.Equal(accessKeyModel.AccessKey, activateKeyResponse.AccessKey);
            Assert.Equal(accessKeyModel.IskeyActive, activateKeyResponse.IskeyActive);
            Assert.Equal(accessKeyModel.UpdatedBy, activateKeyResponse.UpdatedBy);
        }

        private AccessKeyModel GetAccessKeyModel()
        {
            return new AccessKeyModel()
            {
                AccessKey="abcdefg",
                IskeyActive=true,
                ClientId="1234567",
                ClientName="Citi",
                Program="Program1",
                ProgramGroup="CPG1",
                UpdatedBy="me"
            };
        }
    }
}
