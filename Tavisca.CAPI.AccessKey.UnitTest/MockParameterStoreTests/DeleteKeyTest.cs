using Xunit;
using Tavisca.CAPI.AccessKey.MockProvider.ParameterStoreProvider;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.UnitTest.MockParameterStoreTests
{
    public class DeleteKeyTest
    {
        [Fact]
        public async void Delete_accesskey()
        {
            var mock = new MockParameterStore();
            await mock.AddAccessKey(new ParameterStoreModel("z66gfdh278-453b-4c11-9302-9d456abcgr79bb23", "34gpytqq9ds"));
            Assert.True(await mock.DeleteAccessKey("z66gfdh278-453b-4c11-9302-9d456abcgr79bb23"));
        }
    }
}