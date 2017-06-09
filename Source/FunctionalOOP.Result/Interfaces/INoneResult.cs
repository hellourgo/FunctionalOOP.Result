namespace FunctionalOOP
{
    /// <summary>
    ///     A result representing nothing.
    /// </summary>
    /// <seealso cref="IResult" />
    public interface INoneResult : IResult
    {
    }

    /// <summary>
    ///     A result representing nothing.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="IResult" />
    internal interface INoneResult<T> : INoneResult, IResult<T>
    {
    }
}