//using System;
//using Tavisca.CAPI.AccessKey.Model.Models;
//using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;
//using Tavisca.CAPI.AccessKey.Services.Tanslator;
//using Xunit;

//namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTranslatorTests
//{
//    public class ActivateKeyRequestToAccessKeyModelTranslatorTests
//    {
//        [Fact]
//        public void ActivateKeyRequestToAccessKeyModelTranslator_Success()
//        {
//            var activateKeyRequest = GetActivateKeyRequest();
//            var accessKeyModel = activateKeyRequest.ToAccessKeyModel();
//            ValidateRequest(activateKeyRequest,accessKeyModel);
//        }

//        private void ValidateRequest(ActivateKeyRequest activateKeyRequest, AccessKeyModel accessKeyModel)
//        {
//            Assert.Equal(activateKeyRequest.ClientName, accessKeyModel.ClientName);
//            Assert.Equal(activateKeyRequest.AccessKey, accessKeyModel.AccessKey);
//            Assert.Equal(activateKeyRequest.IskeyActive, accessKeyModel.IskeyActive);
//            Assert.Equal(activateKeyRequest.UpdatedBy, accessKeyModel.UpdatedBy);
//            Assert.Equal(activateKeyRequest.ClientId, accessKeyModel.ClientId);
//        }

//        private ActivateKeyRequest GetActivateKeyRequest()
//        {
//            return new ActivateKeyRequest()
//            {
//                ClientName = "Axis",
//                AccessKey="Axis_1234",
//                IskeyActive=true,
//                UpdatedBy="AxisManager",
//                ClientId="AxisID"
//            };
//        }
//    }
//}
