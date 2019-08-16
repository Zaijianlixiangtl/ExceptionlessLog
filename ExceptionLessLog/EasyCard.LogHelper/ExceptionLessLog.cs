using Exceptionless;
using Microsoft.Extensions.Configuration;
using Exceptionless.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCard.Framework.LogHelper
{
    public class ExceptionLessLog : ILogger
    {
       // private readonly IConfiguration configuration;
        private ExceptionlessClient _Exceptionless;

        private IConfiguration _IConfiguration;

        public ExceptionLessLog(IConfiguration configuration)
        {
            this._IConfiguration = configuration;
            _Exceptionless = new ExceptionlessClient();
            _Exceptionless.Configuration.ApiKey = _IConfiguration["Exceptionless:ApiKey"];
            _Exceptionless.Configuration.ServerUrl = _IConfiguration["Exceptionless:ServerUrl"];
        }

        public void Debug(string message, params string[] tags)
        {
            _Exceptionless.CreateLog(message,LogLevel.Debug)
                .AddTags(tags).Submit();
        }

        public void Error(string message, params string[] tags)
        {
            _Exceptionless.CreateLog(message, LogLevel.Error)
                .AddTags(tags).Submit();
        }

        public void Exception(Exception exception, params string[] tags)
        {
            _Exceptionless.CreateException(exception)
                .AddTags(tags).Submit();
        }

        public void Info(string message, params string[] tags)
        {
            _Exceptionless.CreateLog(message, LogLevel.Info)
                .AddTags(tags).Submit();
        }

        public void Warn(string message, params string[] tags)
        {
            _Exceptionless.CreateLog(message, LogLevel.Warn)
               .AddTags(tags).Submit();
        }
    }
}
