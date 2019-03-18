namespace Olbrasoft.Travel.Data.Base
{
    public interface IHaveCreatorId<TUserKey>
    {
        TUserKey CreatorId { get; set; }
       
    }
}