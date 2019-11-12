//using Xunit;
//using Tavisca.CAPI.AccessKey.Web.Controllers;
//using System.Threading.Tasks;
//using Moq;
//using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;
//using Tavisca.CAPI.AccessKey.Model.Interfaces;
//using System.Collections.Generic;
//using FluentAssertions;
//using Microsoft.AspNetCore.Mvc;

//namespace Tavisca.CAPI.AccessKey.UnitTest.ControllerTests
//{
//    public class AccessKeyControllerTests
//    {
//        private readonly Mock<IAccessKeyService> _moqAccessKeyService = new Mock<IAccessKeyService>();
//        [Fact]
//        public async Task Returns_same_response_as_what_AccessKey_service_returns_for_getall()
//        {
//            var getAllKeysResponse = GetAllKeysResponseList();
//            _moqAccessKeyService.Setup(maks => maks.GetAllKeys()).ReturnsAsync(getAllKeysResponse);
//            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
//            var getAllKeysResponseFromController = await accessKeyController.Get();
//            var result = getAllKeysResponseFromController.Result as OkObjectResult;
//            var resultValue = result.Value as List<GetAllKeysResponse>;
//            ValidateGetAllResponse(getAllKeysResponse, resultValue);
//        }
//        [Fact]
//        public async Task Returns_not_found_if_AccessKey_service_returns_null_for_getall()
//        {
//            List<GetAllKeysResponse> getAllKeysResponse = null;
//            _moqAccessKeyService.Setup(maks => maks.GetAllKeys()).ReturnsAsync(getAllKeysResponse);
//            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
//            var getAllKeysResponseFromController = await accessKeyController.Get();
//            getAllKeysResponseFromController.Result.Should().BeOfType<NotFoundResult>();
//        }
//        [Fact]
//        public async Task Returns_same_response_as_what_AccessKey_service_returns_for_create()
//        {
//            var accessKeyRequest = new AccessKeyRequest() { ClientId = "ID_1024", ClientName = "Client_123", ProgramGroup = "CPG_1", Program = "Program_12", UpdatedBy = "Me" };
//            var accessKeyResponse = new AccessKeyResponse() { ClientName = "Client_123", AccessKey = "1111:2222:3333", IskeyActive = false, UpdatedBy = "Me" };
//            _moqAccessKeyService.Setup(maks => maks.CreateKey(accessKeyRequest)).ReturnsAsync(accessKeyResponse);
//            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
//            var createKeyResponseFromController = await accessKeyController.Create(accessKeyRequest);
//            var result = createKeyResponseFromController.Result as OkObjectResult;
//            var resultValue = result.Value as AccessKeyResponse;
//            ValidateCreateKeyResponse(accessKeyResponse, resultValue);
//        }
//        [Fact]
//        public async Task Returns_bad_request_if_AccessKey_service_returns_null_for_create()
//        {
//            AccessKeyResponse accessKeyResponse = null;
//            _moqAccessKeyService.Setup(maks => maks.CreateKey(It.IsAny<AccessKeyRequest>())).ReturnsAsync(accessKeyResponse);
//            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
//            var createKeyResponseFromController = await accessKeyController.Create(new AccessKeyRequest());
//            createKeyResponseFromController.Result.Should().BeOfType<BadRequestResult>();
//        }
//        [Fact]
//        public async Task Returns_same_response_as_what_AccessKey_service_returns_for_activate()
//        {
//            var activateKeyRequest = new ActivateKeyRequest() { AccessKey = "key_1234", IskeyActive = true, ClientId = "Id_1024", ClientName = "Client_1234", UpdatedBy = "client" };
//            var activateKeyResponse = new ActivateKeyResponse() { AccessKey = "key_1234", IskeyActive = true, ClientName = "Client_1234", UpdatedBy = "client" };
//            _moqAccessKeyService.Setup(maks => maks.ActivateKey(activateKeyRequest)).ReturnsAsync(activateKeyResponse);
//            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
//            var activateKeyResponseFromController = await accessKeyController.Activate("Id_1024", activateKeyRequest);
//            var result = activateKeyResponseFromController.Result as OkObjectResult;
//            var resultValue = result.Value as ActivateKeyResponse;
//            ValidateActivateKeyResponse(activateKeyResponse, resultValue);

