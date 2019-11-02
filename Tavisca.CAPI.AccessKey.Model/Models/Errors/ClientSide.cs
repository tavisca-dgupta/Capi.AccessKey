using System.Net;
using Tavisca.Platform.Common.Models;

namespace Tavisca.CAPI.AccessKey.Model.Models.Errors
{
    public static class ClientSide
    {
        public static BaseApplicationException KeyAlreadyExists()
        {
            return new CustomException(ErrorCodes.KeyAlreadyExists, ErrorMessages.KeyAlreadyExists, HttpStatusCode.BadRequest);
        }

        public static BaseApplicationException KeyIsAlreadyActivated()
        {
            return new CustomException(ErrorCodes.KeyIsAlreadyActivated, ErrorMessages.KeyIsAlreadyActivated, HttpStatusCode.BadRequest);
        }

        public static BaseApplicationException KeyIsAlreadyDeactivated()
        {
            return new CustomException(ErrorCodes.KeyIsAlreadyDeactivated, ErrorMessages.KeyIsAlreadyDeactivated, HttpStatusCode.BadRequest);
        }

        public static BaseApplicationException ClientNotFound()
        {
            return new CustomException(ErrorCodes.ClientNotFound, ErrorMessages.ClientNotFound, HttpStatusCode.BadRequest);
        }
    }
}
