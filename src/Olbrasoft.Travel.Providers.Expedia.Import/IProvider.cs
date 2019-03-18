using System;

namespace Olbrasoft.Travel.Providers.Expedia.Import
{
    public interface IProvider
    {
        event EventHandler<string[]> SplittingLine;

        void ReadToEnd(string path);

        string GetFirstLine(string path);
    }
}