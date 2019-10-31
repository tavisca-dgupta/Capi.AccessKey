using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Tavisca.Platform.Common.Models;

namespace Tavisca.CAPI.AccessKey.Model.Models.Errors
{
    public static class ClientSide
    {
        public static BaseApplicationException KeyAlreadyExists()
        {
            return new BadRequestException(ErrorCodes.KeyAlreadyExists, ErrorMessages.KeyAlreadyExists, HttpStatusCode.BadRequest);
        }

        public static BaseApplicationException KeyIsAlreadyActivated()
        {
            return new BadRequestException(ErrorCodes.KeyIsAlreadyActivated, ErrorMessages.KeyIsAlreadyActivated, HttpStatusCode.BadRequest);
        }

        public static BaseApplicationException KeyIsAlreadyDeactivated()
        {
            return new BadRequestException(ErrorCodes.KeyIsAlreadyDeactivated, ErrorMessages.KeyIsAlreadyDeactivated, HttpStatusCode.BadRequest);
        }

        public static BaseApplicationException ClientNotFound()
        {
            return new BadRequestException(ErrorCodes.ClientNotFound, ErrorMessages.ClientNotFound, HttpStatusCode.BadRequest);
        }
    }
}
