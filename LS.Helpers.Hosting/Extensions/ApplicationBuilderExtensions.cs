using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace LS.Helpers.Hosting.Extensions
{
    /// <summary>
    /// Extensions and middlewares for ApplicationBuilder
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Uses the angular middleware.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public static void UseAngularMiddleware(this IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    var indexFile = Path.Combine(env.ContentRootPath, "wwwroot", "index.html");
                    if (File.Exists(indexFile))
                    {
                        context.Response.StatusCode = 200;
                        const int bufferSize = 1024;
                        var buffer = new byte[bufferSize];
                        using (var indexFileStream = File.OpenRead(indexFile))
                        {
                            int bytesReaded;
                            context.Response.ContentLength = indexFileStream.Length;
                            context.Response.ContentType = "text/html";
                            while ((bytesReaded = indexFileStream.Read(buffer, 0, buffer.Length)) > 0 &&
                                   !context.RequestAborted.IsCancellationRequested)
                            {
                                await context.Response.Body.WriteAsync(buffer, 0, bytesReaded);
                                await context.Response.Body.FlushAsync();
                            }
                        }
                    }
                    return;
                }
                await next();
            });
        }
    }
}
