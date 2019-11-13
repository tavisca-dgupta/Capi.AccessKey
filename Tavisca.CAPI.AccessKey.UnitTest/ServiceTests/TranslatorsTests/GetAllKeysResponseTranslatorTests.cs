using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Xunit;
using Tavisca.CAPI.AccessKey.Services.Tanslator;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTests.TranslatorsTests
{
    public class GetAllKeysResponseTranslatorTests
    {
        [Fact]
        public void GetAllKeysResponseTranslator_Success()
        {
            var accessKeyModel = GetAccessKeyModel();
            var getAllKeysResponse = accessKeyModel.ToGetAllKeysResponse();
            ValidateTranslation(accessKeyModel,getAllKeysResponse);
        }

        private void ValidateTranslation(AccessKeyModel accessKeyModel, GetAllKeysResponse getAllKeysResponse)
        {
            Assert.Equal(accessKeyModel.AccessKey, getAllKeysResponse.AccessKey);
            Assert.Equal(accessKeyModel.IsKeyActive, getAllKeysResponse.IsKeyActive);
            Assert.Equal(accessKeyModel.ClientClassicId, getAllKeysResponse.ClientClassicId);
            Assert.Equal(accessKeyModel.ClientId, getAllKeysResponse.ClientId);
            Assert.Equal(accessKeyModel.ClientName, getAllKeysResponse.ClientName);
            Assert.Equal(accessKeyModel.ClientTenantId, getAllKeysResponse.ClientTenantId);
            Assert.Equal(accessKeyModel.CreatedOn, getAllKeysResponse.CreatedOn);
            Assert.Equal(accessKeyModel.LastUpdatedOn, getAllKeysResponse.LastUpdatedOn);
            Assert.Equal(accessKeyModel.Program, getAllKeysResponse.Program);
            Assert.Equal(accessKeyModel.ProgramGroup, getAllKeysResponse.ProgramGroup);
            Assert.Equal(accessKeyModel.ProgramId, getAllKeysResponse.ProgramId);
            Assert.Equal(accessKeyModel.UpdatedBy, getAllKeysResponse.UpdatedBy);
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
