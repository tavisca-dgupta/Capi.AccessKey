using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.MockProvider.ParameterStore;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Amazon.SimpleSystemsManagement.Model;
using Tavisca.CAPI.AccessKey.Model.Models.Errors;
using Amazon.SimpleSystemsManagement;
using Moq;
using Xunit;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.MockProvider.ParameterStore.Utility;
namespace Tavisca.CAPI.AccessKey.UnitTest.AdaptorTests.ParameterStoreTests.UtilityTests
{
    public class ParameterStoreProviderTests
    {
        private readonly Mock<AmazonSimpleSystemsManagementClient> _mockClient;
        public ParameterStoreProviderTests()
        {
            _mockClient = new Mock<AmazonSimpleSystemsManagementClient>();
        }
        [Fact]
        public async Task AddKey_shall_return_valid_response_if_value_got_added()
        {
            var putParameterResponse = new PutParameterResponse();
            var putParameterRequest = new PutParameterRequest() { Name = "key_1", Value = "Value_1",Overwrite=false,Type= ParameterType.SecureString };
            _mockClient.Setup(mc => mc.PutParameterAsync(putParameterRequest, default)).ReturnsAsync(putParameterResponse);
            var parameterStoreProvider = new ParameterStoreProvider();
            parameterStoreProvider._client = _mockClient.Object;

            var responseFromPSProvider = await parameterStoreProvider.PutParameter(putParameterRequest);

            Assert.Equal(putParameterResponse, responseFromPSProvider);
        }
        [Fact]
        public async Task AddKey_shall_throw_Error_if_Client_throws_error_while_Adding()
        {
            var exception = new Exception();
            var putParameterRequest = new PutParameterRequest() { Name = "key_1", Value = "Value_1", Overwrite = false, Type = ParameterType.SecureString };
            _mockClient.Setup(mc => mc.PutParameterAsync(It.IsAny<PutParameterRequest>(), default)).ThrowsAsync(exception);
            var parameterStoreProvider = new ParameterStoreProvider();
            parameterStoreProvider._client = _mockClient.Object;

            var thrownException = await Assert.ThrowsAsync<Exception>(() => parameterStoreProvider.PutParameter(putParameterRequest));

            Assert.NotNull(thrownException);
            Assert.Equal(exception, thrownException);
        }
        [Fact]
        public async Task DeleteKey_shall_return_valid_response_if_value_got_deleted()
        {
            var deleteParameterResponse = new DeleteParameterResponse();
            var deleteParameterRequest = new DeleteParameterRequest() { Name = "key_1" };
            _mockClient.Setup(mc => mc.DeleteParameterAsync(deleteParameterRequest, default)).ReturnsAsync(deleteParameterResponse);
            var parameterStoreProvider = new ParameterStoreProvider();
            parameterStoreProvider._client = _mockClient.Object;

            var responseFromPSProvider = await parameterStoreProvider.DeleteParameter(deleteParameterRequest);

            Assert.Equal(deleteParameterResponse, responseFromPSProvider);
        }
        [Fact]
        public async Task DeleteKey_shall_throw_Error_if_Client_throws_error_while_deleting()
        {
            var exception = new Exception();
            var deleteParameterRequest = new DeleteParameterRequest() { Name = "key_1" };
            _mockClient.Setup(mc => mc.DeleteParameterAsync(It.IsAny<DeleteParameterRequest>(), default)).ThrowsAsync(exception);
            var parameterStoreProvider = new ParameterStoreProvider();
            parameterStoreProvider._client = _mockClient.Object;

            var thrownException = await Assert.ThrowsAsync<Exception>(() => parameterStoreProvider.DeleteParameter(deleteParameterRequest));

            Assert.NotNull(thrownException);
            Assert.Equal(exception, thrownException);
        }
        [Fact]
        public void GetCLient_method_shall_return_valid_AmazonSimpleSystemsManagementClient()
        {
            var parameterStoreProvider = new ParameterStoreProvider();
            parameterStoreProvider._client = _mockClient.Object;
            var client = parameterStoreProvider.GetClient();

            Assert.NotNull(client);
            Assert.IsType<AmazonSimpleSystemsManagementClient>(client);
        }
    }
}
