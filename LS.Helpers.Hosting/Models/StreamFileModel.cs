namespace LS.Helpers.Hosting.Models
{
    using System.IO;
    using Enums;

    /// <summary>
    /// Common model for file streaming upload
    /// </summary>
    public class StreamFileModel
    {
        /// <summary>
        /// Gets or sets the stream.
        /// </summary>
        /// <value>
        /// The stream.
        /// </value>
        public Stream Stream { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the type of the file.
        /// </summary>
        /// <value>
        /// The type of the file.
        /// </value>
        public FileType FileType { get; set; }
    }
}
