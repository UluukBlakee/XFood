using CSharpFunctionalExtensions;
using XFood.Data;
using xFood.Infrastructure;
using Microsoft.EntityFrameworkCore;
using XFood.Data.Models;

namespace XFood.API.User.Queries.GetList
{
    public class GetUserListHandler : IQueryHandler<GetUserListRequest, Result<GetUserListResponse>>
    {
        private readonly XFoodContext _db;
        public GetUserListHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<GetUserListResponse>> Handle(GetUserListRequest query, CancellationToken cancellation)
        {
            List<Data.Models.User> users = await _db.Users.Where(u => u.UserName != "admin").ToListAsync();
            List<UserView> list = users.Select(user => new UserView
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FatherName = user.FatherName,
                UserName = user.UserName
            }).ToList();
            return new GetUserListResponse(list);
        }
    }
}
