namespace Olbrasoft.Travel.Data.Entity
{
    public class HaveCreatorId<TKey,TUserKey> : CreationInfo<TKey>, IHaveCreatorId<TUserKey>
    {
        public TUserKey CreatorId { get; set; }

        public User<TUserKey> Creator { get; set; }
    }
}