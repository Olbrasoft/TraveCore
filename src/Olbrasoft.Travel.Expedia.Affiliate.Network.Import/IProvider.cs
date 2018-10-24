﻿using System;

namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Import
{
    public interface IProvider
    {
        event EventHandler<string[]> SplittingLine;

        void ReadToEnd(string path);

        string GetFirstLine(string path);
    }
}