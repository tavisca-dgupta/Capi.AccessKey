using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;
using Tavisca.CAPI.AccessKey.Services.Tanslator;
using Xunit;
namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTests.TranslatorsTests
{
    public class DeactivateKeyResponseTranslatorTests
    {
        [Fact]
        public void DeactivateKeyResponseTranslator_Success()
        {
            var accessKeyModel = GetAccessKeyModel();
            var deactivateKeyResponse = accessKeyModel.ToDeactivateKeyResponse();
            ValidateTranslation(accessKeyModel,deactivateKeyResponse);
        }

        private void ValidateTranslation(AccessKeyModel accessKeyModel, DeactivateKeyResponse deactivateKeyResponse)
        {
            Assert.Equal(accessKeyModel.AccessKey, deactivateKeyResponse.AccessKey);
            Assert.Equal(accessKeyModel.IsKeyActive, deactivateKeyResponse.IsKeyActive);
            Assert.Equal(accessKeyModel.LastUpdatedOn, deactivateKeyResponse.LastUpdatedOn);
            Assert.Equal(accessKeyModel.AccessKey, deactivateKeyResponse.AccessKey);
        }

        private AccessKeyModel GetAccessKeyModel()
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
