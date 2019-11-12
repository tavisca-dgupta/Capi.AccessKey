//using Tavisca.CAPI.AccessKey.MockProvider.Tanslators;
//using Tavisca.CAPI.AccessKey.Model.Models;
//using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;
//using Xunit;

//namespace Tavisca.CAPI.AccessKey.UnitTest.AdaptorTranslatorTests
//{
//    public class ActivateKeyDataResponseTranslatorTests
//    {
//        [Fact]
//        public void ActivateKeyDataResponseTranslator_Success()
//        {
//            var activateKeyDataResponse = GetActivateKeyDataResponse();
//            var accessKeyModel = activateKeyDataResponse.ToAccessKeyModel();
//            ValidateTranslation(activateKeyDataResponse,accessKeyModel);
//        }

//        private void ValidateTranslation(ActivateKeyDataResponse activateKeyDataResponse, AccessKeyModel accessKeyModel)
//        {
//            Assert.Equal(activateKeyDataResponse.UpdatedBy,accessKeyModel.UpdatedBy);
//            Assert.Equal(activateKeyDataResponse.AccessKey, accessKeyModel.AccessKey);
//            Assert.Equal(activateKeyDataResponse.ClientId, accessKeyModel.ClientId);
//            Assert.Equal(activateKeyDataResponse.ClientName, accessKeyModel.ClientName);
//            Assert.Equal(activateKeyDataResponse.Program, accessKeyModel.Program);
//            Assert.Equal(activateKeyDataResponse.ProgramGroup, accessKeyModel.ProgramGroup);
//            Assert.Equal(activateKeyDataResponse.IskeyActive, accessKeyModel.IskeyActive);
//        }

//        private ActivateKeyDataResponse GetActivateKeyDataResponse()
//        {
//            return new ActivateKeyDataResponse()
//            {
//                AccessKey="1234_abcd",
//                IskeyActive=true,
//                ClientId="1084",
//                ClientName="Bank Of Baroda",
//                CreateDate="26-01-1997",
//                Program="Neo Card",
//                ProgramGroup="CPG Asia",
//                UpdateDate="30-01-2019",
//                UpdatedBy="manager"
//            };
//        }
//    }
//}
