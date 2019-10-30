using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;
using Tavisca.CAPI.AccessKey.Model.Models;
using System.Threading.Tasks;

namespace Tavisca.CAPI.AccessKey.MockProvider.ParameterStoreProvider.Utility
{
    public class ParameterStore
    {
        private static readonly string _parameterStorePath = "C:/Tavisca.Capi.AccessKey/Tavisca.CAPI.AccessKey.MockProvider/ParameterStoreProvider/JsonFile/MockParameterStoreData.json";
        public static Task<bool> AddKey(ParameterStoreModel parameterStore)
        {
            try
            {
                var parameterStoreAccessKeyList = JsonConvert.DeserializeObject<List<ParameterStoreModel>>(File.ReadAllText(_parameterStorePath));
                parameterStoreAccessKeyList.Add(parameterStore);
                string newParameterStore = JsonConvert.SerializeObject(parameterStoreAccessKeyList, Formatting.Indented);
                File.WriteAllText(_parameterStorePath, newParameterStore);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
                return Task.FromResult(false);
            }

        }

        public static Task<bool> DeleteKey(string accessKey)
        {
            try
            {
                var parameterStoreAccessKeyList = JsonConvert.DeserializeObject<List<ParameterStoreModel>>(File.ReadAllText(_parameterStorePath));
                parameterStoreAccessKeyList.RemoveAll(key => key.AccessKey == accessKey);
                string newParameterStore = JsonConvert.SerializeObject(parameterStoreAccessKeyList, Formatting.Indented);
                File.WriteAllText(_parameterStorePath, newParameterStore);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
                return Task.FromResult(false);
            }
        }
    }
}
