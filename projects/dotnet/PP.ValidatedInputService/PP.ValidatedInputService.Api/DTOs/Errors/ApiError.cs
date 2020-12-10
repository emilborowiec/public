using System.Linq;
using System.Collections.Generic;

namespace PP.ValidatedInputService.Api.DTOs
{
    public class ApiError
    {
        public ApiError()
        {
            this.Message = "An unknown error has occurred";
            this.ApiErrorCode = ApiErrorCode.UNKNOWN_ERROR;
        }

        public ApiError(ApiErrorCode errorCode, string message) 
        {
            this.ApiErrorCode = errorCode;
            this.Message = message;
        }
        public ApiError(IEnumerable<ApiValidationError> validationErrors)
        {
            this.Message = "There are validation errors";
            this.ApiErrorCode = ApiErrorCode.VALIDATION_ERROR;
            this.ValidationErrors = validationErrors.ToArray();
        }

        public ApiErrorCode ApiErrorCode { get; set; }
        public string Message { get; set; }
        public ApiValidationError[] ValidationErrors { get; set; }
    }
}