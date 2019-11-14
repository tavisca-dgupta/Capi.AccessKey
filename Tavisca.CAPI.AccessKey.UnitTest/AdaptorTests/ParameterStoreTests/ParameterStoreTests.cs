using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.MockProvider.ParameterStore;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Amazon.SimpleSystemsManagement.Model;
using Tavisca.CAPI.AccessKey.Model.Models.Errors;
using Moq;
using Xunit;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.UnitTest.AdaptorTests.ParameterStoreTests
{
    public class ParameterStoreTests
    {
        private readonly Mock<IParameterStoreProvider> _mockParameterStoreProvider;
        public ParameterStoreTests()
        {
            _mockParameterStoreProvider = new Mock<IParameterStoreProvider>();
        }
        [Fact]
        public async Task AddKey_shall_return_true_if_value_got_added_to_ParameterStoreProvider()
        {
            var keyValueModel = new ParameterStoreModel() { Key="key_1",Value="Value_1" };
            _mockParameterStoreProvider.Setup(mpsp => mpsp.PutParameter(It.Is<PutParameterRequest>(r => r.Name.Equals(keyValueModel.Key) && r.Value.Equals(keyValueModel.Value)))).ReturnsAsync(new PutParameterResponse());
            var parameterStore = new ParameterStore(_mockParameterStoreProvider.Object);

            var addKeyresponseFromPS = await parameterStore.AddKey(keyValueModel);

            Assert.True(addKeyresponseFromPS);
        }
        [Fact]
        public async Task AddKey_shall_throw_ParameterStoreAdditionFailed_Exception_if_Addition_fails()
        {
            var keyValueModel = new ParameterStoreModel() { Key = "key_1", Value = "Value_1" };
            _mockParameterStoreProvider.Setup(mpsp => mpsp.PutParameter(It.IsAny<PutParameterRequest>())).ThrowsAsync(new Exception());
            var parameterStore = new ParameterStore(_mockParameterStoreProvider.Object);

            var thrownException = await Assert.ThrowsAsync<CustomException>(() => parameterStore.AddKey(keyValueModel));

            Assert.NotNull(thrownException);
            Assert.IsType<CustomException>(thrownException);
        }
        [Fact]
        public async Task DeleteKey_shall_return_true_if_value_got_deleted_from_ParameterStoreProvider()
        {
            var keyValueModel = new ParameterStoreModel() { Key = "key_1", Value = "Value_1" };
            _mockParameterStoreProvider.Setup(mpsp => mpsp.DeleteParameter(It.Is<DeleteParameterRequest>(r => r.Name.Equals(keyValueModel.Key)))).ReturnsAsync(new DeleteParameterResponse());
            var parameterStore = new ParameterStore(_mockParameterStoreProvider.Object);

            var deleteKeyresponseFromPS = await parameterStore.DeleteKey(keyValueModel);

            Assert.True(deleteKeyresponseFromPS);
        }
        [Fact]
        public async Task DeleteKey_shall_throw_ParameterStoreAdditionFailed_Exception_if_deletion_fails()
        {
            var keyValueModel = new ParameterStoreModel() { Key = "key_1", Value = "Value_1" };
            _mockParameterStoreProvider.Setup(mpsp => mpsp.DeleteParameter(It.IsAny<DeleteParameterRequest>())).ThrowsAsync(new Exception());
            var parameterStore = new ParameterStore(_mockParameterStoreProvider.Object);

            var thrownException = await Assert.ThrowsAsync<CustomException>(() => parameterStore.DeleteKey(keyValueModel));

            Assert.NotNull(thrownException);
            Assert.IsType<CustomException>(thrownException);
        }
    }
}
