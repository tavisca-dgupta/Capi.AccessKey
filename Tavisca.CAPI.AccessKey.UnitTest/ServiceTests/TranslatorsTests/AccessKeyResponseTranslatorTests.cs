using System;
using Tavisca.CAPI.AccessKey.Model.Models;
using Xunit;
using Tavisca.CAPI.AccessKey.Services.Tanslator;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTests.TranslatorsTests
{
    public class AccessKeyResponseTranslatorTests
    {
        [Fact]
        public void AccessKeyResponseTranslator_Success()
        {
            var accessKeyModel = GetAccessKeyModel();
            var accessKeyResponse = accessKeyModel.ToAccessKeyResponse();
            ValidateTranslation(accessKeyModel,accessKeyResponse);
        }

        private void ValidateTranslation(AccessKeyModel accessKeyModel, AccessKeyResponse accessKeyResponse)
        {
            Assert.Equal(accessKeyModel.AccessKey, accessKeyResponse.AccessKey);
            Assert.Equal(accessKeyModel.IsKeyActive, accessKeyResponse.IsKeyActive);
            Assert.Equal(accessKeyModel.ClientClassicId, accessKeyResponse.ClientClassicId);
            Assert.Equal(accessKeyModel.ClientId, accessKeyResponse.ClientId);
            Assert.Equal(accessKeyModel.ClientName, accessKeyResponse.ClientName);
            Assert.Equal(accessKeyModel.CreatedOn, accessKeyResponse.CreatedOn);
            Assert.Equal(accessKeyModel.LastUpdatedOn, accessKeyResponse.LastUpdatedOn);
            Assert.Equal(accessKeyModel.Program, accessKeyResponse.Program);
            Assert.Equal(accessKeyModel.ProgramGroup, accessKeyResponse.ProgramGroup);
            Assert.Equal(accessKeyModel.ProgramId, accessKeyResponse.ProgramId);
            Assert.Equal(accessKeyModel.UpdatedBy, accessKeyResponse.UpdatedBy);
        }

        private AccessKeyModel GetAccessKeyModel()
        {
            return new AccessKeyModel()
            {
                AccessKey=new Guid().ToString(),
                IsKeyActive=true,
                ClientClassicId= "Client_Classic_Id",
                ClientId= "Client_Id",
                ClientName= "Client_Name",
                ClientTenantId= "Client_Tenant_Id",
                CreatedOn= "Created_On",
                LastUpdatedOn= "Last_Updated_On",
                Program= "Program",
                ProgramGroup= "Program_Group",
                ProgramId= "Program_Id",
                UpdatedBy= "Updated_By"
            };
        }
    }
}
