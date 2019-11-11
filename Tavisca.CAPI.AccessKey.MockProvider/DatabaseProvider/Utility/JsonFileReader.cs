using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

namespace Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider.Utility
{
    public class JsonFileReader
    {
        public static Task<List<GetAllKeysDataResponse>> ReadAllJsonObject(string filename)
        {
            string filepath = @"C:\Users\ankadam\Desktop\Backend\refactor\Capi.AccessKey\Tavisca.CAPI.AccessKey.MockProvider\DatabaseProvider\JsonFile\MockAccessKeyData.json";
            var json = ReadAllText(filepath);
            List<GetAllKeysDataResponse> keyList = new List<GetAllKeysDataResponse>();
            if (json != null)
            {
                keyList = JsonConvert.DeserializeObject<List<GetAllKeysDataResponse>>(json);
            }

            return Task.FromResult(keyList);
        }

        private static string ReadAllText(string filepath)
        {
            try
            {
                using (StreamReader r = new StreamReader(filepath))
                {
                    var json = r.ReadToEnd();
                    return json;
                }
            }
            catch
            {
                return null;
            }
            
           
        }
    }
}
