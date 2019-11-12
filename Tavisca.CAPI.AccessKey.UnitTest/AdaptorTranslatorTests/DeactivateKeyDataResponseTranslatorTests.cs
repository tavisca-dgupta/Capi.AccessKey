//using Tavisca.CAPI.AccessKey.MockProvider.Tanslators;
//using Tavisca.CAPI.AccessKey.Model.Models;
//using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;
//using Xunit;

//namespace Tavisca.CAPI.AccessKey.UnitTest.AdaptorTranslatorTests
//{
//    public class DeactivateKeyDataResponseTranslatorTests
//    {
//        [Fact]
//        public void DeactivateKeyDataResponseTranslator_Success()
//        {
//            var deactivateKeyDataResponse = GetDeactivateKeyDataResponse();
//            var accessKeyModel = deactivateKeyDataResponse.ToAccessKeyModel();
//            ValidateTranslation(deactivateKeyDataResponse, accessKeyModel);
//        }

//        private void ValidateTranslation(DeactivateKeyDataResponse deactivateKeyDataResponse, AccessKeyModel accessKeyModel)
//        {
//            Assert.Equal(deactivateKeyDataResponse.ClientId, accessKeyModel.ClientId);
//            Assert.Equal(deactivateKeyDataResponse.ClientName, accessKeyModel.ClientName);
//            Assert.Equal(deactivateKeyDataResponse.AccessKey, accessKeyModel.AccessKey);
//            Assert.Equal(deactivateKeyDataResponse.IskeyActive, accessKeyModel.IskeyActive);
//            Assert.Equal(deactivateKeyDataResponse.Program, accessKeyModel.Program);
//            Assert.Equal(deactivateKeyDataResponse.ProgramGroup, accessKeyModel.ProgramGroup);
//            Assert.Equal(deactivateKeyDataResponse.UpdatedBy, accessKeyModel.UpdatedBy);
//        }

//        private DeactivateKeyDataResponse GetDeactivateKeyDataResponse()
//        {
//            return new DeactivateKeyDataResponse()
//            {
//                AccessKey = "1234_abcd",
//                IskeyActive = true,
//                ClientId = "1084",
//                ClientName = "Bank Of Baroda",
//                CreateDate = "26-01-1997",
//                Program = "Neo Card",
//                ProgramGroup = "CPG Asia",
//                UpdateDate = "30-01-2019",
//                UpdatedBy = "manager"
//            };
//        }
//    }
//}
