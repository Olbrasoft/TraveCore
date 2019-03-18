
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Repositories
{
    public interface ILoggingImports
    {
        void LogIn(Log log);

        void Log(string textForLogging);
    }
}