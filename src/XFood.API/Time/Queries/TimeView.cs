namespace XFood.API.Time.Queries
{
    public class TimeView
    {
        public int Id { get; set; }
        public TimeOnly StartOfPeriod { get; set; }
        public TimeOnly EndOfPeriod { get; set; }
    }
}
