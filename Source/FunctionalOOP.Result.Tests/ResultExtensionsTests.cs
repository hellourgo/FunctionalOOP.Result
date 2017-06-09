using Xunit;
namespace FunctionalOOP.ResultTests
{
    public class ResultExtensionsTests
    {
        [Fact]
        public void BindTest()
        {
            var bindSuccessResult = Result.Return("15").Bind(ParseFunction);
            var bindFailureResult = Result.Return("Hello").Bind(ParseFunction);
            var bindExceptionResult = Result.Return("Exception").Bind(ExceptionFunction);

            Assert.IsAssignableFrom<ISuccessResult<int>>(bindSuccessResult);
            Assert.IsAssignableFrom<IFailureResult>(bindFailureResult);
            Assert.IsAssignableFrom<IFailureResult>(bindExceptionResult);

            IResult<int> ParseFunction(string input)
            {
                return Result.Wrap(() => int.Parse(input));
            }

            IResult<int> ExceptionFunction(string input)
            {
                var value = int.Parse(input);
                return Result.Return(value);
            }
        }

        [Fact]
        public void CountTest()
        {
            Assert.Equal(1, Result.Return("Success").Count());
            Assert.Equal(0, Result.Return<object>().Count());
        }

        [Fact]
        public void ExistsTest()
        {
            var successValue = "Success";
            Assert.True(Result.Return(successValue).Exists(value => value == successValue));
            Assert.False(Result.Return("Failure").Exists(value => value == successValue));
            Assert.False(Result.Return<string>().Exists(value => value == successValue));
        }

        [Fact]
        public void FilterTest()
        {
            var intValue = 15;
            var testValue = 20;
            Assert.IsAssignableFrom<INoneResult>(Result.Return(intValue).Filter(value => value == testValue));
            Assert.IsAssignableFrom<ISuccessResult>(Result.Return(intValue).Filter(value => value < testValue));
        }

        [Fact]
        public void FoldTest()
        {
            var testString = "Hello";
            var initialState = 2;

            Assert.Equal(testString.Length + initialState, Result.Return(testString).Fold(Folder, initialState));
            Assert.Equal(initialState, Result.Return<string>().Fold(Folder, initialState));

            Assert.Throws<ResultException>(() => Result.Return("Test").Fold((_, value) => throw new ResultException(value), 2));

            int Folder(int value, string input) => input.Length + value;
        }

        [Fact]
        public void IterTest()
        {
            var testString = string.Empty;
            var newValue = "Hello";

            Result.Return<string>().Iter(value => testString = newValue);
            Assert.NotEqual(testString, newValue);

            Result.Return(testString).Iter(value => testString = newValue);
            Assert.Equal(testString, newValue);

            Assert.Throws<ResultException>(() => Result.Return("Test").Iter(value => throw new ResultException(value)));
        }

        [Fact]
        public void MapTest()
        {
            var mapSuccessResult = Result.Return("15").Map(ParseFunction);
            var mapFailureResult = Result.Return("Hello").Map(ParseFunction);

            Assert.IsAssignableFrom<ISuccessResult<int>>(mapSuccessResult);
            Assert.IsAssignableFrom<IFailureResult>(mapFailureResult);
            
            int ParseFunction(string input) => int.Parse(input);
        }
    }
}