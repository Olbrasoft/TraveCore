using Olbrasoft.Travel.Data.Identity;

namespace Olbrasoft.Travel.Data.Base
{
    public class OwnerCreatorInfoAndCreator : CreatorInfo<int, int>
    {
        public new User Creator { get; set; }
    }
}