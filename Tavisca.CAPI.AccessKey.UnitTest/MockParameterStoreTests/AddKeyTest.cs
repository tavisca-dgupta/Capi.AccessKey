using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Tavisca.CAPI.AccessKey.MockProvider.ParameterStoreProvider;
using Tavisca.CAPI.AccessKey.Model.Models;
using System.Threading.Tasks;

namespace Tavisca.CAPI.AccessKey.UnitTest.MockParameterStoreTests
{
    public class AddKeyTest
    {
        [Fact]
        public async void Add_accesskey()
        {
            var mock = new MockParameterStore();
            Assert.True(await mock.AddAccessKey(new ParameterStoreModel("z66gfdh278-453b-4c11-9302-9d456abcgr79bb23", "34gpytqq9ds")));
        }
    }
}