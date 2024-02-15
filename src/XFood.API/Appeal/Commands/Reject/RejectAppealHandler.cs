using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using xFood.Infrastructure;
using XFood.Data;

namespace XFood.API.Appeal.Commands.Reject
{
    public class RejectAppealHandler : ICommandHandler<RejectAppealRequest, Result<RejectAppealResponse>>
    {
        private readonly XFoodContext _context;
        private readonly EmailService _emailService;

        public RejectAppealHandler(XFoodContext context, EmailService emailService)
        {
            _context = context;            _emailService = emailService;

        }

        public async Task<Result<RejectAppealResponse>> Handle(RejectAppealRequest command, CancellationToken cancellationToken)
        {
            try
            {
                Data.Models.Appeal appeal = await _context.Appeals.FirstOrDefaultAsync(a => a.Id == command.AppealId);
                if (appeal != null)
                {
                    appeal.Reply = command.Reply;
                    appeal.DateReply = DateTime.UtcNow;
                    appeal.Status = "Done";
                    appeal.IsApproved = false;
                    _context.Update(appeal);
                    await _context.SaveChangesAsync();
                    string message = $"Здравствуйте, ваша апелляция было отклонено. \n\n" +
                    $"{appeal.Reply}";
                    await _emailService.SendEmailAsync(appeal.Email, "Ответ на апелляцию", message);
                    return Result.Success(new RejectAppealResponse(true));
                }
                return Result.Failure<RejectAppealResponse>("Аппеляция не найдена.");
            }
            catch (Exception ex)
            {
                return Result.Failure<RejectAppealResponse>($"Ошибка при обработке аппеляции: {ex.Message}");
            }
        }
    }
}
