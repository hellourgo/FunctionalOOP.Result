namespace FunctionalOOP
{
    /// <summary>
    ///     A result representing nothing.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed class NoneResult<T> : INoneResult<T>
    {
    }

    /// <summary>
    ///     A result representing nothing.
    /// </summary>
    internal sealed class NoneResult : INoneResult
    {
    }
}