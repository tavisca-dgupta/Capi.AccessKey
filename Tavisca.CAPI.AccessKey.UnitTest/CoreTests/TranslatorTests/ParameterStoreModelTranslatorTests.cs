using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;
using Xunit;
using Tavisca.CAPI.AccessKey.Core.Translator;
namespace Tavisca.CAPI.AccessKey.UnitTest.CoreTests.TranslatorTests
{
    public class ParameterStoreModelTranslatorTests
    {
        [Fact]
        public void ParameterStoreModelTranslator_Success()
        {
            var accessKeyModel = GetAccessKeyModel();
            var parameterStoreModel = accessKeyModel.ToParameterStoreModel();
            ValidateTranslation(accessKeyModel,parameterStoreModel);
        }

        private void ValidateTranslation(AccessKeyModel accessKeyModel, ParameterStoreModel parameterStoreModel)
        {
            Assert.Equal(accessKeyModel.AccessKey, parameterStoreModel.Key);
            Assert.Equal(accessKeyModel.ClientTenantId, parameterStoreModel.Value);
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
