using Tavisca.CAPI.AccessKey.Core.Components;
using Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider;
using Tavisca.CAPI.AccessKey.MockProvider.ParameterStoreProvider;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;
using Xunit;

namespace Tavisca.CAPI.AccessKey.UnitTest.CoreComponentsTests
{
    public class CreateKeyComponentTest
    {
        private readonly IDatabaseAdapter _databaseAdapter;

        private AccessKeyModel accessKey = new AccessKeyModel()
        {
            ClientName = "Citi",
            ProgramGroup = "south America",
            Program = "Prog50",
            UpdatedBy = "ankit malhotra"
        };

        public CreateKeyComponentTest()
        {
            _databaseAdapter = new MockAccessKeyDatabase();
        }
        [Fact]
        public async void Create_method_returns_null_if_client_access_key_exists()
        {
            accessKey.ClientId = "381ddhad";
            var sut = new CreateKeyComponent(_databaseAdapter);
            var result = await sut.Create(accessKey);
            Assert.Null(result);
        }

        [Fact]
        public async void Create_method_adds_IsKeyActive_field_if_client_key_doesnt_exist()
        {
            accessKey.ClientId = "newclient1";
            var sut = new CreateKeyComponent(_databaseAdapter);
            var result = await sut.Create(accessKey);
            Assert.False(result.IskeyActive);
        }

        [Fact]
        public async void Create_method_returns_AccessKeyModel_object_on_new_accesskey_creation()
        {
            accessKey.ClientId = "newclient1";
            var sut = new CreateKeyComponent(_databaseAdapter);
            var result = await sut.Create(accessKey);
            Assert.IsType<AccessKeyModel>(result);
        }
    }
}
