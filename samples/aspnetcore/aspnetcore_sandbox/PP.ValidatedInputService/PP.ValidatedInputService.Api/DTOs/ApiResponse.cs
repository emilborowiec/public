using System.Collections.Generic;

namespace PP.ValidatedInputService.Api.DTOs
{
    public class ApiResponse<T>
    {
        public static ApiResponse<object> Ok()
        {
            return new ApiResponse<object> { Status = ApiResponseStatus.SUCCESS };
        }
        
        public ApiResponse() {}

        public ApiResponse(ICollection<ApiValidationError> validationErrors)
        {
            this.Status = ApiResponseStatus.CLIENT_ERROR;
            this.Error = new ApiError(validationErrors);
        }

        public ApiResponse(T data)
        {
            this.Status = ApiResponseStatus.SUCCESS;
            this.Data = data;
        }

        public ApiResponseStatus Status { get; set; }
        public T Data { get; set; }
        public ApiError Error { get; set; }

    }
}