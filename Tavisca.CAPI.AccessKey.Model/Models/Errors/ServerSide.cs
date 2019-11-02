using System.Net;
using Tavisca.Platform.Common.Models;

namespace Tavisca.CAPI.AccessKey.Model.Models.Errors
{
    public class ServerSide
    {
        public static BaseApplicationException AccessKeyNotGenerated()
        {
            return new CustomException(ErrorCodes.AccessKeyNotGenerated, ErrorMessages.AccessKeyNotGenerated, HttpStatusCode.InternalServerError);
        }
        public static BaseApplicationException AccesskeyNotActivated()
        {
            return new CustomException(ErrorCodes.AccessKeyNotActivated, ErrorMessages.AccessKeyNotActivated, HttpStatusCode.InternalServerError);
        }
        public static BaseApplicationException AccessKeyNotDeactivated()
        {
            return new CustomException(ErrorCodes.AccessKeyNotDeactivated, ErrorMessages.AccessKeyNotDeactivated, HttpStatusCode.InternalServerError);
        }
    }
}
