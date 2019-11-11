using System;
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
        public static BaseApplicationException ParameterStoreNotResponding()
        {
            return new CustomException(ErrorCodes.ParameterStoreNotResponding, ErrorMessages.ParameterStoreNotResponding, HttpStatusCode.InternalServerError);
        }

        public static BaseApplicationException ParameterStoreDeletionFailed()
        {
            return new CustomException(ErrorCodes.ParameterStoreDeletionFailed, ErrorMessages.ParameterStoreDeletionFailed, HttpStatusCode.InternalServerError);
        }

        public static BaseApplicationException ParameterStoreAdditionFailed()
        {
            return new CustomException(ErrorCodes.ParameterStoreAdditionFailed, ErrorMessages.ParameterStoreAdditionFailed, HttpStatusCode.InternalServerError);
        }

        public static BaseApplicationException ParameterStoreCommunicationError()
        {
            return new CustomException(ErrorCodes.ParameterStoreCommunicationError, ErrorMessages.ParameterStoreCommunicationError, HttpStatusCode.InternalServerError);
        }
    }
}
