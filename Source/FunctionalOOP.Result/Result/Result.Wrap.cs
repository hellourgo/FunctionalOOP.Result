using System;
using System.Diagnostics.CodeAnalysis;

namespace FunctionalOOP
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "MemberCanBeInternal")]
    public static partial class Result
    {
        /// <summary>
        ///     Executes the <paramref name="function" /> and returns the result in an <see cref="ISuccessResult{T}" />.
        ///     If the return value is null, returns a <see cref="INoneResult" />. If an exception is thrown, returns a
        ///     <see cref="IFailureResult" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="function">The function to be wrapped in a result.</param>
        /// <param name="exceptionHandler">
        ///     The exception handler. This function allows the caller to provide the
        ///     <see cref="IFailureResult" /> with a custom exception.
        /// </param>
        /// <returns></returns>
        public static IResult<T> Wrap<T>(Func<T> function, Func<Exception, Exception> exceptionHandler = null)
        {
            try
            {
                return Return(function());
            }
            catch (Exception e)
            {
                return Wrap<T>(exceptionHandler, e);
            }
        }

        internal static IResult<T> Wrap<T>(Func<IResult<T>> function, Func<Exception, Exception> exceptionHandler = null)
        {
            try
            {
                return Return(function());
            }
            catch (Exception e)
            {
                return Wrap<T>(exceptionHandler, e);
            }
        }

        /// <summary>
        ///     Executes the <paramref name="action" /> and returns an <see cref="ISuccessResult" />.
        ///     If an exception is thrown, returns a <see cref="IFailureResult" />.
        /// </summary>
        /// <param name="action">The function to be wrapped in a result.</param>
        /// <param name="exceptionHandler">
        ///     The exception handler. This function allows the caller to provide the
        ///     <see cref="IFailureResult" /> with a custom exception.
        /// </param>
        /// <returns></returns>
        public static IResult<bool> Wrap(Action action, Func<Exception, Exception> exceptionHandler = null)
        {
            try
            {
                action();
                return Return(true);
            }
            catch (Exception e)
            {
                return Wrap<bool>(exceptionHandler, e);
            }
        }

        private static IFailureResult<T> Wrap<T>(Func<Exception,Exception> exceptionHandler, Exception exception)
        {
            var handler = exceptionHandler ?? (e => e);
            try
            {
                return (IFailureResult<T>) Return<T, Exception>(handler(exception));
            }
            catch (Exception e)
            {
                return (IFailureResult<T>) Return<T, Exception>(new ResultException("Exception Handler threw an exception!", e));
            }
        }
    }
}