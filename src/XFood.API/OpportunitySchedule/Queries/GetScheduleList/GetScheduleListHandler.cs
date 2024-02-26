using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using xFood.Infrastructure;
using XFood.API.CriticalFactors.Queries.GetCriticalFactorList;
using XFood.API.CriticalFactors.Queries;
using XFood.Data;
using XFood.Data.Models;
using XFood.API.Time.Queries;

namespace XFood.API.OpportunitySchedule.Queries.GetScheduleList
{
    public class GetScheduleListHandler : IQueryHandler<GetScheduleListRequest, Result<GetScheduleListResponse>>
    {
        private readonly XFoodContext _db;
        public GetScheduleListHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<GetScheduleListResponse>> Handle(GetScheduleListRequest query, CancellationToken cancellation)
        {
            List<Data.Models.OpportunitySchedule> schedules = await _db.Schedules.ToListAsync();
            List<ScheduleView> list = schedules.Select(s => new ScheduleView
            {
                Id = s.Id,
                ExpertId = s.ExpertId,
                Day = s.Day,
                WorkTime = s.WorkTime.Select(m => new TimeView
                {
                    Id = m.Id,
                    EndOfPeriod = m.EndOfPeriod,
                    StartOfPeriod = m.StartOfPeriod,

                }).ToList(),
            }).ToList();
            return new GetScheduleListResponse(list);
        }
    }
}
