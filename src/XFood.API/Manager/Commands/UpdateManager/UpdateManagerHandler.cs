using CSharpFunctionalExtensions;
using XFood.Data;
using xFood.Infrastructure;

namespace XFood.API.Manager.Commands.UpdateManager
{
    public class UpdateManagerHandler : ICommandHandler<UpdateManagerRequest, Result<UpdateManagerResponse>>
    {

        private readonly XFoodContext _db;
        public UpdateManagerHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<UpdateManagerResponse>> Handle(UpdateManagerRequest command, CancellationToken cancellationToken)
        {
            Data.Models.Manager manager = await _db.Managers.FindAsync(command.Id);
            if (manager != null)
            {
                manager.Id = command.Id;
                manager.FirstName = command.FirstName;
                manager.LastName = command.LastName;
                manager.PizzeriaId = command.PizzeriaId;
                _db.Update(manager);
                var result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    return new UpdateManagerResponse(true);
                }
                else
                {
                    return Result.Failure<UpdateManagerResponse>("Не удалось сохранить изменения в базе данных.");
                }
            }
            else
            {
                return Result.Failure<UpdateManagerResponse>("Не удалось найти данные, попробуйте еще раз.");
            }
        }
    }
}
