namespace Olbrasoft.Travel.Data.Entity
{
    public class BaseName : OwnerCreatorIdAndCreator, IHaveName
    {
        public string Name { get; set; }
    }
}