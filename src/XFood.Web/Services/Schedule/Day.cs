namespace XFoodBlazor.Web.Client.Services.Schedule
{
    public class Day
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public User? Expert { get; set; }
        public string? DayNumber { get; set; }
        public List<Time>? WorkTime { get; set; }
        public string? DayName { get; set; }
    }
}
