using Tavisca.CAPI.AccessKey.Core.Components;
using Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider;
using Tavisca.CAPI.AccessKey.MockProvider.ParameterStoreProvider;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;
using Xunit;

namespace Tavisca.CAPI.AccessKey.UnitTest.CoreComponentsTests
{
    public class ActivateKeyComponentTest
    {
        private readonly IDatabaseAdapter _databaseAdapter;
        private readonly IParameterStore _parameterStore;

        private AccessKeyModel accessKey = new AccessKeyModel()
        {
            ClientName = "Citi",
            ProgramGroup = "south America",
            Program = "Prog50",
            UpdatedBy = "ankit malhotra"
        };

        public ActivateKeyComponentTest()
        {
            _databaseAdapter = new MockAccessKeyDatabase();
            _parameterStore = new MockParameterStore();
        }

        [Fact]
        public async void Activate_method_returns_null_if_client_key_active()
        {
            accessKey.ClientId = "2mpyt1qq9ds";
            var sut = new ActivateKeyComponent(_databaseAdapter,_parameterStore);
            var result = await sut.Activate(accessKey);
            Assert.Null(result);
        }

        [Fact]
        public async void Activate_method_returns_AccessKeyModel_if_client_key_inactive()
        {
            accessKey.ClientId = "1gkrcs8g740";
            var sut = new ActivateKeyComponent(_databaseAdapter,_parameterStore);
            var result = await sut.Activate(accessKey);
            Assert.IsType<AccessKeyModel>(result);
        }
    }
}
