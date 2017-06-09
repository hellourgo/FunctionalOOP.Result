// ReSharper disable MemberCanBeInternal
namespace FunctionalOOP
{
    /// <summary>
    ///     A result indicating success, without a return value.
    /// </summary>
    /// <seealso cref="IResult" />
    public interface ISuccessResult : IResult
    {
    }

    /// <summary>
    ///     A result indicating success, with a return value of type <typeparamref name="T" />.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="IResult" />
    public interface ISuccessResult<T> : ISuccessResult, IResult<T>
    {
        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        T Value { get; }
    }
}