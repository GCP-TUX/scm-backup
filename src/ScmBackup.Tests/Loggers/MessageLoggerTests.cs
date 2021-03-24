﻿using ScmBackup.Loggers;
using System.Linq;
using Xunit;

namespace ScmBackup.Tests.Loggers
{
    public class MessageLoggerTests
    {
        [Fact]
        public void LogsMessage()
        {
            var msg = new LogMessages();
            var sut = new MessageLogger(msg);

            sut.Log(ErrorLevel.Info, "foo {0}", "bar");

            var result = msg.GetMessages().ToList();
            Assert.Single(result);

            string text = result.First();

            Assert.Contains("foo", text);
            Assert.Contains("bar", text);
            Assert.Contains("Info", text);
        }
    }
}
