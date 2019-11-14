using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Xunit;
using Tavisca.CAPI.AccessKey.Services.Tanslator;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTests.TranslatorsTests
{
    public class ActivateKeyResponseTranslator
    {
        [Fact]
        public void ActivateKeyResponseTranslator_Success()
        {
            var accessKeyModel = GetAccessKetyModel();
            var activateKeyResponse = accessKeyModel.ToActivateKeyResponse();
            ValidateTranslation(accessKeyModel, activateKeyResponse);
        }

        private void ValidateTranslation(AccessKeyModel accessKeyModel, ActivateKeyResponse activateKeyResponse)
        {
            Assert.Equal(accessKeyModel.AccessKey, activateKeyResponse.AccessKey);
            Assert.Equal(accessKeyModel.IsKeyActive, activateKeyResponse.IsKeyActive);
            Assert.Equal(accessKeyModel.UpdatedBy, activateKeyResponse.UpdatedBy);
            Assert.Equal(accessKeyModel.ClientTenantId, activateKeyResponse.ClientTenantId);
            Assert.Equal(accessKeyModel.LastUpdatedOn, activateKeyResponse.LastUpdatedOn);
        }

        private AccessKeyModel GetAccessKetyModel()
        {
            return new AccessKeyModel()
            {
                AccessKey = new Guid().ToString(),
                IsKeyActive = true,
                ClientClassicId = "Client_Classic_Id",
                ClientId = "Client_Id",
                ClientName = "Client_Name",
                ClientTenantId = "Client_Tenant_Id",
                CreatedOn = "Created_On",
                LastUpdatedOn = "Last_Updated_On",
                Program = "Program",
                ProgramGroup = "Program_Group",
                ProgramId = "Program_Id",
                UpdatedBy = "Updated_By"
            };
        }
    }
}
