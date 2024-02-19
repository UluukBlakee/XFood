using CSharpFunctionalExtensions;
using XFood.Data;
using xFood.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace XFood.API.User.Queries.GetUser
{
    public class GetUserHandler : IQueryHandler<GetUserRequest, Result<GetUserResponse>>
    {
        private readonly XFoodContext _context;
        public GetUserHandler(XFoodContext context)
        {
            _context = context;
        }
        public async Task<Result<GetUserResponse>> Handle(GetUserRequest query, CancellationToken cancellation)
        {
            XFood.Data.Models.User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == query.Id);
            if (user != null)
            {
                UserView newUser = new UserView
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    FatherName = user.FatherName
                };

                return new GetUserResponse(newUser);
            }
            else
            {
                return Result.Failure<GetUserResponse>("Не удалось найти данные, попробуйте еще раз.");
            }
        }
    }
}