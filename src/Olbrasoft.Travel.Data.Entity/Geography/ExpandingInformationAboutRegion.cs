namespace Olbrasoft.Travel.Data.Entity.Geography
{
    public class ExpandingInformationAboutRegion : OwnerCreatorIdAndCreator, IAdditionalRegionInfo
    {
        public string Code { get; set; }
        public Region Region { get; set; }
    }
}