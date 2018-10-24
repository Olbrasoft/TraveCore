namespace Olbrasoft.Travel.Data.Entity
{
    public class OwnerCreatorIdAndCreator : HaveCreatorId<int, int>
    {
        public new Identity.User Creator { get; set; }
    }
}