using System;
using System.Diagnostics.CodeAnalysis;

namespace FunctionalOOP
{
    /// <summary>
    ///     Provides helper methods for handling <see cref="IResult" /> objects.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBeInternal")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static partial class Result
    {
        /// <summary>
        ///     Wraps the specified value in a <see cref="ISuccessResult{T}" />. If the value is null, returns
        ///     <see cref="INoneResult" />
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IResult<T> Return<T>(T value) => value == null
            ? Return<T>()
            : new SuccessResult<T>(value);

        /// <summary>
        ///     Returns a <see cref="INoneResult{T}" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IResult<T> Return<T>() => new NoneResult<T>();

        /// <summary>
        ///     Returns a <see cref="INoneResult" />.
        /// </summary>
        /// <returns></returns>
        public static IResult Return() => new NoneResult();

        /// <summary>
        ///     Overload for Wrap that prevents double-wrapping an <see cref="IResult{T}" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IResult<T> Return<T>(IResult<T> value) => value;

        /// <summary>
        ///     Overload for Wrap that prevents double-wrapping an <see cref="IResult" />.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IResult Return(IResult value) => value;

        /// <summary>
        ///     Wraps the specified exception in a <see cref="IFailureResult" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public static IResult<T> Return<T, TException>(TException exception) where TException : Exception 
            => new FailureResult<T>(exception);

        /// <summary>
        ///     Wraps the specified <see cref="IFailureResult" /> with a typed <see cref="IFailureResult{T}" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="failure">The failure.</param>
        /// <returns></returns>
        internal static IFailureResult<T> Return<T>(IFailureResult failure) => new FailureResult<T>(failure);
    }
}