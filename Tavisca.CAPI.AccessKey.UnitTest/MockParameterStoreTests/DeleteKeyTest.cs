using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Tavisca.CAPI.AccessKey.MockProvider.ParameterStoreProvider;
namespace Tavisca.CAPI.AccessKey.UnitTest.MockParameterStoreTests
{
    public class DeleteKeyTest
    {
        [Fact]
        public async void Delete_accesskey()
        {
            var mock = new MockParameterStore();
            Assert.True(await mock.DeleteAccessKey("f6640278-453b-4c11-9302-9d189279bb23"));
        }
    }
}