using System.ComponentModel.DataAnnotations;
using Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Property;

namespace Olbrasoft.Travel.Providers.Expedia
{
    public class PathsHotelsImages : BaseParser<PathToHotelImage>, IPathsHotelsImagesParser
    {
        public override PathToHotelImage Parse(string[] items)
        {
            throw new System.NotImplementedException();
        }

        public override bool TryParse(string line, out PathToHotelImage entity)
        {
            var properties= line.Split('|');

            if (!int.TryParse(properties[0], out var eanHotelId))
            {
                entity = null;
                return false;
            }

            entity= new PathToHotelImage
            {
                EANHotelID =eanHotelId,
                URL = properties[2]
            };
            return Validator.TryValidateObject(entity, new ValidationContext(entity), null, true);
        }
        
    }
}