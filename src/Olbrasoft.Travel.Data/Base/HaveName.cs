namespace Olbrasoft.Travel.Data.Base
{
    public abstract class HaveName : OwnerCreatorIdAndCreator, IHaveName
    {
        public string Name { get; set; }
    }
}