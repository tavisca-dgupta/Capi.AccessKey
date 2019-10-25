using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Core.Components;
using Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider;
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
            ClientId = "381ddhad",
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
        public async void Client_Access_Key_Exists_Should_Return_Null()
        {
            string clientId = "1edb9skbh8g";
            var sut = new CreateKeyComponent(_databaseAdapter);
            var result = await sut.Create(accessKey);

            Assert.Null(result);
        }

        //[Fact]
        //public async void 
    }
}
