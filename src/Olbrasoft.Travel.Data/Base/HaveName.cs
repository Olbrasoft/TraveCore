namespace Olbrasoft.Travel.Data.Base
{
    public abstract class HaveName : OwnerCreatorInfoAndCreator, IHaveName
    {
        public string Name { get; set; }
    }
}