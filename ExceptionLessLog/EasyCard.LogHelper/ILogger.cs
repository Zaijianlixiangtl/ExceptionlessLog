using System;

namespace EasyCard.Framework.LogHelper
{
    public interface ILogger
    {
        void Debug(string message, params string[] args);
        void Info(string message, params string[] args);
        void Warn(string message, params string[] args);
        void Error(string message, params string[] args);
        void Exception(Exception exception, params string[] tags);
    }
}
