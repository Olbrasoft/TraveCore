using Olbrasoft.Travel.Data.Identity;

namespace Olbrasoft.Travel.Data.Base
{
    public class OwnerCreatorIdAndCreator : HaveCreatorId<int, int>
    {
        public new User Creator { get; set; }
    }
}