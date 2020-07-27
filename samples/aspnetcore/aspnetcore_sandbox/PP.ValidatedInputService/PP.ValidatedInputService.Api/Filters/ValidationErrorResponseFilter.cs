using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PP.ValidatedInputService.Api.DTOs;

namespace PP.ValidatedInputService.Api.Filters
{
    public class ValidationErrorResponseFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var validationErrors = context.ModelState.SelectMany(pair => pair.Value.Errors.Select(error => new ApiValidationError {Field = pair.Key, Message = error.ErrorMessage}));
                context.Result = new BadRequestObjectResult(new ApiResponse<object>(validationErrors.ToArray()));
            }
        }
    }
}