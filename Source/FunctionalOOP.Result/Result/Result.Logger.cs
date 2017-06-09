using System;
using System.Diagnostics.CodeAnalysis;

namespace FunctionalOOP
{
    /// <summary>
    ///     Provides the setter for the log action that takes place when a <see cref="IFailureResult" /> is constructed.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBeInternal")]
    public static partial class Result
    {
        internal static Action<Exception> Logger { get; private set; } = exception => { };

        /// <summary>
        ///     Sets the logger.
        /// </summary>
        /// <param name="action">The action.</param>
        public static void SetLogger(Action<Exception> action)
        {
            Logger = action;
        }
    }
}