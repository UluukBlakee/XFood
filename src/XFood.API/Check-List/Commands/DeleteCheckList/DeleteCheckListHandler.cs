﻿using CSharpFunctionalExtensions;
using XFood.API.Check_List.Commands.CreateCheckList;
using XFood.Data.Models;
using XFood.Data;
using xFood.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace XFood.API.Check_List.Commands.DeleteCheckList
{
    public class DeleteCheckListHandler : ICommandHandler<DeleteCheckListRequest, Result<DeleteCheckListResponse>>
    {

        private readonly XFoodContext _db;
        public DeleteCheckListHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<DeleteCheckListResponse>> Handle(DeleteCheckListRequest command, CancellationToken cancellationToken)
        {
            CheckList checkList = await _db.CheckLists.FirstOrDefaultAsync(cl => cl.Id == command.Id);
            _db.Remove(checkList);
            var result = await _db.SaveChangesAsync();
            if (result > 0)
            {
                return Result.Success(new DeleteCheckListResponse(true));
            }
            else
            {
                return Result.Failure<DeleteCheckListResponse>("Не удалось удалить данные в базе данных.");
            }
        }
    }
}
