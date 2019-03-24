namespace Olbrasoft.Travel.Data.Base
{
    public class Log : OwnerCreatorInfoAndCreator
    {
        public string Text { get; set; }

        public int LevelId { get; set; }

        public LogLevel Level { get; set; }
    }
}