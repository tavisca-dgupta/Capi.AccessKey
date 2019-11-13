using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Moq;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Core.Components;

namespace Tavisca.CAPI.AccessKey.UnitTest.CoreTests.ComponentsTests
{
    //TODO
    public class AccessKeyComponentTests
    {
        private readonly Mock<IDatabaseAdapter> _databaseAdapter;
        public AccessKeyComponentTests()
        {
            _databaseAdapter = new Mock<IDatabaseAdapter>();
        }
        [Fact]
        public async Task Getall_method_shall_Return_all_accessKeys()
        {
            var accessKeys = GetaccessKeys();
            _databaseAdapter.Setup(da => da.GetAllClients()).ReturnsAsync(accessKeys);
            var accessKeyComponent = new AccessKeyComponent(_databaseAdapter.Object);
            var getallResponseFromComponent = await accessKeyComponent.GetAll();
            ValidateGetallResponse(accessKeys,getallResponseFromComponent);
        }

        private void ValidateGetallResponse(List<AccessKeyModel> accessKeys, List<AccessKeyModel> getallResponseFromComponent)
        {
            for(int i = 0; i < accessKeys.Count; i++)
            {
                Assert.Equal(accessKeys[i], getallResponseFromComponent[i]);
            }
        }

        private List<AccessKeyModel> GetaccessKeys()
        {
            var accessKeys = new List<AccessKeyModel>();
            accessKeys.Add(new AccessKeyModel() { AccessKey = new Guid().ToString(), ClientClassicId = "ClientClassicId1", IsKeyActive = true, ClientId = "ClientId1", ClientName = "Name1", ClientTenantId = "ClientTenantId1", CreatedOn = "2773773", LastUpdatedOn = "1234", Program = "Program1", ProgramGroup = "Group1", ProgramId = "ProgramId1", UpdatedBy = "U1" });
            accessKeys.Add(new AccessKeyModel() { AccessKey = new Guid().ToString(), ClientClassicId = "ClientClassicId2", IsKeyActive = false, ClientId = "ClientId2", ClientName = "Name2", ClientTenantId = "ClientTenantId2", CreatedOn = "742764", LastUpdatedOn = "1223", Program = "Program2", ProgramGroup = "Group2", ProgramId = "ProgramId2", UpdatedBy = "U2" });
            accessKeys.Add(new AccessKeyModel() { AccessKey = new Guid().ToString(), ClientClassicId = "ClientClassicId3", IsKeyActive = true, ClientId = "ClientId3", ClientName = "Name3", ClientTenantId = "ClientTenantId3", CreatedOn = "3423333", LastUpdatedOn = "5432", Program = "Program3", ProgramGroup = "Group3", ProgramId = "ProgramId3", UpdatedBy = "U3" });
            accessKeys.Add(new AccessKeyModel() { AccessKey = new Guid().ToString(), ClientClassicId = "ClientClassicId4", IsKeyActive = true, ClientId = "ClientId4", ClientName = "Name4", ClientTenantId = "ClientTenantId4", CreatedOn = "3333333", LastUpdatedOn = "1234", Program = "Program4", ProgramGroup = "Group4", ProgramId = "ProgramId4", UpdatedBy = "U4" });
            return accessKeys;
        }
        
    }
}
