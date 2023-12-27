using CSharpFunctionalExtensions;
using XFood.Data.Models;
using XFood.Data;
using xFood.Infrastructure;

namespace XFood.API.Manager.Commands.CreateManager
{
    public class CreateManagerHandler : ICommandHandler<CreateManagerRequest, Result<CreateManagerResponse>>
    {
        private readonly XFoodContext _db;
        public CreateManagerHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<CreateManagerResponse>> Handle(CreateManagerRequest command, CancellationToken cancellationToken)
        {
            Data.Models.Manager manager = new Data.Models.Manager
            { 
                FirstName = command.FirstName,
                LastName = command.LastName,
                PizzeriaId = command.PizzeriaId 
            };
            await _db.AddAsync(manager);
            var result = await _db.SaveChangesAsync();
            if (result > 0)
            {
                return new CreateManagerResponse(manager.Id);
            }
            else
            {
                return Result.Failure<CreateManagerResponse>("Не удалось сохранить изменения в базе данных.");
            }
        }
    }
}
