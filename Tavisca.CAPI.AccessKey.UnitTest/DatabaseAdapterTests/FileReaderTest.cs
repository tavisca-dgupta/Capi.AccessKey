using Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider.Utility;
using Xunit;

namespace Tavisca.CAPI.AccessKey.UnitTest.DatabaseAdapterTests
{
    public class FileReaderTest
    {
        [Fact]
        public void Read_List_From_Json_File_Success()
        {
            var json = JsonFileReader.ReadAllJsonObject("MockAccessKeyData.json");
            //Assert.Equal()
        }
        
    }
}
