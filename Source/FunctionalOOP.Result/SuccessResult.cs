namespace FunctionalOOP
{
    internal sealed class SuccessResult<T> : ISuccessResult<T>
    {
        public SuccessResult(T value) => Value = value;

        public T Value { get; }
    }
}