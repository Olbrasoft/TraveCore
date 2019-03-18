
namespace Olbrasoft.Travel.Providers.Expedia
{
    public interface IParserFactory
    {
        IParser<TEan> Create<TEan>(string firstLine) where TEan : class, new();
        IPathsHotelsImagesParser Create();
    }
}
