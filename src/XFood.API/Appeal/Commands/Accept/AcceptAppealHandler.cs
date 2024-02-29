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
                int recivedPoints = appeal.ChecklistCriteria.ReceivedPoints;
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
                            <p><strong>Критерий:</strong> {recivedPoints} {criteria.Criterion.Name}</p>
                            <p><strong>Апелляция:</strong> {appeal.Comment}</p>
                            <p><strong>Решение по апелляции:</strong> Удовлетворена</p>
                            <p><strong>Комментарий:</strong> {appeal.Reply}. Результат {checkList.TotalPoints}</p>
                            <p>--</p>
                            <h3>Дмитрий Улыбин</h3>
                            <р>Лидер команды онлайн-контроллинга</p>
                            <p>d.ulybin.dodo@gmail.com</p>
                            <img src='https://crm-media-bucket.s3.amazonaws.com/media/2023-11-28/7f4a55eb-e5bd-4ff3-a3c7-96ee66c601c51701163760186.png' alt='Dodo' />
                        </div>
                    </body>
                    </html>
                    ";
                    await _emailService.SendEmailAsync(appeal.Email, $"#{appeal.Id} {checkList.Pizzeria.Name} решение по апелляции", message);

                    return new AcceptAppealResponse(true);
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
