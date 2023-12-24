using CSharpFunctionalExtensions;
using XFood.Data.Models;
using XFood.Data;
using xFood.Infrastructure;

namespace XFood.API.Manager.Commands.DeleteManager
{
    public class DeleteManagerHandler : ICommandHandler<DeleteManagerRequest, Result<DeleteManagerResponse>>
    {

        private readonly XFoodContext _db;
        public DeleteManagerHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<DeleteManagerResponse>> Handle(DeleteManagerRequest command, CancellationToken cancellationToken)
        {
            Data.Models.Manager manager = await _db.Managers.FindAsync(command.Id);
            if (manager != null)
            {
                _db.Remove(manager);
                var result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    return new DeleteManagerResponse(true);
                }
                else
                {
                    return Result.Failure<DeleteManagerResponse>("Не удалось удалить данные в базе данных.");
                }
            }
            return Result.Failure<DeleteManagerResponse>("Не удалось найти данные, попробуйте еще раз.");
        }
    }
}
