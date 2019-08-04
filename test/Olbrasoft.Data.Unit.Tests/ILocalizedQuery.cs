﻿

using Olbrasoft.Querying;

namespace Olbrasoft.Data.Unit.Tests
{
    public interface ILocalizedQuery<TResult>:IQuery<TResult>,IHaveLanguageId
    {
    }
}