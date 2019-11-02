using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

namespace Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider.Utility
{
    public class JsonFileWriter
    {
        public static Task<bool> WriteToJsonFile(List<GetAllKeysDataResponse> clients)
        {
            string filepath = "C:/Tavisca.CAPI.AccessKey/Tavisca.CAPI.AccessKey.MockProvider/DatabaseProvider/JsonFile/MockAccessKeyData.json";
            var convertedJson = JsonConvert.SerializeObject(clients, Formatting.Indented);
            return Task.FromResult(Write(filepath, convertedJson));
        }

        private static bool Write(string filepath, string data)
        {
            try
            {
                File.WriteAllText(filepath, data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
