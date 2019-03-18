using System;

namespace Olbrasoft.Travel.Providers.Expedia.Import
{
    public interface IImporter : IDisposable
    {
        void Import(string path);
    }
}