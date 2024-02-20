namespace XFoodBlazor.Web.Client.Services.Schedule

{
    public class Time
    {
        public int Id { get; set; }
        public TimeOnly StartOfPeriod { get; set; }
        public TimeOnly EndOfPeriod { get; set; }
    }
}
