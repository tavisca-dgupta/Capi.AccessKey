using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.Core.Translator
{
    public static class ParameterStoreModelTranslator
    {
        public static ParameterStoreModel ToParameterStoreModel(this AccessKeyModel accessKeyModel)
        {
            if (accessKeyModel == null)
                return null;
            return new ParameterStoreModel()
            {
                Key = accessKeyModel.AccessKey,
                Value = accessKeyModel.ClientId
            };
        }
    }
}
