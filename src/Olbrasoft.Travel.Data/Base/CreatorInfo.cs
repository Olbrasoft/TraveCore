namespace Olbrasoft.Travel.Data.Base
{
    public class
        CreatorInfo<TKey, TUserKey> : CreationInfo<TKey>, IHaveCreatorId<TUserKey>
    {
        public TUserKey CreatorId { get; set; }

        public User<TUserKey> Creator { get; set; }
    }
}