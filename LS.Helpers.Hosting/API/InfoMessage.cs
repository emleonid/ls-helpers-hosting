namespace LS.Helpers.Hosting.API
{
    /// <summary>
    /// InfoMessage
    /// </summary>
    public class InfoMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfoMessage"/> class.
        /// </summary>
        public InfoMessage()
            : this(string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoMessage"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public InfoMessage(string message)
            : this(string.Empty, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoMessage" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="message">The message.</param>
        public InfoMessage(string key, string message)
        {
            Title = key;
            MessageText = message;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        /// <value>
        /// The message text.
        /// </value>
        public string MessageText { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{base.ToString()}. Key: '{Title}', Message: '{MessageText}'";
        }
    }
}