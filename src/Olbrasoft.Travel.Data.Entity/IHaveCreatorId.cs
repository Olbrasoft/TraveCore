namespace Olbrasoft.Travel.Data.Entity
{
    public interface IHaveCreatorId<TUserKey>
    {
        TUserKey CreatorId { get; set; }
       
    }
}