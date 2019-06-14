namespace LS.Helpers.Hosting.Attributes
{
    using System;
    using System.Linq;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    /// <summary>
    /// DisableFormValueModelBinding
    /// </summary>
    /// <seealso cref="System.Attribute" />
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IResourceFilter" />
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    [UsedImplicitly]
    public class DisableFormValueModelBindingAttribute : Attribute, IResourceFilter
    {
        /// <summary>
        /// Executes the resource filter. Called before execution of the remainder of the pipeline.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext" />.</param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var formValueProviderFactory = context.ValueProviderFactories
                .OfType<FormValueProviderFactory>()
                .FirstOrDefault();
            if (formValueProviderFactory != null)
            {
                context.ValueProviderFactories.Remove(formValueProviderFactory);
            }
            var jqueryFormValueProviderFactory = context.ValueProviderFactories
                .OfType<JQueryFormValueProviderFactory>()
                .FirstOrDefault();
            if (jqueryFormValueProviderFactory != null)
            {
                context.ValueProviderFactories.Remove(jqueryFormValueProviderFactory);
            }
        }

        /// <summary>
        /// Executes the resource filter. Called after execution of the remainder of the pipeline.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext" />.</param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
