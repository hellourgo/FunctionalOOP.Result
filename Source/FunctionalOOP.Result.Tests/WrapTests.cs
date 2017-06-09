using System;
using Xunit;

namespace FunctionalOOP.ResultTests
{
    public class WrapTests
    {
        [Fact]
        public void FunctionWrapSuccessTest()
        {
            var function = new Func<int>(() => 6);
            var result = Result.Wrap(function);
            Assert.IsAssignableFrom<ISuccessResult<int>>(result);
            Assert.Equal(function(), ((ISuccessResult<int>)result).Value);
        }

        [Fact]
        public void FunctionWrapFailureTest()
        {
            var exception = new Exception("Test");
            var function = new Func<int>(() => throw exception);
            var result = Result.Wrap(function);
            Assert.IsAssignableFrom<IFailureResult>(result);
            Assert.Equal(exception, ((IFailureResult)result).Exception);
        }

        [Fact]
        public void FunctionWrapExceptionHandlerTest()
        {
            var exception = new Exception("Test");
            var function = new Func<int>(() => throw exception);
            var handlerException = new Exception("Handler Test");
            var result = Result.Wrap(function, e => handlerException);
            Assert.IsAssignableFrom<IFailureResult>(result);
            Assert.NotEqual(exception, ((IFailureResult)result).Exception);
            Assert.Equal(handlerException, ((IFailureResult)result).Exception);

            result = Result.Wrap(function, e => throw handlerException);
            Assert.IsAssignableFrom<IFailureResult>(result);
            Assert.NotEqual(exception, ((IFailureResult)result).Exception);
            Assert.NotEqual(handlerException, ((IFailureResult)result).Exception);
            Assert.IsType<ResultException>(((IFailureResult)result).Exception);
        }

        [Fact]
        public void ActionWrapTest()
        {
            var action = new Action(() =>
                                    {
                                        var test = "Do Nothing";
                                    });
            var result = Result.Wrap(action);
            Assert.IsAssignableFrom<ISuccessResult<bool>>(result);
            Assert.True(((ISuccessResult<bool>)result).Value);
        }
    }
}