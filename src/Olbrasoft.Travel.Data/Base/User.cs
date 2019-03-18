namespace Olbrasoft.Travel.Data.Base
{
    public class User<TKey> : CreationInfo<TKey>, IHaveUserName
    {
        public string UserName { get; set; }
    }
}