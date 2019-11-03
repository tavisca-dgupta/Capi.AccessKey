using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;
using Tavisca.CAPI.AccessKey.Services.Services;
using Tavisca.CAPI.AccessKey.Services.Tanslator;
using Xunit;
namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTests
{
    public class AccessKeyServiceTests
    {
        private readonly Mock<IAccessKeyComponent> _moqAccessKey = new Mock<IAccessKeyComponent>();
        private readonly Mock<IDeactivateKey> _moqDeactivateKey = new Mock<IDeactivateKey>();
        private readonly Mock<ICreateKey> _moqCreateKey = new Mock<ICreateKey>();
        private readonly Mock<IActivateKey> _moqActivateKey = new Mock<IActivateKey>();
        [Fact]
        public async Task GetAllKeys_Test_for_positive_Scenario()
        {
            var clientKeysFromAccessKeyModel = GetclientKeys();
            _moqAccessKey.Setup(mak => mak.GetAll()).ReturnsAsync(clientKeysFromAccessKeyModel);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object,_moqCreateKey.Object,_moqActivateKey.Object,_moqAccessKey.Object);
            var getAllKeysResponseFromAccessKeyService = await accessKeyService.GetAllKeys();
            ValidateGetallKeys(clientKeysFromAccessKeyModel, getAllKeysResponseFromAccessKeyService);
        }
        [Fact]
        public async Task GetAllKeys_Test_for_negative_Scenario()
        {
            var exception = new Exception("get all keys exception");
            _moqAccessKey.Setup(mak => mak.GetAll()).ThrowsAsync(exception);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);

            var thrownException = await Assert.ThrowsAsync<Exception>(() => accessKeyService.GetAllKeys());
            Assert.NotNull(thrownException);
            Assert.Equal(exception, thrownException);
        }
        [Fact]
        public async Task ActivateKey_Test_for_positive_Scenario()
        {
            var activateKeyRequest = new ActivateKeyRequest() { ClientName = "abcd", AccessKey = "1234", ClientId = "ab12", IskeyActive = true, UpdatedBy = "me" };
            var accessKeyModelResponse = new AccessKeyModel() { AccessKey = "1234", IskeyActive = true, ClientId = "ab12", ClientName = "abcd", UpdatedBy = "me" };
            _moqActivateKey.Setup(mak => mak.Activate(It.IsAny<AccessKeyModel>())).ReturnsAsync(accessKeyModelResponse);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);
            var activateKeyResponseFromAccessKeyService = await accessKeyService.ActivateKey(activateKeyRequest);
            ValidateActivateKey(accessKeyModelResponse.ToActivateKeyResponse(), activateKeyResponseFromAccessKeyService);
        }
        [Fact]
        public async Task ActivateKey_Test_for_negative_Scenario()
        {
            var activateKeyRequest = new ActivateKeyRequest() { ClientName = "abcd", AccessKey = "1234", ClientId = "ab12", IskeyActive = true, UpdatedBy = "me" };
            var exception = new Exception("activate key exception");
            _moqActivateKey.Setup(mak => mak.Activate(It.IsAny<AccessKeyModel>())).ThrowsAsync(exception);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);
            var thrownException = await Assert.ThrowsAsync<Exception>(() => accessKeyService.ActivateKey(activateKeyRequest));
            Assert.NotNull(thrownException);
            Assert.Equal(exception, thrownException);
        }
        private void ValidateActivateKey(ActivateKeyResponse activateKeyResponse, ActivateKeyResponse activateKeyResponseFromAccessKeyService)
        {
            Assert.Equal(activateKeyResponseFromAccessKeyService.AccessKey, activateKeyResponse.AccessKey);
            Assert.Equal(activateKeyResponseFromAccessKeyService.ClientName, activateKeyResponse.ClientName);
            Assert.Equal(activateKeyResponseFromAccessKeyService.IskeyActive, activateKeyResponse.IskeyActive);
            Assert.Equal(activateKeyResponseFromAccessKeyService.UpdatedBy, activateKeyResponse.UpdatedBy);
        }
        [Fact]
        public async Task DeactivateKey_Test_for_positive_Scenario()
        {
            var deactivateKeyRequest = new DeactivateKeyRequest() { ClientName = "abcd", AccessKey = "1234", ClientId = "ab12", IskeyActive = false, UpdatedBy = "me" };
            var accessKeyModelResponse = new AccessKeyModel() { ClientName = "abcd", AccessKey = "1234", ClientId = "ab12", IskeyActive = false, UpdatedBy = "me" };
            _moqDeactivateKey.Setup(mak => mak.Deactivate(It.IsAny<AccessKeyModel>())).ReturnsAsync(accessKeyModelResponse);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);
            var deactivateKeyResponseFromAccessKeyService = await accessKeyService.DeactivateKey(deactivateKeyRequest);
            ValidateDeactivateKey(accessKeyModelResponse.ToDeactivateKeyResponse(), deactivateKeyResponseFromAccessKeyService);
        }
        [Fact]
        public async Task DeactivateKey_Test_for_negative_Scenario()
        {
            var deactivateKeyRequest = new DeactivateKeyRequest() { ClientName = "abcd", AccessKey = "1234", ClientId = "ab12", IskeyActive = false, UpdatedBy = "me" };
            var exception = new Exception("activate key exception");
            _moqDeactivateKey.Setup(mak => mak.Deactivate(It.IsAny<AccessKeyModel>())).ThrowsAsync(exception);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);
            var thrownException = await Assert.ThrowsAsync<Exception>(() => accessKeyService.DeactivateKey(deactivateKeyRequest));
            Assert.NotNull(thrownException);
            Assert.Equal(exception, thrownException);
        }
        [Fact]
        public async Task CreateKey_Test_for_positive_Scenario()
        {
            var accessKeyRequest = new AccessKeyRequest() { ClientId = "123", ClientName = "abc", Program = "pro", ProgramGroup = "cpg", UpdatedBy = "me" };
            var accessKeyModelResponse = new AccessKeyModel() { AccessKey = "", IskeyActive = false, ClientId = "123", ClientName = "abc", Program = "pro", ProgramGroup = "cpg", UpdatedBy = "me" };
            _moqCreateKey.Setup(mak => mak.Create(It.IsAny<AccessKeyModel>())).ReturnsAsync(accessKeyModelResponse);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);
            var createKeyResponseFromAccessKeyService = await accessKeyService.CreateKey(accessKeyRequest);
            ValidateCreatedKey(accessKeyModelResponse.ToAccessKeyResponse(), createKeyResponseFromAccessKeyService);
        }
        [Fact]
        public async Task CreateKey_Test_for_negative_Scenario()
        {
            var accessKeyRequest = new AccessKeyRequest() { ClientId = "123", ClientName = "abc", Program = "pro", ProgramGroup = "cpg", UpdatedBy = "me" };
            var exception = new Exception("activate key exception");
            _moqCreateKey.Setup(mak => mak.Create(It.IsAny<AccessKeyModel>())).ThrowsAsync(exception);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);
            var thrownException = await Assert.ThrowsAsync<Exception>(() => accessKeyService.CreateKey(accessKeyRequest));
            Assert.NotNull(thrownException);
            Assert.Equal(exception, thrownException);
        }
        private void ValidateCreatedKey(AccessKeyResponse accessKeyResponse, AccessKeyResponse createKeyResponseFromAccessKeyService)
        {
            Assert.Equal(accessKeyResponse.AccessKey, createKeyResponseFromAccessKeyService.AccessKey);
            Assert.Equal(accessKeyResponse.ClientName, createKeyResponseFromAccessKeyService.ClientName);
            Assert.Equal(accessKeyResponse.IskeyActive, createKeyResponseFromAccessKeyService.IskeyActive);
            Assert.Equal(accessKeyResponse.UpdatedBy, createKeyResponseFromAccessKeyService.UpdatedBy);
        }
        private void ValidateDeactivateKey(DeactivateKeyResponse deactivateKeyResponse, DeactivateKeyResponse deactivateKeyResponseFromAccessKeyService)
        {
            Assert.Equal(deactivateKeyResponse.AccessKey, deactivateKeyResponseFromAccessKeyService.AccessKey);
            Assert.Equal(deactivateKeyResponse.ClientName, deactivateKeyResponseFromAccessKeyService.ClientName);
            Assert.Equal(deactivateKeyResponse.IskeyActive, deactivateKeyResponseFromAccessKeyService.IskeyActive);
            Assert.Equal(deactivateKeyResponse.UpdatedBy, deactivateKeyResponseFromAccessKeyService.UpdatedBy);
        }

        private void ValidateGetallKeys(List<AccessKeyModel> clientKeysFromAccessKeyModel, List<GetAllKeysResponse> getAllKeysResponseFromAccessKeyService)
        {
            for (int i = 0; i < clientKeysFromAccessKeyModel.Count; i++)
            {
                Assert.Equal(clientKeysFromAccessKeyModel[i].ToAccesKeyDetail().AccessKey, getAllKeysResponseFromAccessKeyService[i].AccessKey);
                Assert.Equal(clientKeysFromAccessKeyModel[i].ToAccesKeyDetail().ClientName, getAllKeysResponseFromAccessKeyService[i].ClientName);
                Assert.Equal(clientKeysFromAccessKeyModel[i].ToAccesKeyDetail().IskeyActive, getAllKeysResponseFromAccessKeyService[i].IskeyActive);
                Assert.Equal(clientKeysFromAccessKeyModel[i].ToAccesKeyDetail().UpdatedBy, getAllKeysResponseFromAccessKeyService[i].UpdatedBy);
            }
        }
        private List<AccessKeyModel> GetclientKeys()
        {
            var accessKeyModelList = new List<AccessKeyModel>();
            accessKeyModelList.Add(new AccessKeyModel() { AccessKey = "Key_123", IskeyActive = true, ClientId = "Id_1234", ClientName = "ABC", Program = "P1", ProgramGroup = "CPG1", UpdatedBy = "me" });
            accessKeyModelList.Add(new AccessKeyModel() { AccessKey = "key_456", IskeyActive = false, ClientId = "Id_4567", ClientName = "DEF", Program = "P2", ProgramGroup = "CPG2", UpdatedBy = "me" });
            accessKeyModelList.Add(new AccessKeyModel() { AccessKey = "key_789", IskeyActive = true, ClientId = "Id_7891", ClientName = "GHI", Program = "P3", ProgramGroup = "CPG3", UpdatedBy = "me" });
            return accessKeyModelList;
        }
    }
}