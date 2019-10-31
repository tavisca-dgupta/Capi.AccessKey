using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Model.Models;

namespace Tavisca.CAPI.AccessKey.Model.Interfaces
{
    public interface IActivateKey
    {
        Task<AccessKeyModel> Activate(AccessKeyModel accessKey);
    }
}
