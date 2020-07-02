using System;
using System.Runtime.CompilerServices;

namespace LogAdatper
{
    public interface ILogWrapper
    {
        void Debug(string message, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0);

        void Debug(string message, Exception exception, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0);

        void Info(string message, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0);

        void Info(string message, Exception exception, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0);

        void Warn(string message, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0);

        void Warn(string message, Exception exception, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0);

        void Error(string message, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0);

        void Error(string message, Exception exception, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0);

        void Fatal(string message, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0);

        void Fatal(string message, Exception exception, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLine = 0);
    }
}