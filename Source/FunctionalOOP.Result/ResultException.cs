using System;
using System.Diagnostics.CodeAnalysis;

namespace FunctionalOOP
{
    /// <summary>
    ///     Represents errors that occured during operations in the <see cref="Result" /> class.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [SuppressMessage("ReSharper", "MemberCanBeInternal")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public sealed class ResultException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ResultException" /> class.
        /// </summary>
        public ResultException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ResultException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ResultException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ResultException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference (Nothing in
        ///     Visual Basic) if no inner exception is specified.
        /// </param>
        public ResultException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}