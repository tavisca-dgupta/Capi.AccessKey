using System.Net;
using Tavisca.Platform.Common.Models;

namespace Tavisca.CAPI.AccessKey.Model.Models.Errors
{
    public class CustomException : BaseApplicationException
    {
        public CustomException(string code, string message, HttpStatusCode httpStatusCode) : base(code, message, httpStatusCode) { }
    }
}
