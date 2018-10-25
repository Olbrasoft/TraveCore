namespace Olbrasoft.Travel.Data.Entity
{
    public class Log : OwnerCreatorIdAndCreator
    {
        public string Text { get; set; }

        public int LevelId { get; set; }

        public LogLevel Level { get; set; }
    }
}