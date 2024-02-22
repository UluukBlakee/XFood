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
                    Data.Models.CheckList checkList = await _context.CheckLists.Include(cl => cl.Pizzeria).Include(cl => cl.Manager).FirstOrDefaultAsync(cl => cl.Id == appeal.CheckListId);
                    Data.Models.ChecklistCriteria criteria = await _context.ChecklistCriteria.Include(c => c.Criterion).FirstOrDefaultAsync(c => c.Id == appeal.ChecklistCriteriaId);
                    string message = $@"
                    <html>
                    <head>
                        <style>
                            body {{
                                font-family: Arial, sans-serif;
                                font-size: 14px;
                                color: #333;
                            }}
                            .container {{
                                max-width: 600px;
                                margin: 0 auto;
                                padding: 20px;
                                border: 1px solid #ccc;
                                border-radius: 5px;
                                background-color: #f9f9f9;
                            }}
                            h1, h2, h3, h4, h5, h6 {{
                                color: #333;
                            }}
                            p {{
                                margin: 0 0 10px;
                            }}
                            img {{
                                max-width: 100%;
                                height: auto;
                                margin-top: 20px;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <h2>Решение по апелляции</h2>
                            <p><strong>Дата проверки:</strong> {checkList.EndCheck?.ToShortDateString()}</p>
                            <p><strong>Менеджер:</strong> {checkList.Manager.LastName} {checkList.Manager.FirstName}</p>
                            <p><strong>Критерий:</strong> {criteria.ReceivedPoints} {criteria.Criterion.Name}</p>
                            <p><strong>Апелляция:</strong> {appeal.Comment}</p>
                            <p><strong>Решение по апелляции:</strong> Не удовлетворена</p>
                            <p><strong>Комментарий:</strong> {appeal.Reply}. Результат {checkList.TotalPoints}</p>
                            <p>--</p>
                            <h3>Дмитрий Улыбин</h3>
                            <p>Лидер команды онлайн-контроллинга</p>
                            <p>d.ulybin.dodo@gmail.com</p>
                            <img src='https://upload.wikimedia.org/wikipedia/ru/thumb/9/91/Dodo_Logo.svg/1200px-Dodo_Logo.svg.png' alt='Dodo' />
                        </div>
                    </body>
                    </html>
                    ";
                    await _emailService.SendEmailAsync(appeal.Email, $"#{appeal.Id} {checkList.Pizzeria.Name} решение по апелляции", message);
                    return new RejectAppealResponse(true);
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
