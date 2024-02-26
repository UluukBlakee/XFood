using System.ComponentModel.DataAnnotations;
using XFood.API.Time.Queries;

namespace XFood.API.CriticalFactors.Commands.CreateCriticalFactor
{
    public record CreateScheduleRequest([Required] int ExpertId, [Required] DateTime Day, List<TimeView> WorkTime);
}
