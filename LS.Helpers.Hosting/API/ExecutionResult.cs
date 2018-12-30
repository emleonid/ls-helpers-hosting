using System.Collections.Generic;

namespace LS.Helpers.Hosting.API
{

      /// <summary>
    /// Represents result of an action.
    /// </summary>
    public class ExecutionResult
    {
        private bool? _success;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionResult"/> class.
        /// </summary>
        public ExecutionResult()
            : this((ExecutionResult)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionResult"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public ExecutionResult(ErrorInfo error)
            : this(new[] { error })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionResult"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ExecutionResult(InfoMessage message)
            : this(new[] { message })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionResult"/> class.
        /// </summary>
        /// <param name="errors">The errors.</param>
        public ExecutionResult(IEnumerable<ErrorInfo> errors)
            : this((ExecutionResult)null)
        {
            foreach (var errorInfo in errors)
            {
                Errors.Add(errorInfo);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionResult"/> class.
        /// </summary>
        /// <param name="messages">The messages.</param>
        public ExecutionResult(IEnumerable<InfoMessage> messages)
            : this((ExecutionResult)null)
        {
            foreach (var message in messages)
            {
                Messages.Add(message);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionResult"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public ExecutionResult(ExecutionResult result)
        {
            if (result != null)
            {
                Success = result.Success;
                Errors = new List<ErrorInfo>(result.Errors);
                Messages = new List<InfoMessage>(result.Messages);
            }
            else
            {
                Errors = new List<ErrorInfo>();
                Messages = new List<InfoMessage>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether indicates if result is successful.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success
        {
            get => _success ?? Errors.Count == 0;
            set => _success = value;
        }

        /// <summary>
        /// Gets a list of errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IList<ErrorInfo> Errors { get; }

        /// <summary>
        /// Gets informmation messages
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        public IList<InfoMessage> Messages { get; }
    }
}