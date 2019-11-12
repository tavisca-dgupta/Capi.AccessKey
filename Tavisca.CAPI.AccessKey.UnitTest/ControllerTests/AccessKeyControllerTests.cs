using Xunit;
using Tavisca.CAPI.AccessKey.Web.Controllers;
using System.Threading.Tasks;
using Moq;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Tavisca.CAPI.AccessKey.UnitTest.ControllerTests
{
    public class AccessKeyControllerTests
    {
        private readonly Mock<IAccessKeyService> _moqAccessKeyService = new Mock<IAccessKeyService>();
        [Fact]
        public async Task Returns_same_response_as_what_AccessKey_service_returns_for_getall()
        {
            var getAllKeysResponse = GetAllKeysResponseList();
            _moqAccessKeyService.Setup(maks => maks.GetAllKeys()).ReturnsAsync(getAllKeysResponse);
            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
            var getAllKeysResponseFromController = await accessKeyController.Get();
            var result = getAllKeysResponseFromController.Result as OkObjectResult;
            var resultValue = result.Value as List<GetAllKeysResponse>;
            ValidateGetAllResponse(getAllKeysResponse, resultValue);
        }
        [Fact]
        public async Task Returns_not_found_if_AccessKey_service_returns_null_for_getall()
        {
            List<GetAllKeysResponse> getAllKeysResponse = null;
            _moqAccessKeyService.Setup(maks => maks.GetAllKeys()).ReturnsAsync(getAllKeysResponse);
            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
            var getAllKeysResponseFromController = await accessKeyController.Get();
            getAllKeysResponseFromController.Result.Should().BeOfType<NotFoundResult>();
        }
        [Fact]
        public async Task Returns_same_response_as_what_AccessKey_service_returns_for_create()
        {
            var accessKeyRequest = new AccessKeyRequest() { ClientId = "ID_1024", ClientName = "Client_123", ProgramGroup = "CPG_1", Program = "Program_12", UpdatedBy = "Me" };
            var accessKeyResponse = new AccessKeyResponse() { ClientName = "Client_123", AccessKey = "1111:2222:3333", IsKeyActive = false, UpdatedBy = "Me" };
            _moqAccessKeyService.Setup(maks => maks.CreateKey(accessKeyRequest)).ReturnsAsync(accessKeyResponse);
            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
            var createKeyResponseFromController = await accessKeyController.Create(accessKeyRequest);
            var result = createKeyResponseFromController.Result as OkObjectResult;
            var resultValue = result.Value as AccessKeyResponse;
            ValidateCreateKeyResponse(accessKeyResponse, resultValue);
        }
        [Fact]
        public async Task Returns_bad_request_if_AccessKey_service_returns_null_for_create()
        {
            AccessKeyResponse accessKeyResponse = null;
            _moqAccessKeyService.Setup(maks => maks.CreateKey(It.IsAny<AccessKeyRequest>())).ReturnsAsync(accessKeyResponse);
            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
            var createKeyResponseFromController = await accessKeyController.Create(new AccessKeyRequest());
            createKeyResponseFromController.Result.Should().BeOfType<BadRequestResult>();
        }
        [Fact]
        public async Task Returns_same_response_as_what_AccessKey_service_returns_for_activate()
        {
            var activateKeyRequest = new ActivateKeyRequest() {UpdatedBy = "client" };
            var activateKeyResponse = new ActivateKeyResponse() { AccessKey = "key_1234", IsKeyActive = true, UpdatedBy = "client", LastUpdatedOn="26/01/1997" };
            _moqAccessKeyService.Setup(maks => maks.ActivateKey(activateKeyRequest, "key_1234")).ReturnsAsync(activateKeyResponse);
            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
            var activateKeyResponseFromController = await accessKeyController.Activate("key_1234", activateKeyRequest);
            var result = activateKeyResponseFromController.Result as OkObjectResult;
            var resultValue = result.Value as ActivateKeyResponse;
            ValidateActivateKeyResponse(activateKeyResponse, resultValue);

        }
        [Fact]
        public async Task Returns_bad_request_if_AccessKey_service_returns_null_for_activate()
        {
            ActivateKeyResponse activateKeyResponse = null;
            _moqAccessKeyService.Setup(maks => maks.ActivateKey(It.IsAny<ActivateKeyRequest>(),It.IsAny<string>())).ReturnsAsync(activateKeyResponse);
            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
            var activateKeyResponseFromController = await accessKeyController.Activate("Id_1024", new ActivateKeyRequest());
            activateKeyResponseFromController.Result.Should().BeOfType<BadRequestResult>();
        }
        [Fact]
        public async Task Returns_same_response_as_what_AccessKey_service_returns_for_deactivate()
        {
            var deactivateKeyRequest = new DeactivateKeyRequest() { UpdatedBy = "client" };
            var deactivateKeyResponse = new DeactivateKeyResponse() { AccessKey = "key_1234", IsKeyActive = false, UpdatedBy = "client", LastUpdatedOn = "26/01/1997" };
            _moqAccessKeyService.Setup(maks => maks.DeactivateKey(deactivateKeyRequest,"key_1234")).ReturnsAsync(deactivateKeyResponse);
            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
            var deactivateKeyResponseFromController = await accessKeyController.Deactivate("key_1234", deactivateKeyRequest);
            var result = deactivateKeyResponseFromController.Result as OkObjectResult;
            var resultValue = result.Value as DeactivateKeyResponse;
            ValidateDeactivateKeyResponse(deactivateKeyResponse, resultValue);
        }
        [Fact]
        public async Task Returns_bad_request_if_AccessKey_service_returns_null_for_deactivate()
        {
            DeactivateKeyResponse deactivateKeyResponse = null;
            _moqAccessKeyService.Setup(maks => maks.DeactivateKey(It.IsAny<DeactivateKeyRequest>(), It.IsAny<string>())).ReturnsAsync(deactivateKeyResponse);
            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
            var deactivateKeyResponseFromController = await accessKeyController.Deactivate("Id_1024", new DeactivateKeyRequest());
            deactivateKeyResponseFromController.Result.Should().BeOfType<BadRequestResult>();
        }
        private List<GetAllKeysResponse> GetAllKeysResponseList()
        {
            var getAllKeysResponse = new List<GetAllKeysResponse>();
            getAllKeysResponse.Add(new GetAllKeysResponse() { ClientId = "1", ClientTenantId = "ab", ClientName = "abcd", ClientClassicId = "a1", CreatedOn = "26/01/1997", AccessKey = "abcd1", IsKeyActive = true, LastUpdatedOn = "12/11/2019", Program = "P1", ProgramGroup = "CPG1", ProgramId = "P123", UpdatedBy = "U1" });
            getAllKeysResponse.Add(new GetAllKeysResponse() { ClientId = "2", ClientTenantId = "cd", ClientName = "efgh", ClientClassicId = "b2", CreatedOn = "26/01/1997", AccessKey = "efgh2", IsKeyActive = false, LastUpdatedOn = "12/11/2019", Program = "P2", ProgramGroup = "CPG2", ProgramId = "P456", UpdatedBy = "U2" });
            getAllKeysResponse.Add(new GetAllKeysResponse() { ClientId = "3", ClientTenantId = "ef", ClientName = "ijkl", ClientClassicId = "c3", CreatedOn = "26/01/1997", AccessKey = "ijkl3", IsKeyActive = true, LastUpdatedOn = "12/11/2019", Program = "P3", ProgramGroup = "CPG3", ProgramId = "P789", UpdatedBy = "U3" });
            getAllKeysResponse.Add(new GetAllKeysResponse() { ClientId = "4", ClientTenantId = "gh", ClientName = "mnop", ClientClassicId = "d4", CreatedOn = "26/01/1997", AccessKey = "mnop4", IsKeyActive = true, LastUpdatedOn = "12/11/2019", Program = "P4", ProgramGroup = "CPG4", ProgramId = "P987", UpdatedBy = "U4" });
            return getAllKeysResponse;
        }
        private void ValidateGetAllResponse(List<GetAllKeysResponse> getAllKeysResponse, List<GetAllKeysResponse> resultValue)
        {
            Assert.NotNull(resultValue);
            for (int i = 0; i < getAllKeysResponse.Count; i++)
            {
                Assert.Equal(getAllKeysResponse[i].AccessKey, resultValue[i].AccessKey);
                Assert.Equal(getAllKeysResponse[i].ClientClassicId, resultValue[i].ClientClassicId);
                Assert.Equal(getAllKeysResponse[i].ClientId, resultValue[i].ClientId);
                Assert.Equal(getAllKeysResponse[i].ClientName, resultValue[i].ClientName);
                Assert.Equal(getAllKeysResponse[i].ClientTenantId, resultValue[i].ClientTenantId);
                Assert.Equal(getAllKeysResponse[i].CreatedOn, resultValue[i].CreatedOn);
                Assert.Equal(getAllKeysResponse[i].IsKeyActive, resultValue[i].IsKeyActive);
                Assert.Equal(getAllKeysResponse[i].LastUpdatedOn, resultValue[i].LastUpdatedOn);
                Assert.Equal(getAllKeysResponse[i].Program, resultValue[i].Program);
                Assert.Equal(getAllKeysResponse[i].ProgramGroup, resultValue[i].ProgramGroup);
                Assert.Equal(getAllKeysResponse[i].ProgramId, resultValue[i].ProgramId);
                Assert.Equal(getAllKeysResponse[i].UpdatedBy, resultValue[i].UpdatedBy);
            }
        }
        private void ValidateCreateKeyResponse(AccessKeyResponse accessKeyResponse, AccessKeyResponse resultValue)
        {
            Assert.NotNull(resultValue);
            Assert.Equal(accessKeyResponse.ClientName, resultValue.ClientName);
            Assert.Equal(accessKeyResponse.IsKeyActive, resultValue.IsKeyActive);
            Assert.Equal(accessKeyResponse.UpdatedBy, resultValue.UpdatedBy);
            Assert.Equal(accessKeyResponse.AccessKey, resultValue.AccessKey);
        }
        private void ValidateDeactivateKeyResponse(DeactivateKeyResponse deactivateKeyResponse, DeactivateKeyResponse resultValue)
        {
            Assert.NotNull(resultValue);
            Assert.Equal(deactivateKeyResponse.AccessKey, resultValue.AccessKey);
            Assert.Equal(deactivateKeyResponse.UpdatedBy, resultValue.UpdatedBy);
            Assert.Equal(deactivateKeyResponse.IsKeyActive, resultValue.IsKeyActive);
            Assert.Equal(deactivateKeyResponse.LastUpdatedOn, resultValue.LastUpdatedOn);
        }
        private void ValidateActivateKeyResponse(ActivateKeyResponse activateKeyResponse, ActivateKeyResponse resultValue)
        {
            Assert.NotNull(resultValue);
            Assert.Equal(activateKeyResponse.AccessKey, resultValue.AccessKey);
            Assert.Equal(activateKeyResponse.UpdatedBy, resultValue.UpdatedBy);
            Assert.Equal(activateKeyResponse.IsKeyActive, resultValue.IsKeyActive);
            Assert.Equal(activateKeyResponse.LastUpdatedOn, resultValue.LastUpdatedOn);
        }
    }
}