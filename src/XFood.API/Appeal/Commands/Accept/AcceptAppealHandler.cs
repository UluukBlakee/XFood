using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using xFood.Infrastructure;
using XFood.Data;
using XFood.Data.Models;

namespace XFood.API.Appeal.Commands.Accept
{
    public class AcceptAppealHandler : ICommandHandler<AcceptAppealRequest, Result<AcceptAppealResponse>>
    {
        private readonly XFoodContext _context;
        private readonly EmailService _emailService;

        public AcceptAppealHandler(XFoodContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<Result<AcceptAppealResponse>> Handle(AcceptAppealRequest command, CancellationToken cancellationToken)
        {
            try
            {
                Data.Models.Appeal appeal = await _context.Appeals.Include(a => a.ChecklistCriteria).FirstOrDefaultAsync(a => a.Id == command.AppealId);
                if (appeal != null)
                {
                    appeal.Reply = command.Reply;
                    appeal.DateReply = DateTime.UtcNow;
                    appeal.Status = "Done";
                    appeal.IsApproved = true;
                    _context.Update(appeal);
                    if (appeal.ChecklistCriteria != null)
                    {
                        appeal.ChecklistCriteria.ReceivedPoints = command.ReceivedPoints;
                        _context.Update(appeal.ChecklistCriteria);
                    }
                    await _context.SaveChangesAsync();
                    string message = $"Здравствуйте, ваша апелляция было одобрено. \n\n" +
                        $"{appeal.Reply}";
                    await _emailService.SendEmailAsync(appeal.Email, "Ответ на апелляцию", message);
                    return Result.Success(new AcceptAppealResponse(true));
                }
                return Result.Failure<AcceptAppealResponse>("Аппеляция не найдена.");
            }
            catch (Exception ex)
            {
                return Result.Failure<AcceptAppealResponse>($"Ошибка при обработке аппеляции: {ex.Message}");
            }
        }
    }
}
