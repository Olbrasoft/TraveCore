using System;

namespace Olbrasoft.Travel.Data.Base
{
    /// <summary>
    /// I have a property that is called created, and it contains information about the date and time of creation.
    /// </summary>
    public interface IHaveDateAndTimeOfCreation
    {
        DateTime Created { get; set; }
    }
}