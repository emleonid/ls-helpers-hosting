namespace LS.Helpers.Hosting.Helpers
{
    using System;
    using System.Linq;
    using System.Text;
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Net.Http.Headers;

    /// <summary>
    /// MultipartRequestHelper
    /// </summary>
    public static class MultipartRequestHelper
    {
        /// <summary>
        /// Determines whether [is multipart content type] [the specified content type].
        /// </summary>
        /// <param name="contentType">Type of the content.</param>
        /// <returns>
        ///   <c>true</c> if [is multipart content type] [the specified content type]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMultipartContentType(string contentType)
        {
            return
                !string.IsNullOrEmpty(contentType) &&
                contentType.IndexOf("multipart/", StringComparison.OrdinalIgnoreCase) >= 0;
        }


        /// <summary>
        /// Gets the encoding.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <returns></returns>
        public static Encoding GetEncoding(MultipartSection section)
        {
            var hasMediaTypeHeader =
                MediaTypeHeaderValue.TryParse(section.ContentType, out MediaTypeHeaderValue mediaType);
            // UTF-7 is insecure and should not be honored. UTF-8 will succeed in 
            // most cases.
#pragma warning disable SYSLIB0001 // Type or member is obsolete
#pragma warning disable 618
            if (!hasMediaTypeHeader || Encoding.UTF7.Equals(mediaType.Encoding))
#pragma warning restore 618
#pragma warning restore SYSLIB0001 // Type or member is obsolete
            {
                return Encoding.UTF8;
            }
            return mediaType.Encoding;
        }

        /// <summary>
        /// Gets the boundary.
        /// </summary>
        /// <param name="contentType">Type of the content.</param>
        /// <returns></returns>
        public static string GetBoundary(string contentType)
        {
            var elements = contentType.Split(' ');
            var element = elements.First(entry => entry.StartsWith("boundary="));
            var boundary = element.Substring("boundary=".Length);
            // Remove quotes
            if (boundary.Length >= 2 && boundary[0] == '"' &&
                boundary[boundary.Length - 1] == '"')
            {
                boundary = boundary.Substring(1, boundary.Length - 2);
            }
            return boundary;
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <param name="contentDisposition">The content disposition.</param>
        /// <returns></returns>
        public static string GetFileName(string contentDisposition)
        {
            return contentDisposition
                .Split(';')
                .SingleOrDefault(part => part.Contains("filename"))
                ?.Split('=')
                .Last()
                .Trim('"');
        }


        /// <summary>
        /// Determines whether [has form data content disposition] [the specified content disposition].
        /// </summary>
        /// <param name="contentDisposition">The content disposition.</param>
        /// <returns>
        ///   <c>true</c> if [has form data content disposition] [the specified content disposition]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasFormDataContentDisposition(ContentDispositionHeaderValue contentDisposition)
        {
            // Content-Disposition: form-data; name="key";
            return contentDisposition != null
                   && contentDisposition.DispositionType.Equals("form-data")
                   && string.IsNullOrEmpty(contentDisposition.FileName.ToString())
                   && string.IsNullOrEmpty(contentDisposition.FileNameStar.ToString());
        }

        /// <summary>
        /// Determines whether [has file content disposition] [the specified content disposition].
        /// </summary>
        /// <param name="contentDisposition">The content disposition.</param>
        /// <returns>
        ///   <c>true</c> if [has file content disposition] [the specified content disposition]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasFileContentDisposition(ContentDispositionHeaderValue contentDisposition)
        {
            // Content-Disposition: form-data; name="myfile1"; filename="Misc 002.jpg"
            return contentDisposition != null
                   && contentDisposition.DispositionType.Equals("form-data")
                   && (!string.IsNullOrEmpty(contentDisposition.FileName.ToString())
                       || !string.IsNullOrEmpty(contentDisposition.FileNameStar.ToString()));
        }
    }
}
