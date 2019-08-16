using Microsoft.Extensions.DependencyInjection;

namespace EasyCard.Framework.LogHelper
{
    public static class LogIoc
    {
        public static void AddLog(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ILogger, ExceptionLessLog>();
        }
    }
}
