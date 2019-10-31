using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Tavisca.Platform.Common.Models;

namespace Tavisca.CAPI.AccessKey.Model.Models.Errors
{
    public class BadRequestException : BaseApplicationException
    {
        public BadRequestException(string code, string message, HttpStatusCode httpStatusCode) : base(code, message, httpStatusCode) { }
    }
}
