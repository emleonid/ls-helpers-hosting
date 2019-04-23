using System.Linq;
using LS.Helpers.Hosting.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LS.Helpers.Hosting.Attributes
{
    /// <summary>
    /// ValidateModelStateAttribute
    /// </summary>
    /// <seealso cref="ActionFilterAttribute" />
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <inheritdoc />
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var allErrors = context.ModelState
                    .Values
                    .SelectMany(v => v.Errors)
                    .Select(x=>new ErrorInfo(x.ErrorMessage))
                    .ToList();

                context.Result = new BadRequestObjectResult(
                    new ExecutionResult<object>(allErrors)); 
            }
        }
    }
}
