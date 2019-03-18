using System;
using Olbrasoft.Travel.Data.Base;

// ReSharper disable once CheckNamespace
namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.SomeNamespace
{
    public class SomeEntityObject : IHaveDateAndTimeOfCreation
    {
        public DateTime Created { get; set; }
    }
}