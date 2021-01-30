using Common.Application.Exceptions;
using Common.Domain;
using Microsoft.AspNetCore.Diagnostics;
using System;

namespace Sandbox.Shared.Api.ErrorHandling.Errors
{
    public class ErrorFactory
    {
        public Error Create(IExceptionHandlerFeature contextFeature)
        {
            Error error = contextFeature.Error switch
            {
                NotFoundException notFoundException
                => notFoundException.Errors == null
                    ? new NotFoundError(notFoundException.Message)
                    : new NotFoundError(notFoundException.Message,
                        new ErrorDetailsCollection(notFoundException.Errors)),

                UnauthorizedAccessException unauthorizedAccessException
                => new UnauthorizedAccessError(unauthorizedAccessException.Message),

                AppException appException
                => new AppError(appException.Message, new ErrorDetailsCollection(appException.Errors)),

                DomainException domainException
                => new DomainError(domainException.Message, new ErrorDetailsCollection(domainException.Errors)),
                _
                => new InternalServerError(contextFeature.Error.Message)
            };
            return error;
        }
    }
}