﻿namespace Olbrasoft.Travel.Providers.Expedia.Import
{
    public class SharedProperties
    {
        public SharedProperties(int creatorId, int defaultLanguageId)
        {
            CreatorId = creatorId;
            DefaultLanguageId = defaultLanguageId;
        }

        public int DefaultLanguageId { get; set; }
        public int CreatorId { get; set; }
    }
}