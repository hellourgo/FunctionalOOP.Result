using System;
using Xunit;

namespace FunctionalOOP.ResultTests
{
    public class ReturnTests
    {
        [Fact]
        public void ResultTestSuccessAndNone()
        {
            Assert.IsAssignableFrom<ISuccessResult>(Result.Return("Hello"));
            Assert.IsAssignableFrom<ISuccessResult<string>>(Result.Return("Hello"));
        }

        [Fact]
        public void ResultTestNone()
        {
            string testString = null;
            Assert.IsAssignableFrom<INoneResult>(Result.Return<string>());
            Assert.IsAssignableFrom<INoneResult>(Result.Return(testString));
            Assert.False(Result.Return<string>() is IFailureResult);
        }

        [Fact]
        public void ResultPreventDoubleWrapTest()
        {
            var result = Result.Return(10);
            Assert.IsAssignableFrom<ISuccessResult<int>>(result);

            var doubleResult = Result.Return(result);
            Assert.IsAssignableFrom<ISuccessResult<int>>(doubleResult);
        }
    }
}
