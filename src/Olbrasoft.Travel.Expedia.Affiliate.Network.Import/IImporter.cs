using System;

namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Import
{
    public interface IImporter : IDisposable
    {
        void Import(string path);
    }
}