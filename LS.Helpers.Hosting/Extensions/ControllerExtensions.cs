namespace LS.Helpers.Hosting.Extensions
{
    using JetBrains.Annotations;
    using API;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// ControllerExtensions
    /// </summary>
    [UsedImplicitly]
    public static class ControllerExtensions
    {
        /// <summary>
        /// From the execution result.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="result">The result.</param>
        /// <returns>
        /// IActionResult
        /// </returns>
        public static IActionResult FromExecutionResult(this Controller controller, ExecutionResult result)
        {
            if (result.Success)
            {
                return controller.Ok(result);
            }

            return controller.BadRequest(result);
        }

        /// <summary>
        /// From the execution result.
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="controller">The controller.</param>
        /// <param name="result">The result.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// IActionResult
        /// </returns>
        public static IActionResult FromExecutionResult<T>(this Controller controller, ExecutionResult<T> result, object value = null)
        {
            if (result.Success)
            {
                return controller.Ok(value ?? result);
            }

            return controller.BadRequest(result);
        }
    }
}
