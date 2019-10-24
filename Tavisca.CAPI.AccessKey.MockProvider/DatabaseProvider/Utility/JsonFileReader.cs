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
    public class JsonFileReader
    {
        private static readonly string  _basePath = Assembly.GetExecutingAssembly().GetName().Name + ".DatabaseProvider.JsonFile.";

        public static Task<List<GetAllKeysDataResponse>> ReadAllJsonObject(string filename)
        {
            //using (var filepath = typeof(JsonFileReader).Assembly.GetManifestResourceStream(string.Concat(_basePath, filename)))
            //{

            //    var json= ReadAllText(filepath);
            //    List<GetAllKeysDataResponse> keyList = new List<GetAllKeysDataResponse>();
            //    if (json!=null)
            //    {
            //        keyList = JsonConvert.DeserializeObject<List<GetAllKeysDataResponse>>(json);
            //    }

            //    return Task.FromResult(keyList);
            //}
            string filepath = "C:/Tavisca.CAPI.AccessKey/Tavisca.CAPI.AccessKey.MockProvider/DatabaseProvider/JsonFile/MockAccessKeyData.json";
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
            using (StreamReader r = new StreamReader(filepath))
            {
                    var json = r.ReadToEnd();
                    return json;
            }
           
        }
    }
}
