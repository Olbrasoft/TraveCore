namespace Olbrasoft.Travel.Data.Entity
{
    public class User<TKey> : CreationInfo<TKey>, IHaveUserName
    {
        public string UserName { get; set; }
    }
}