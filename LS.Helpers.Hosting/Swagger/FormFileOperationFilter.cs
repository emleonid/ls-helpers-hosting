//namespace LS.Helpers.Hosting.Swagger
//{
//    using System.Collections.Generic;
//    using System.Linq;
//    using JetBrains.Annotations;
//    using Microsoft.AspNetCore.Mvc.ApiExplorer;
//    using Swashbuckle.AspNetCore.Swagger;
//    using Swashbuckle.AspNetCore.SwaggerGen;

//    /// <summary>
//    /// FormFileOperationFilter
//    /// </summary>
//    /// <seealso cref="IOperationFilter" />
//    [UsedImplicitly]
//    public class FormFileOperationFilter : IOperationFilter
//    {
//        /// <summary>
//        /// Applies the specified operation.
//        /// </summary>
//        /// <param name="operation">The operation.</param>
//        /// <param name="schemaRegistry">The schema registry.</param>
//        /// <param name="apiDescription">The API description.</param>
//        public void Apply(Operation operation, ISchemaRegistry schemaRegistry, ApiDescription apiDescription)
//        {
//            var requestAttributes =
//                apiDescription.ActionAttributes().Where(x => x is SwaggerFormAttribute);

//            foreach (SwaggerFormAttribute attr in requestAttributes)
//            {
//                var list = new List<IParameter>
//                {
//                    new NonBodyParameter
//                    {
//                        Name = "File",
//                        In = "formData",
//                        Description = "Upload file.",
//                        Required = true,
//                        Type = "file"
//                    }
//                };
//                if (operation.Parameters != null)
//                {
//                    foreach (var parameter in list)
//                    {
//                        operation.Parameters.Add(parameter);
//                    }
//                }
//                else
//                {
//                    operation.Parameters = list;
//                }

//                operation.Consumes.Add("multipart/form-data");
//            }
//        }

//        /// <summary>
//        /// Applies the specified operation.
//        /// </summary>
//        /// <param name="operation">The operation.</param>
//        /// <param name="context">The context.</param>
//        public void Apply(Operation operation, OperationFilterContext context)
//        {
//            Apply(operation, context.SchemaRegistry, context.ApiDescription);
//        }
//    }
//}
