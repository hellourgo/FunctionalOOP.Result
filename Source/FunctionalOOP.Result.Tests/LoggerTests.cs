using System;
using Xunit;

namespace FunctionalOOP.ResultTests
{
    public class LoggerTests : IClassFixture<LoggerTests>
    {
        public LoggerTests()
        {
            LogMessage = null;
            LogException = null;
            Result.SetLogger(Logger);
        }

        private string LogMessage { get; set; }

        private Exception LogException { get; set; }

        private void Logger(Exception exception)
        {
            LogMessage = exception.Message;
            LogException = exception;
        }

        private static IFailureResult GetFailureResult(Exception exception)
        {
            return (IFailureResult)Result.Wrap(() => throw exception);
        }

        [Fact]
        public void LoggerExceptionTest()
        {
            var exception = new ResultException("Exception");
            var failureResult = GetFailureResult(exception);
            Assert.IsAssignableFrom<IFailureResult>(failureResult);
            Assert.Equal(LogMessage, exception.Message);
            Assert.Equal(LogException, exception);
        }
    }
}