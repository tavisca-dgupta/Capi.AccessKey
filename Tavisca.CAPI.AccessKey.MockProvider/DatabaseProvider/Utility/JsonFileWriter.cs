using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

namespace Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider.Utility
{
    public class JsonFileWriter
    {
        public static Task<bool> WriteToJsonFile(List<GetAllKeysDataResponse> clients)
        {
            var convertedJson = JsonConvert.SerializeObject(clients, Formatting.Indented);
            string filepath = @"JsonFile/MockAccessKeyData.json";
            return Task.FromResult(Write(filepath, convertedJson));
            
        }

        private static bool Write(string filepath, string data)
        {
            try
            {
                File.WriteAllText(filepath, data);
                return true;
            }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            {
                throw new FileNotFoundException();
            }
        }
    }
}
