using System.Collections.Generic;

namespace LS.Helpers.Hosting.API
{
    /// <summary>
    ///     Represents result of an action that returns any value
    /// </summary>
    /// <typeparam name="T">Type of value to be returned with action</typeparam>
    public class ExecutionResult<T> : ExecutionResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionResult{T}"/> class.
        /// </summary>
        public ExecutionResult()
            : this((ExecutionResult)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionResult{T}"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public ExecutionResult(T result)
            : this((ExecutionResult)null)
        {
            Value = result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionResult{T}"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="message">The message.</param>
        public ExecutionResult(T result, InfoMessage message)
            : this((ExecutionResult)null)
        {
            Value = result;
            Messages.Add(message);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionResult{T}" /> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public ExecutionResult(ExecutionResult result)
            : base(result)
        {
            if (result is ExecutionResult<T> r)
            {
                Value = r.Value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionResult{T}"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public ExecutionResult(ErrorInfo error)
            : this(new[] { error })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionResult{T}"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ExecutionResult(InfoMessage message)
            : this(new[] { message })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionResult{T}"/> class.
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
        /// Initializes a new instance of the <see cref="ExecutionResult{T}"/> class.
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
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }
    }
}