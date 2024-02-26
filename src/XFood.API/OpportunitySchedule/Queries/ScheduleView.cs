using XFood.API.Time.Queries;
using XFood.API.User.Queries;

namespace XFood.API.OpportunitySchedule.Queries
{
    public class ScheduleView
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public UserView? Expert { get; set; }
        public DateTime Day { get; set; }
        public List<TimeView>? WorkTime { get; set; }
    }
}
