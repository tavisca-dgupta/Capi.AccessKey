using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataApiModel;

namespace Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider.Utility
{
    public class JsonFileWriter
    {
        private static readonly string _basePath = Assembly.GetExecutingAssembly().GetName().Name + ".DatabaseProvider.JsonFile.";
        private static string _filename = "MockAccessKeyData.json";

        public static Task<bool> WriteToJsonFile(List<GetAllKeysDataResponse> clients)
        {
            string filepath = "C:/Tavisca.CAPI.AccessKey/Tavisca.CAPI.AccessKey.MockProvider/DatabaseProvider/JsonFile/MockAccessKeyData.json";
            //using (var filepath = typeof(JsonFileWriter).Assembly.GetManifestResourceStream(string.Concat(_basePath, _filename)))
            //{
            //    var convertedJson = JsonConvert.SerializeObject(clients, Formatting.Indented);
            //    return Task.FromResult(Write(filepath, convertedJson));
            //}
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
            catch (Exception e)
            {
                throw new FileNotFoundException();
            }

            //using (StreamWriter streamWriter = new StreamWriter(filepath))
            //{

            //    streamWriter.WriteLine(data);
            //    //r.WriteAsync(data);
            //    return true;
            //}
        }
    }
}
