using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using log4net;

namespace LogAdatper
{
    public class LogWrapper : ILogWrapper
    {
        private readonly ILog _logger;

        public LogWrapper(ILog logger)
        {
            _logger = logger;
        }

        private string GetFormattedMessage(string message, string callerMember, int callerLine)
        {
            return $"{GetClassFullName()}.{callerMember}({callerLine}) - {message}.";
        }

        private string GetClassFullName()
        {
            return new StackTrace().GetFrame(1).GetMethod().ReflectedType.FullName;
        }

        public void Debug(string message, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0)
        {
            _logger.Debug(GetFormattedMessage(message, callerMember, callerLine));
        }

        public void Debug(string message, Exception exception, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0)
        {
            _logger.Debug(GetFormattedMessage(message, callerMember, callerLine), exception);
        }

        public void Info(string message, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0)
        {
            _logger.Info(GetFormattedMessage(message, callerMember, callerLine));
        }

        public void Info(string message, Exception exception, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0)
        {
            _logger.Info(GetFormattedMessage(message, callerMember, callerLine), exception);
        }

        public void Warn(string message, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0)
        {
            _logger.Warn(GetFormattedMessage(message, callerMember, callerLine));
        }

        public void Warn(string message, Exception exception, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0)
        {
            _logger.Warn(GetFormattedMessage(message, callerMember, callerLine), exception);
        }

        public void Error(string message, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0)
        {
            _logger.Error(GetFormattedMessage(message, callerMember, callerLine));
        }

        public void Error(string message, Exception exception, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0)
        {
            _logger.Error(GetFormattedMessage(message, callerMember, callerLine), exception);
        }

        public void Fatal(string message, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0)
        {
            _logger.Fatal(GetFormattedMessage(message, callerMember, callerLine));
        }

        public void Fatal(string message, Exception exception, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0)
        {
            _logger.Fatal(GetFormattedMessage(message, callerMember, callerLine), exception);
        }
    }
}