//        }
//        [Fact]
//        public async Task Returns_bad_request_if_AccessKey_service_returns_null_for_activate()
//        {
//            ActivateKeyResponse activateKeyResponse = null;
//            _moqAccessKeyService.Setup(maks => maks.ActivateKey(It.IsAny<ActivateKeyRequest>())).ReturnsAsync(activateKeyResponse);
//            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
//            var activateKeyResponseFromController = await accessKeyController.Activate("Id_1024", new ActivateKeyRequest());
//            activateKeyResponseFromController.Result.Should().BeOfType<BadRequestResult>();
//        }
//        [Fact]
//        public async Task Returns_same_response_as_what_AccessKey_service_returns_for_deactivate()
//        {
//            var deactivateKeyRequest = new DeactivateKeyRequest() { AccessKey = "key_1234", IskeyActive = false, ClientId = "Id_1024", ClientName = "Client_1234", UpdatedBy = "client" };
//            var deactivateKeyResponse = new DeactivateKeyResponse() { AccessKey = "key_1234", IskeyActive = false, ClientId = "Id_1024", ClientName = "Client_1234", UpdatedBy = "client" };
//            _moqAccessKeyService.Setup(maks => maks.DeactivateKey(deactivateKeyRequest)).ReturnsAsync(deactivateKeyResponse);
//            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
//            var deactivateKeyResponseFromController = await accessKeyController.Deactivate("Id_1024", deactivateKeyRequest);
//            var result = deactivateKeyResponseFromController.Result as OkObjectResult;
//            var resultValue = result.Value as DeactivateKeyResponse;
//            ValidateDeactivateKeyResponse(deactivateKeyResponse, resultValue);
//        }
//        [Fact]
//        public async Task Returns_bad_request_if_AccessKey_service_returns_null_for_deactivate()
//        {
//            DeactivateKeyResponse deactivateKeyResponse = null;
//            _moqAccessKeyService.Setup(maks => maks.DeactivateKey(It.IsAny<DeactivateKeyRequest>())).ReturnsAsync(deactivateKeyResponse);
//            var accessKeyController = new AccessKeyController(_moqAccessKeyService.Object);
//            var deactivateKeyResponseFromController = await accessKeyController.Deactivate("Id_1024", new DeactivateKeyRequest());
//            deactivateKeyResponseFromController.Result.Should().BeOfType<BadRequestResult>();
//        }
//        private List<GetAllKeysResponse> GetAllKeysResponseList()
//        {
//            var getAllKeysResponse = new List<GetAllKeysResponse>();
//            getAllKeysResponse.Add(new GetAllKeysResponse() { AccessKey = "key_1", ClientName = "ABC", IskeyActive = true, UpdatedBy = "client_1" });
//            getAllKeysResponse.Add(new GetAllKeysResponse() { AccessKey = "key_2", ClientName = "DEF", IskeyActive = false, UpdatedBy = "client_2" });
//            getAllKeysResponse.Add(new GetAllKeysResponse() { AccessKey = "key_3", ClientName = "GHI", IskeyActive = true, UpdatedBy = "client_3" });
//            return getAllKeysResponse;
//        }
//        private void ValidateGetAllResponse(List<GetAllKeysResponse> getAllKeysResponse, List<GetAllKeysResponse> resultValue)
//        {
//            Assert.NotNull(resultValue);
//            for (int i = 0; i < getAllKeysResponse.Count; i++)
//            {
//                getAllKeysResponse[i].ClientName = resultValue[i].ClientName;
//                getAllKeysResponse[i].AccessKey = resultValue[i].AccessKey;
//                getAllKeysResponse[i].IskeyActive = resultValue[i].IskeyActive;
//                getAllKeysResponse[i].UpdatedBy = resultValue[i].UpdatedBy;
//            }
//        }
//        private void ValidateCreateKeyResponse(AccessKeyResponse accessKeyResponse, AccessKeyResponse resultValue)
//        {
//            Assert.NotNull(resultValue);
//            Assert.Equal(accessKeyResponse.ClientName, resultValue.ClientName);
//            Assert.Equal(accessKeyResponse.IskeyActive, resultValue.IskeyActive);
//            Assert.Equal(accessKeyResponse.UpdatedBy, resultValue.UpdatedBy);
//            Assert.Equal(accessKeyResponse.AccessKey, resultValue.AccessKey);
//        }
//        private void ValidateDeactivateKeyResponse(DeactivateKeyResponse deactivateKeyResponse, DeactivateKeyResponse resultValue)
//        {
//            Assert.NotNull(resultValue);
//            Assert.Equal(deactivateKeyResponse.AccessKey, resultValue.AccessKey);
//            Assert.Equal(deactivateKeyResponse.IskeyActive, resultValue.IskeyActive);
//            Assert.Equal(deactivateKeyResponse.ClientName, resultValue.ClientName);
//            Assert.Equal(deactivateKeyResponse.UpdatedBy, resultValue.UpdatedBy);
//            Assert.Equal(deactivateKeyResponse.ClientId, resultValue.ClientId);
//        }
//        private void ValidateActivateKeyResponse(ActivateKeyResponse activateKeyResponse, ActivateKeyResponse resultValue)
//        {
//            Assert.NotNull(resultValue);
//            Assert.Equal(activateKeyResponse.AccessKey, resultValue.AccessKey);
//            Assert.Equal(activateKeyResponse.IskeyActive, resultValue.IskeyActive);
//            Assert.Equal(activateKeyResponse.ClientName, resultValue.ClientName);
//            Assert.Equal(activateKeyResponse.UpdatedBy, resultValue.UpdatedBy);
//        }
//    }
//}