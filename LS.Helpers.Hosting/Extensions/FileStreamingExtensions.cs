namespace LS.Helpers.Hosting.Extensions
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Enums;
    using Helpers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Net.Http.Headers;
    using Models;

    /// <summary>
    /// HttpRequest extensions for file streaming upload
    /// </summary>
    public static class FileStreamingExtensions
    {
        /// <summary>
        /// Streams the file.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// Expected a multipart request, but got {request.ContentType}
        /// or
        /// Extension {ext} not supported
        /// </exception>
        public static async Task<StreamFileModel> StreamFile(this HttpRequest request)
        {
            if (!MultipartRequestHelper.IsMultipartContentType(request.ContentType))
            {
                throw new Exception($"Expected a multipart request, but got {request.ContentType}");
            }
            var boundary = MultipartRequestHelper.GetBoundary(request.ContentType);
            var reader = new MultipartReader(boundary, request.Body);
            var section = await reader.ReadNextSectionAsync();

            while (section != null)
            {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition,
                    out ContentDispositionHeaderValue contentDisposition);

                if (hasContentDispositionHeader)
                {
                    if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition))
                    {
                        var result = new StreamFileModel
                        {
                            Stream = section.Body,
                            FileName = contentDisposition.FileName.Value.Trim('"'),
                        };
                        // get format
                        var ext = Path.GetExtension(result.FileName);
                        switch (ext)
                        {
                            case ".xls":
                                result.FileType = FileType.Xls;
                                break;
                            case ".xlsx":
                                result.FileType = FileType.Xlsx;
                                break;
                            case ".csv":
                                result.FileType = FileType.Csv;
                                break;
                            case ".txt":
                                result.FileType = FileType.Txt;
                                break;
                            default:
                                throw new Exception($"Extension {ext} not supported");
                        }
                        return result;
                    }
                }

                // Drains any remaining section body that has not been consumed and
                // reads the headers for the next section.
                section = await reader.ReadNextSectionAsync();
            }
            return null;
        }
    }
}
