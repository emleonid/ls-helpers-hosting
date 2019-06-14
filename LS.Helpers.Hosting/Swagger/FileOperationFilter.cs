namespace LS.Helpers.Hosting.Swagger
{
    using System.Linq;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Http;
    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    /// FileOperationFilter
    /// </summary>
    /// <seealso cref="IOperationFilter" />
    [UsedImplicitly]
    public class FileOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Applies the specified operation.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="context">The context.</param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.ParameterDescriptions.Any(
                x => x.ModelMetadata.ContainerType == typeof(IFormFile)))
            {
                var list = operation.Parameters.Where(x => !x.Name.StartsWith("File.")).ToList();
                operation.Parameters.Clear();
                foreach (var parameter in list)
                {
                    operation.Parameters.Add(parameter);
                }
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "File",
                    In = "formData",
                    Description = "Upload file.",
                    Required = true,
                    Type = "file"
                });
                operation.Consumes.Add("multipart/form-data");
            }
        }
    }
}