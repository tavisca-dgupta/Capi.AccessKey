//using Tavisca.CAPI.AccessKey.MockProvider.Tanslator;
//using Tavisca.CAPI.AccessKey.Model.Models;
//using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;
//using Xunit;

//namespace Tavisca.CAPI.AccessKey.UnitTest.AdaptorTranslatorTests
//{
//    public class GetAllKeysDataResponseTranslatorTests
//    {
//        [Fact]
//        public void GetAllKeysDataResponseTranslator_Success()
//        {
//            var getAllKeysDataResponse = GetInstanceGetAllKeysDataResponse();
//            var accessKeyModel = getAllKeysDataResponse.ToAccessKeyModel();
//            ValidateTranslation(getAllKeysDataResponse,accessKeyModel);
//        }

//        private void ValidateTranslation(GetAllKeysDataResponse getAllKeysDataResponse, AccessKeyModel accessKeyModel)
//        {
//            Assert.Equal(getAllKeysDataResponse.ClientId,accessKeyModel.ClientId);
//            Assert.Equal(getAllKeysDataResponse.ProgramGroup,accessKeyModel.ProgramGroup);
//            Assert.Equal(getAllKeysDataResponse.Program, accessKeyModel.Program);
//            Assert.Equal(getAllKeysDataResponse.UpdatedBy,accessKeyModel.UpdatedBy);
//            Assert.Equal(getAllKeysDataResponse.AccessKey, accessKeyModel.AccessKey);
//            Assert.Equal(getAllKeysDataResponse.ClientName, accessKeyModel.ClientName);
//            Assert.Equal(getAllKeysDataResponse.IskeyActive, accessKeyModel.IskeyActive);
//        }

//        private GetAllKeysDataResponse GetInstanceGetAllKeysDataResponse()
//        {
//            return new GetAllKeysDataResponse()
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
