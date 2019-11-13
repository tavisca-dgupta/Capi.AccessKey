using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;
using Tavisca.CAPI.AccessKey.Model.Models.Errors;
using Tavisca.CAPI.AccessKey.Services.Services;
using Tavisca.CAPI.AccessKey.Services.Tanslator;
using Tavisca.Platform.Common.Models;
using Xunit;
namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTests
{
    public class AccessKeyServiceTests
    {
        private readonly Mock<IAccessKeyComponent> _moqAccessKey;
        private readonly Mock<IDeactivateKey> _moqDeactivateKey;
        private readonly Mock<ICreateKey> _moqCreateKey;
        private readonly Mock<IActivateKey> _moqActivateKey;
        public AccessKeyServiceTests()
        {
            _moqAccessKey = new Mock<IAccessKeyComponent>();
            _moqDeactivateKey = new Mock<IDeactivateKey>();
            _moqCreateKey = new Mock<ICreateKey>();
            _moqActivateKey = new Mock<IActivateKey>();
        }
        [Fact]
        public async Task GetAllKeys_should_return_valid_Response_if_AccessKyeComponent_returns_value()
        {
            var accessKeys = GetaccessKeys();
            _moqAccessKey.Setup(mak => mak.GetAll()).ReturnsAsync(accessKeys);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);
            var getAllKeysResponseFromService = await accessKeyService.GetAllKeys();
            ValidateGetallKeys(accessKeys, getAllKeysResponseFromService);
        }

        private void ValidateGetallKeys(List<AccessKeyModel> accessKeys, List<GetAllKeysResponse> getAllKeysResponseFromService)
        {
            for(int i = 0;i < accessKeys.Count; i++)
            {
                Assert.Equal(accessKeys[i].AccessKey, getAllKeysResponseFromService[i].AccessKey);
                Assert.Equal(accessKeys[i].IsKeyActive, getAllKeysResponseFromService[i].IsKeyActive);
                Assert.Equal(accessKeys[i].ClientClassicId, getAllKeysResponseFromService[i].ClientClassicId);
                Assert.Equal(accessKeys[i].ClientId, getAllKeysResponseFromService[i].ClientId);
                Assert.Equal(accessKeys[i].ClientName, getAllKeysResponseFromService[i].ClientName);
                Assert.Equal(accessKeys[i].ClientTenantId, getAllKeysResponseFromService[i].ClientTenantId);
                Assert.Equal(accessKeys[i].CreatedOn, getAllKeysResponseFromService[i].CreatedOn);
                Assert.Equal(accessKeys[i].Program, getAllKeysResponseFromService[i].Program);
                Assert.Equal(accessKeys[i].ProgramGroup, getAllKeysResponseFromService[i].ProgramGroup);
                Assert.Equal(accessKeys[i].ProgramId, getAllKeysResponseFromService[i].ProgramId);
                Assert.Equal(accessKeys[i].LastUpdatedOn, getAllKeysResponseFromService[i].LastUpdatedOn);
                Assert.Equal(accessKeys[i].UpdatedBy, getAllKeysResponseFromService[i].UpdatedBy);
            }
        }

        private List<AccessKeyModel> GetaccessKeys()
        {
            List<AccessKeyModel> accessKeys = new List<AccessKeyModel>();
            accessKeys.Add(new AccessKeyModel() { AccessKey = new Guid().ToString(), ClientClassicId = "ClientClassicId1", IsKeyActive = true, ClientId = "ClientId1", ClientName = "Name1", ClientTenantId = "ClientTenantId1", CreatedOn = "2773773", LastUpdatedOn = "1234", Program = "Program1", ProgramGroup = "Group1", ProgramId = "ProgramId1", UpdatedBy = "U1" });
            accessKeys.Add(new AccessKeyModel() { AccessKey = new Guid().ToString(), ClientClassicId = "ClientClassicId2", IsKeyActive = false, ClientId = "ClientId2", ClientName = "Name2", ClientTenantId = "ClientTenantId2", CreatedOn = "742764", LastUpdatedOn = "1223", Program = "Program2", ProgramGroup = "Group2", ProgramId = "ProgramId2", UpdatedBy = "U2" });
            accessKeys.Add(new AccessKeyModel() { AccessKey = new Guid().ToString(), ClientClassicId = "ClientClassicId3", IsKeyActive = true, ClientId = "ClientId3", ClientName = "Name3", ClientTenantId = "ClientTenantId3", CreatedOn = "3423333", LastUpdatedOn = "5432", Program = "Program3", ProgramGroup = "Group3", ProgramId = "ProgramId3", UpdatedBy = "U3" });
            accessKeys.Add(new AccessKeyModel() { AccessKey = new Guid().ToString(), ClientClassicId = "ClientClassicId4", IsKeyActive = true, ClientId = "ClientId4", ClientName = "Name4", ClientTenantId = "ClientTenantId4", CreatedOn = "3333333", LastUpdatedOn = "1234", Program = "Program4", ProgramGroup = "Group4", ProgramId = "ProgramId4", UpdatedBy = "U4" });
            return accessKeys;
        }

        [Fact]
        public async Task GetAllKeys_should_throw_exception_if_accessKeyComponent_throws_exception()
        {
            var exception = new Exception("get all keys exception");
            _moqAccessKey.Setup(mak => mak.GetAll()).ThrowsAsync(exception);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);

            var thrownException = await Assert.ThrowsAsync<Exception>(() => accessKeyService.GetAllKeys());
            Assert.NotNull(thrownException);
            Assert.Equal(exception, thrownException);
        }
        [Fact]
        public async Task Deactivate_Key_should_retuan_a_valid_value_if_deactiavteKeyComponent_returns_value()
        {
            var deactivateKeyRequest = new DeactivateKeyRequest() { UpdatedBy="me"};
            var accessKey = "ABCD-1234";
            var accessKeyModelFromComponent = new AccessKeyModel() { AccessKey=accessKey,IsKeyActive=false,UpdatedBy="me",LastUpdatedOn="26/01/1997"};
            _moqDeactivateKey.Setup(mdk => mdk.Deactivate(It.Is<AccessKeyModel>(akm => akm.AccessKey.Equals(accessKey)))).ReturnsAsync(accessKeyModelFromComponent);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);
            
            var deactivateKeyResponseFromService =await accessKeyService.DeactivateKey(deactivateKeyRequest, accessKey);
            
            ValidateDeactivateKeyResponse(accessKeyModelFromComponent,deactivateKeyResponseFromService);
        }

        private void ValidateDeactivateKeyResponse(AccessKeyModel accessKeyModelFromComponent, DeactivateKeyResponse deactivateKeyResponseFromService)
        {
            Assert.Equal(accessKeyModelFromComponent.AccessKey, deactivateKeyResponseFromService.AccessKey);
            Assert.Equal(accessKeyModelFromComponent.IsKeyActive, deactivateKeyResponseFromService.IsKeyActive);
            Assert.Equal(accessKeyModelFromComponent.UpdatedBy, deactivateKeyResponseFromService.UpdatedBy);
            Assert.Equal(accessKeyModelFromComponent.LastUpdatedOn, deactivateKeyResponseFromService.LastUpdatedOn);
        }
        [Fact]
        public async Task Deactivate_key_should_throw_Error_if_deactivateKeyComponent_throws_ParameterStore_Error()
        {
            var deactivateKeyRequest = new DeactivateKeyRequest() { UpdatedBy = "me" };
            var accessKey = "ABCD-1234";
            var exception = ServerSide.ParameterStoreNotResponding();
            _moqDeactivateKey.Setup(mdk => mdk.Deactivate(It.IsAny<AccessKeyModel>())).ThrowsAsync(exception);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);

            var thrownException = await Assert.ThrowsAsync<CustomException>(() => accessKeyService.DeactivateKey(deactivateKeyRequest, accessKey));

            Assert.NotNull(thrownException);
            Assert.Equal(exception, thrownException);
        }
        [Fact]
        public async Task Deactivate_key_should_throw_Error_if_deactivateKeyComponent_throws_KeyIsDeactive_Error()
        {
            var deactivateKeyRequest = new DeactivateKeyRequest() { UpdatedBy = "me" };
            var accessKey = "ABCD-1234";
            var exception = ClientSide.KeyIsAlreadyDeactivated();
            _moqDeactivateKey.Setup(mdk => mdk.Deactivate(It.IsAny<AccessKeyModel>())).ThrowsAsync(exception);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);

            var thrownException = await Assert.ThrowsAsync<CustomException>(() => accessKeyService.DeactivateKey(deactivateKeyRequest, accessKey));

            Assert.NotNull(thrownException);
            Assert.Equal(exception, thrownException);
        }
        [Fact]
        public async Task Activate_Key_should_retuan_a_valid_value_if_activateKeyComponent_returns_value()
        {
            var activateKeyRequest = new ActivateKeyRequest() { UpdatedBy = "me" };
            var accessKey = "ABCD-1234";
            var accessKeyModelFromComponent = new AccessKeyModel() { AccessKey = accessKey, IsKeyActive = true, UpdatedBy = "me", LastUpdatedOn = "26/01/1997" };
            _moqActivateKey.Setup(mak => mak.Activate(It.Is<AccessKeyModel>(akm => akm.AccessKey.Equals(accessKey)))).ReturnsAsync(accessKeyModelFromComponent);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);

            var activateKeyResponseFromService = await accessKeyService.ActivateKey(activateKeyRequest, accessKey);

            ValidateActivateKeyResponse(accessKeyModelFromComponent, activateKeyResponseFromService);
        }

        private void ValidateActivateKeyResponse(AccessKeyModel accessKeyModelFromComponent, Model.Models.DataContracts.ActivateKeyResponse activateKeyResponseFromService)
        {
            Assert.Equal(accessKeyModelFromComponent.AccessKey, activateKeyResponseFromService.AccessKey);
            Assert.Equal(accessKeyModelFromComponent.IsKeyActive, activateKeyResponseFromService.IsKeyActive);
            Assert.Equal(accessKeyModelFromComponent.UpdatedBy, activateKeyResponseFromService.UpdatedBy);
            Assert.Equal(accessKeyModelFromComponent.LastUpdatedOn, activateKeyResponseFromService.LastUpdatedOn);
        }

        [Fact]
        public async Task Activate_key_should_throw_Error_if_activateKeyComponent_throws_ParameterStore_Error()
        {
            var activateKeyRequest = new ActivateKeyRequest() { UpdatedBy = "me" };
            var accessKey = "ABCD-1234";
            var exception = ServerSide.ParameterStoreNotResponding();
            _moqActivateKey.Setup(mak => mak.Activate(It.IsAny<AccessKeyModel>())).ThrowsAsync(exception);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);

            var thrownException = await Assert.ThrowsAsync<CustomException>(() => accessKeyService.ActivateKey(activateKeyRequest, accessKey));

            Assert.NotNull(thrownException);
            Assert.Equal(exception, thrownException);
        }
        [Fact]
        public async Task Activate_key_should_throw_Error_if_activateKeyComponent_throws_KeyIsACtive_Error()
        {
            var activateKeyRequest = new ActivateKeyRequest() { UpdatedBy = "me" };
            var accessKey = "ABCD-1234";
            var exception = ClientSide.KeyIsAlreadyActivated();
            _moqActivateKey.Setup(mak => mak.Activate(It.IsAny<AccessKeyModel>())).ThrowsAsync(exception);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);

            var thrownException = await Assert.ThrowsAsync<CustomException>(() => accessKeyService.ActivateKey(activateKeyRequest, accessKey));

            Assert.NotNull(thrownException);
            Assert.Equal(exception, thrownException);
        }
        [Fact]
        public async Task CreateKey_Shall_throw_error_if_createKey_component_throws_error()
        {
            var accessKeyRequest = new AccessKeyRequest() { ClientId = "123", ClientName = "abc", Program = "pro", ProgramGroup = "cpg", UpdatedBy = "me", ClientClassicId = "bcd", ClientTenantId = "1234", ProgramId = "1234abcd" };
            var exception = ClientSide.KeyAlreadyExists();
            _moqCreateKey.Setup(mck => mck.Create(It.IsAny<AccessKeyModel>())).ThrowsAsync(exception);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);

            var thrownException = await Assert.ThrowsAsync<CustomException>(() => accessKeyService.CreateKey(accessKeyRequest));

            Assert.NotNull(thrownException);
            Assert.Equal(exception, thrownException);
        }
        [Fact]
        public async Task CreateKey_Test_For_Positive_Scenario()
        {
            var accessKeyRequest = new AccessKeyRequest() { ClientId = "123", ClientName = "abc", Program = "pro", ProgramGroup = "cpg", UpdatedBy = "me", ClientClassicId="bcd",ClientTenantId="1234",ProgramId="1234abcd" };
            var accessKeyModel = new AccessKeyModel() { ClientId = "123", ClientName = "abc", Program = "pro", ProgramGroup = "cpg", UpdatedBy = "me", ClientClassicId = "bcd", ProgramId = "1234abcd", AccessKey = new Guid().ToString(), IsKeyActive = false };
            _moqCreateKey.Setup(mck => mck.Create(It.Is<AccessKeyModel>(akm => akm.ProgramId.Equals(accessKeyRequest.ProgramId)))).ReturnsAsync(accessKeyModel);
            var accessKeyService = new AccessKeyService(_moqDeactivateKey.Object, _moqCreateKey.Object, _moqActivateKey.Object, _moqAccessKey.Object);

            var createKeyResponseFromService = await accessKeyService.CreateKey(accessKeyRequest);

            ValidateCreateKeyResponse(accessKeyModel, createKeyResponseFromService);

        }
        private void ValidateCreateKeyResponse(AccessKeyModel accessKeyModel, AccessKeyResponse createKeyResponseFromService)
        {
            Assert.Equal(accessKeyModel.AccessKey, createKeyResponseFromService.AccessKey);
            Assert.Equal(accessKeyModel.IsKeyActive, createKeyResponseFromService.IsKeyActive);
            Assert.Equal(accessKeyModel.ProgramId, createKeyResponseFromService.ProgramId);
        }
        
    }
}