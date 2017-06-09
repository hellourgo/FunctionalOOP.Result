using System;

namespace FunctionalOOP
{
    internal sealed class FailureResult<T> : FailureResult, IFailureResult<T>
    {
        public FailureResult(Exception exception) : base(exception)
        {
        }

        public FailureResult(IFailureResult failure) : base(failure)
        {
        }
    }

    internal class FailureResult : IFailureResult
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FailureResult" /> class.
        ///     Utilizes the Logger action in <see cref="Result" /> to log exceptions.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public FailureResult(Exception exception)
        {
            Exception = exception ?? new Exception("Null Exception Passed");
            Result.Logger(Exception);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FailureResult" /> class. Prevents multiple logging actions being fired
        ///     when changing between different types.
        /// </summary>
        /// <param name="failure">The failure.</param>
        protected FailureResult(IFailureResult failure) => Exception = failure.Exception;

        public Exception Exception { get; }
    }
}