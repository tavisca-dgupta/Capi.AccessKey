//using System;
//using Tavisca.CAPI.AccessKey.Model.Models;
//using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;
//using Tavisca.CAPI.AccessKey.Services.Tanslator;
//using Xunit;

//namespace Tavisca.CAPI.AccessKey.UnitTest.ServiceTranslatorTests
//{
//    public class DeactivateKeyRequestTranslatorTests
//    {
//        [Fact]
//        public void DeactivateKeyRequestTranslator_Success()
//        {
//            var deactivateKeyRequest = GetDeactivateKeyRequest();
//            var accessKeyModel = deactivateKeyRequest.ToAccessKeyModel();
//            ValidateTranslation(deactivateKeyRequest,accessKeyModel);
//        }

//        private void ValidateTranslation(DeactivateKeyRequest deactivateKeyRequest, AccessKeyModel accessKeyModel)
//        {
//            Assert.Equal(deactivateKeyRequest.ClientName, accessKeyModel.ClientName);
//            Assert.Equal(deactivateKeyRequest.AccessKey, accessKeyModel.AccessKey);
//            Assert.Equal(deactivateKeyRequest.IskeyActive, accessKeyModel.IskeyActive);
//            Assert.Equal(deactivateKeyRequest.UpdatedBy, accessKeyModel.UpdatedBy);
//            Assert.Equal(deactivateKeyRequest.ClientId, accessKeyModel.ClientId);
//        }

//        private DeactivateKeyRequest GetDeactivateKeyRequest()
//        {
//            return new DeactivateKeyRequest()
//            {
//                ClientName = "Axis",
//                AccessKey = "Axis_1234",
//                IskeyActive = true,
//                //UpdatedBy = "AxisManager",
//                ClientId = "AxisID"
//            };
//        }
//    }
//}
