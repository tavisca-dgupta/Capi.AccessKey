using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Core.Components;
using Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;
using Xunit;

namespace Tavisca.CAPI.AccessKey.UnitTest.CoreComponentsTests
{
    public class DeactivateKeyComponentTest
    {
        private readonly IDatabaseAdapter _databaseAdapter;
        private AccessKeyModel accessKey = new AccessKeyModel()
        {
            ClientName = "Citi",
            ProgramGroup = "south America",
            Program = "Prog50",
            UpdatedBy = "ankit malhotra"
        };

        public DeactivateKeyComponentTest()
        {
            _databaseAdapter = new MockAccessKeyDatabase();
        }

        [Fact]
        public async void Deactivate_method_returns_null_if_client_key_active()
        {
            accessKey.ClientId = "1gkrcs8g740";
            var sut = new DeactivateKeyComponent(_databaseAdapter);
            var result = await sut.Deactivate(accessKey);

            Assert.Null(result);
        }

        [Fact]
        public async void Activate_method_returns_AccessKeyModel_if_client_key_inactive()
        {
            accessKey.ClientId = "1edb9skbh8g";
            var sut = new DeactivateKeyComponent(_databaseAdapter);
            var result = await sut.Deactivate(accessKey);

            Assert.IsType<AccessKeyModel>(result);
        }
    }
}
