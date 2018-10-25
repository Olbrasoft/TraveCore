
using Olbrasoft.Travel.Data.Entity;

namespace Olbrasoft.Travel.Data.Repository
{
    public interface ILoggingImports
    {
        void LogIn(Log log);

        void Log(string textForLogging);
    }
}