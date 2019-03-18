namespace Olbrasoft.Travel.Providers.Expedia
{
    public class ParserFactory : IParserFactory
    {
        public IParser<TEan> Create<TEan>(string firstLine) where TEan : class, new()
        {
            return new Parser<TEan>(firstLine);
        }

        public IPathsHotelsImagesParser Create()
        {
           return new PathsHotelsImages();
        }
    }
}