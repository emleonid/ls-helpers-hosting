namespace LS.Helpers.Hosting.API
{
    /// <summary>
    /// ErrorInfo
    /// </summary>
    public class ErrorInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorInfo"/> class.
        /// </summary>
        public ErrorInfo()
            : this(string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorInfo"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public ErrorInfo(string errorMessage)
            : this(string.Empty, errorMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorInfo"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="errorMessage">The error message.</param>
        public ErrorInfo(string key, string errorMessage)
        {
            Key = key;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{base.ToString()}. Key: '{Key}', ErrorMessage: '{ErrorMessage}'";
        }
    }
}